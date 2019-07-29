using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using OCR.Utils.Extensions.UIs;
using OCR.Utils.Helpers.DriverControls;

namespace OCR.Views.Additions.Dialogs
{
    public partial class CameraDeviceSelectDialog : Form
    {
        #region static
        public static DialogResult ShowCustomDialog(out int camIndex)
        {
            camIndex = -1;
            using (CameraDeviceSelectDialog dialog = new CameraDeviceSelectDialog())
            {
                var diRes = dialog.ShowDialog();
                if (dialog.cbb_CameraDevices.SelectedItem != null)
                    camIndex = dialog.cbb_CameraDevices.SelectedIndex;
                return diRes;
            }
        }
        #endregion
        #region instance
        private CameraDeviceSelectDialog()
        {
            InitializeComponent();
        }

        private void CameraDeviceSelectDialog_Load(object sender, EventArgs e)
        {
            var devices = CameraControl.GetCameraDevice();
            cbb_CameraDevices.UpdateUI(devices, devices.FirstOrDefault());
        }

        private async void Cbb_CameraDevices_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            var cbb = sender as ComboBox;
            if (cbb.SelectedItem != null)
            {
                if (backgroundWorkerCamPreview.IsBusy)
                    backgroundWorkerCamPreview.CancelAsync();
                while (backgroundWorkerCamPreview.IsBusy)
                    await Task.Delay(10).ConfigureAwait(true);
                backgroundWorkerCamPreview.RunWorkerAsync(cbb.SelectedIndex);
            }
            else
            {
                if (backgroundWorkerCamPreview.IsBusy)
                    backgroundWorkerCamPreview.CancelAsync();
            }
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BackgroundWorkerCamPreview_DoWork(object sender, DoWorkEventArgs e)
        {
            var bw = sender as BackgroundWorker;
            int deviceIndex = 0;
            if (e.Argument != null)
            {
                deviceIndex = (int)e.Argument;
            }
            else
            {
                return;
            }
            using (VideoCapture videoCapture = new VideoCapture(deviceIndex))
            {
                if (!videoCapture.IsOpened)
                {
                    this.InvokeOnUIThreadASync(() =>
                    {
                        MessageBox.Show("Không thể mở thiết bị, kiểm tra lại thiết bị.", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                    return;
                }
                using (Mat m = new Mat())
                {
                    while (!bw.CancellationPending && videoCapture.IsOpened)
                    {
                        videoCapture.Read(m);
                        try
                        {
                            this.InvokeOnUIThreadSync(() =>
                            {
                                pictureBox1.Image = m.Bitmap;
                            });
                        }
                        catch (InvalidOperationException ex)
                        {
                            Debug.WriteLine(ex.Message);
                            return;
                        }
                        catch (AccessViolationException exx)
                        {
                            Debug.WriteLine(exx.Message);
                        }
                        Thread.Sleep(50);
                    }
                }
                Debug.WriteLine("BackgroundWorkerCamPreview_DoWork Terminate.");
            }
        }

        private void CameraDeviceSelectDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorkerCamPreview.IsBusy)
                backgroundWorkerCamPreview.CancelAsync();
        }
        #endregion
    }
}
