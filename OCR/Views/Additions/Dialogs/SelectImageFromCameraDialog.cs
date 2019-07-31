﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using OCR.Processors.Handlers;
using OCR.Processors.Interfaces;
using OCR.Utils.Extensions.UIs;

namespace OCR.Views.Additions.Dialogs
{
    public partial class SelectImageFromCameraDialog : Form
    {
        #region static
        public static DialogResult ShowCustomDialog(out IImage img)
        {
            using (SelectImageFromCameraDialog dialog = new SelectImageFromCameraDialog())
            {
                DialogResult res = dialog.ShowDialog();
                img = res == DialogResult.OK ? dialog._image : null;
                return res;
            }
        }
        #endregion
        #region instance
        #region dependencyinjection
        private readonly IDetectPaperArea _detectPaper = DetectPaperArea.MakeInstance();
        #endregion
        private SelectImageFromCameraDialog()
        {
            InitializeComponent();
        }

        public int CamIndex { get; private set; }


        private (IImage imgOriginal, IImage imgDrawed, RotatedRect rotated) _resultCache = (null, null, RotatedRect.Empty);
        private bool _pauseVideoCapture = false;
        private IImage _image;

        private void BackgroundWorkerForVideoCapture_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            if (e.Argument == null)
            {
                return;
            }

            if (!(e.Argument is int))
            {
                return;
            }

            int camIndex = (int)e.Argument;
            if (camIndex < 0)
            {
                return;
            }

            using (VideoCapture capture = new VideoCapture(camIndex))
            {
                using (Mat m = new Mat())
                {
                    while (!bw.CancellationPending && capture.IsOpened)
                    {
                        if (_pauseVideoCapture)
                        {
                            Thread.Sleep(50);
                            continue;
                        }
                        capture.Read(m);
                        try
                        {
                            _resultCache = _detectPaper.DetectAndDrawPaperArea(m, _resultCache.rotated);
                            this.InvokeOnUIThreadSync(() =>
                            {
                                pictureBox_ImgPreview.Image = _resultCache.imgDrawed.Bitmap;
                            });
                        }
                        catch (InvalidOperationException ex)
                        {
                            Debug.WriteLine(ex.Message);
                            return;
                        }
                        Thread.Sleep(60);
                    }
                }
            }
        }

        /// <summary>
        /// Create hotkey
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (btn_Capture.Enabled && e?.KeyChar == 'c')
            {
                btn_Capture.PerformClick();
            }
            base.OnKeyPress(e);
        }
        private void BackgroundWorkerForVideoCapture_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void Btn_SelectCapture_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerForVideoCapture.IsBusy)
            {
                backgroundWorkerForVideoCapture.CancelAsync();
            }

            if (CameraDeviceSelectDialog.ShowCustomDialog(out int camIndex) != DialogResult.OK)
            {
                CamIndex = -1;
                return;
            }
            CamIndex = camIndex;
            backgroundWorkerForVideoCapture.RunWorkerAsync(CamIndex);
        }

        private void Btn_Capture_Click(object sender, EventArgs e)
        {
            _image = null;
            if (_pauseVideoCapture)
            {
                _pauseVideoCapture = false;
                btn_Capture.Text = "Chụp lại";
                return;
            }
            _pauseVideoCapture = true;
            IImage paperArea = _detectPaper.ExtractPaperArea(_resultCache.imgOriginal, _resultCache.rotated);
            if (paperArea == null)
            {
                MessageBox.Show("Không tìm thấy.", "Không thể tìm thấy khu vực nhận dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox_ImgPreview.Image = paperArea.Bitmap;
            _image = paperArea;
            btn_Capture.Text = "Tiếp tục";
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            if (_image == null)
            {
                MessageBox.Show("Chưa có hình nào được chọn.\nNhấn và Chụp lại để chụp ảnh.", "Chưa lấy hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion
    }
}
