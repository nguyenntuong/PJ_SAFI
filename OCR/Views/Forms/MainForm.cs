﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OCR.DAO.Interfaces;
using OCR.DAO.Locals;
using OCR.Models.Locals;
using OCR.Processors.Handlers;
using OCR.Processors.Interfaces;
using OCR.Utils.Enum;
using OCR.Utils.Extensions.Objects;
using OCR.Utils.Extensions.Structs;
using OCR.Utils.Extensions.UIs;
using OCR.Utils.Helpers.DriverControls;
using OCR.Views.Additions.Dialogs;
using OCR.Views.Forms.ForTest;
using WIA;

namespace OCR.Views.Forms
{
    public partial class MainForm : Form
    {
        #region instance

        /// <summary>
        /// Ảnh hiện tại trên chương trình, dùng để xử lý chính
        /// </summary>
        private List<CImage> _images = new List<CImage>();
        /// <summary>
        /// Index hiện tại trong danh sách ảnh
        /// </summary>
        private int _currentImageIndex = 0;
        /// <summary>
        /// Vùng ảnh được chọn sau khi bật tính năng crop
        /// </summary>
        private Image<Bgr, byte> _imageSelectedRegion = null;

        /// <summary>
        /// Tracking hành vi chuột phục vụ vẽ vời
        /// </summary>
        private bool _isMouseButtonRelease = true;
        /// <summary>
        /// 2 điểm kéo chuột để vẽ khu vực chọn
        /// </summary>
        private List<Point> _pointsForDrawRect = new List<Point>(2);

        private InputMode _inputMode;
        /// <summary>
        /// Scanner id
        /// </summary>
        private string _scannerID;
        private string ScannerID
        {
            get => _scannerID;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _inputMode = InputMode.Normal;
                    btn_Scan.Enabled = false;
                }
                else
                {
                    _inputMode = InputMode.ScanMode;
                    btn_Scan.Enabled = true;
                }
                _scannerID = value;
            }
        }
        /// <summary>
        /// Scanner id
        /// </summary>
        private int _camIndex;
        private int CamIndex
        {
            get => _camIndex;
            set
            {
                if (value < 0)
                {
                    _inputMode = InputMode.Normal;
                    btn_Scan.Enabled = false;
                }
                else
                {
                    _inputMode = InputMode.CamMode;
                    btn_Scan.Enabled = true;
                }
                _camIndex = value;
            }
        }

        /// <summary>
        /// Giử lại hình hiện tại trong chế độ CAM
        /// </summary>
        private volatile bool _pauseVideoCapture = false;

        #region Dependency Injection
        private readonly IAppConfig _appConfig = AppConfig.DefaultInstance();
        private readonly IROIProfilesResource _regionProfiles = ROIProfilesResource.DefaultInstance();
        private readonly ITesseractLanguages _tesseractLanguages = TesseractLanguages.DefaultInstance();
        private readonly IImportImage _importImage = ImportImage.Instance(DetectPaperArea.MakeInstance());
        #endregion
        public MainForm()
        {
            InitializeComponent();
        }

        #region delegateevent


        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerForOCRFullCharacterOrROI.IsBusy)
            {
                backgroundWorkerForOCRFullCharacterOrROI.CancelAsync();
            }
            if (backgroundWorkerForOCRROIAllImage.IsBusy)
            {
                backgroundWorkerForOCRROIAllImage.CancelAsync();
            }
            if (backgroundWorkerForOCRROISingleImage.IsBusy)
            {
                backgroundWorkerForOCRROISingleImage.CancelAsync();
            }
        }

        private void StopProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerVideoCapture.IsBusy)
                backgroundWorkerVideoCapture.CancelAsync();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                if (openFile.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                _images.Clear();
                backgroundWorkerForLoadImage.RunWorkerAsync(openFile.FileName);
            }
        }

        private void LangComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_images.Count == 0)
            {
                MessageBox.Show("Chọn hình trước !", "Chưa chọn hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (ThresholdAdjustForm f = new ThresholdAdjustForm(ChangeThreshold))
            {
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Sửa lỗi chính tả dự trên từ điển
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpellCheckEditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnOCRProcess_Click(object sender, EventArgs e)
        {
            if (cbb_Lang.SelectedItem == null)
            {
                MessageBox.Show("Chọn ngôn ngữ trước !", "Chưa chọn ngôn ngữ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_images.Count == 0)
            {
                MessageBox.Show("Chọn hình trước !", "Chưa chọn hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(dataGridView_Result.Tag is bool))
            {
                CreateDataGridView();
            }
            backgroundWorkerForOCRFullCharacterOrROI.RunWorkerAsync(cbb_Lang.SelectedItem);
        }

        /// <summary>
        /// Đánh dấu ảnh đang được xữ lý không thể xữ lú tiếp
        /// </summary>
        private bool _isProc = false;
        private void ChangeThreshold(object sender, int value)
        {
            if (_isProc == true)
            {
                return;
            }

            _isProc = true;
            this.InvokeOnUIThreadSync(() =>
            {
                pictureBox_ScanImage.Image = _images[_currentImageIndex].ThresholdBinary(value).Bitmap;
            });
            _isProc = false;
        }

        private void btnClearTxt_Click(object sender, EventArgs e)
        {
            ClearDataGridView();
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            if (_images.Count == 0)
            {
                MessageBox.Show("Chọn hình trước !", "Chưa chọn hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox_ScanImage.Image = _images[_currentImageIndex].RotateLeft().Bitmap;
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            if (_images.Count == 0)
            {
                MessageBox.Show("Chọn hình trước !", "Chưa chọn hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox_ScanImage.Image = _images[_currentImageIndex].RotateRight().Bitmap;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "(*.txt)|*.txt|(*.csv)|*.csv",
                DefaultExt = "txt"
            })
            {
                if (saveFile.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                StreamWriter streamWriter = new StreamWriter(File.OpenWrite(saveFile.FileName));
                for (int i = 0; i < dataGridView_Result.Columns.Count; i++)
                {
                    var col = dataGridView_Result.Columns[i];
                    streamWriter.Write($"{col.Name?.ToString().Replace("\n", "")},");
                }
                streamWriter.WriteLine();
                for (int rid = 0; rid < dataGridView_Result.Rows.Count - 1; rid++)
                {
                    DataGridViewCellCollection cells = dataGridView_Result.Rows[rid].Cells;
                    for (int cid = 0; cid < cells.Count; cid++)
                    {
                        streamWriter.Write($"{cells[cid]?.Value?.ToString().Replace("\n", "")},");
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.Close();
                var res = MessageBox.Show("Lưu thành công.\nCó muốn mở ngay.", "Thành công!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    Process.Start(saveFile.FileName);
                }
            }
        }

        private void pcBoxScanImage_MouseDown(object sender, MouseEventArgs e)
        {
            ClearPoint();
            if (e.Button == MouseButtons.Left)
            {
                _isMouseButtonRelease = false;
                _pointsForDrawRect.Add(e.Location);
            }
        }

        private void pcBoxScanImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _pointsForDrawRect.Add(e.Location);
                if (_pointsForDrawRect.Count == 2)
                {
                    using (VectorOfPoint vector = new VectorOfPoint(_pointsForDrawRect.ToArray()))
                    {
                        Rectangle rect = CvInvoke.BoundingRectangle(vector);
                        ClearPoint();
                        if (rect.Width > ROI.MINIMUNSIZE && rect.Height > ROI.MINIMUNSIZE)
                        {
                            using (Graphics g = pictureBox_ScanImage.CreateGraphics())
                            {
                                using (Pen p = new Pen(Brushes.Red))
                                {
                                    g.DrawRectangle(p, rect);
                                }
                            }
                            Image<Bgr, byte> imgOrginal = _images[_currentImageIndex].GetOriginalImage() as Image<Bgr, byte>;
                            imgOrginal.ROI = rect.ConvertToActualyImageSizeWithAcc(pictureBox_ScanImage).ConvertToActualyImageSizeRemoveAcc();
                            _imageSelectedRegion = imgOrginal.Copy();
                            using (Form showimg = new ShowImageForm(_imageSelectedRegion))
                            {
                                showimg.ShowDialog();
                            }
                            imgOrginal.ROI = Rectangle.Empty;
                        }
                    }
                }
            }
            _isMouseButtonRelease = true;
        }

        private void pcBoxScanImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMouseButtonRelease)
            {
                using (VectorOfPoint vector = new VectorOfPoint(new[] { _pointsForDrawRect[0], e.Location }))
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(vector);
                    using (Graphics g = pictureBox_ScanImage.CreateGraphics())
                    {
                        pictureBox_ScanImage.Refresh();
                        using (Pen p = new Pen(Brushes.Red))
                        {
                            g.DrawRectangle(p, rect);
                        }
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _imageSelectedRegion = null;
            ClearPoint();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbb_Lang.UpdateUI(_tesseractLanguages.Languages);
            if (cbb_Lang.Items.Count > 0)
            {
                cbb_Lang.SelectedIndex = 0;
            }

            cbb_RegionProfile.UpdateUI(_regionProfiles.Profiles);
            if (cbb_RegionProfile.Items.Count > 0)
            {
                cbb_RegionProfile.SelectedIndex = 0;
            }
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_currentImageIndex > 0)
            {
                _currentImageIndex--;
            }
            backgroundWorkerForLoadImage.RunWorkerAsync(_currentImageIndex);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_currentImageIndex < _images.Count - 1)
            {
                _currentImageIndex++;
            }
            backgroundWorkerForLoadImage.RunWorkerAsync(_currentImageIndex);
        }

        private void btnExtractROISingleImage_Click(object sender, EventArgs e)
        {
            if (cbb_RegionProfile.SelectedItem == null || _appConfig.GetConfig<ROIProfile>("CurrentRegionProfile") == null)
            {
                MessageBox.Show("Chọn một cấu hình cụ thể ở danh sách cấu hình.", "Chưa chọn cấu hình.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_RegionProfile.UpdateUI(_regionProfiles.Profiles);
                return;
            }
            if (_images.Count == 0)
            {
                MessageBox.Show("Chọn hình, hoặc thư mục chứa hình trước !", "Chưa chọn hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ROIProfile rOIProfile = _appConfig.GetConfig<ROIProfile>("CurrentRegionProfile");
            if (!(dataGridView_Result.Tag is ROIProfile) || (dataGridView_Result.Tag as ROIProfile) != rOIProfile)
            {
                CreateDataGridView(rOIProfile);
            }
            backgroundWorkerForOCRROISingleImage.RunWorkerAsync(rOIProfile);
        }

        private void ChoseRegionInPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RegionSelectForm RSF = new RegionSelectForm())
            {
                RSF.ShowDialog();
                cbb_RegionProfile.UpdateUI(_regionProfiles.Profiles, _appConfig.GetConfig<ROIProfile>("CurrentRegionProfile")?.Name);
            }
        }

        private void AddPaperProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaperProfileDialog.ShowCustomDialog();
        }

        private void RegionProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageProfileDialog.ShowCustomDialog();
            List<string> lstProfile = _regionProfiles.Profiles;
            cbb_RegionProfile.UpdateUI(lstProfile, lstProfile.FirstOrDefault());
        }

        private void Btn_ExtractBaseOnROIAllImage_Click(object sender, EventArgs e)
        {
            if (cbb_RegionProfile.SelectedItem == null || _appConfig.GetConfig<ROIProfile>("CurrentRegionProfile") == null)
            {
                MessageBox.Show("Chọn một cấu hình cụ thể ở danh sách cấu hình.", "Chưa chọn cấu hình.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbb_RegionProfile.UpdateUI(_regionProfiles.Profiles);
                return;
            }
            if (_images.Count == 0)
            {
                MessageBox.Show("Chọn hình, hoặc thư mục chứa hình trước !", "Chưa chọn hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ROIProfile rOIProfile = _appConfig.GetConfig<ROIProfile>("CurrentRegionProfile");
            if (!(dataGridView_Result.Tag is ROIProfile) || (dataGridView_Result.Tag as ROIProfile) != rOIProfile)
            {
                CreateDataGridView(rOIProfile);
            }
            backgroundWorkerForOCRROIAllImage.RunWorkerAsync(rOIProfile);
        }

        private void Cbb_RegionProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedItem == null)
            {
                _appConfig.SetConfig<ROIProfile>("CurrentRegionProfile", null);
            }
            else
            {
                ROIProfile config = _appConfig.GetConfig<ROIProfile>("CurrentRegionProfile");
                if (config == null || config.Name != cbb.SelectedItem.ToString().Trim())
                {
                    _appConfig.SetConfig<ROIProfile>("CurrentRegionProfile", _regionProfiles.GetRegionProfile(cbb.SelectedItem.ToString().Trim()));
                }
            }
        }

        private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            })
            {
                if (folder.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                backgroundWorkerForLoadImage.RunWorkerAsync(folder.SelectedPath);
            }
        }

        private void Btn_ActivePictureBox_Click(object sender, EventArgs e)
        {
            if (pictureBox_ScanImage.Enabled)
            {
                pictureBox_ScanImage.Enabled = false;
            }
            else
            {
                pictureBox_ScanImage.Enabled = true;
            }
        }

        private void PictureBox_ScanImage_EnabledChanged(object sender, EventArgs e)
        {
            if (pictureBox_ScanImage.Enabled)
            {
                btn_ActivePictureBox.Text = "Tắt cắt ảnh";
            }
            else
            {
                btn_ActivePictureBox.Text = "Kích hoạt cắt ảnh";
            }
        }

        private void ScanConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerVideoCapture.IsBusy)
            {
                backgroundWorkerVideoCapture.CancelAsync();
            }

            if (ScanDeviceSelectDialog.ShowCustomDialog(out string scannerid) != DialogResult.OK)
            {
                ScannerID = "";
                return;
            }
            ScannerID = scannerid;
        }

        private void Btn_Scan_Click(object sender, EventArgs e)
        {
            if (_pauseVideoCapture)
            {
                _pauseVideoCapture = false;
                btn_Scan.Text = "Scan/Capture";
                return;
            }
            _images.Clear();
            _imageSelectedRegion = null;
            _currentImageIndex = 0;
            if (_inputMode == InputMode.ScanMode)
            {
                backgroundWorkerForScan.RunWorkerAsync();
            }
            else if (_inputMode == InputMode.CamMode)
            {
                IDetectPaperArea detectPaper = DetectPaperArea.MakeInstance();
                _pauseVideoCapture = true;
                IImage paperArea = detectPaper.ExtractPaperArea(_resultCache.imgOriginal, _resultCache.rotated);
                if (paperArea == null)
                {
                    MessageBox.Show("Không tìm thấy.", "Không thể tìm thấy khu vực nhận dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pictureBox_ScanImage.Image = paperArea.Bitmap;
                _images.Add(new CImage(paperArea));
                btn_Scan.Text = "Tiếp tục";
                EnableCommonButton(true);
            }
        }

        private void ConnectVideoCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerVideoCapture.IsBusy)
            {
                backgroundWorkerVideoCapture.CancelAsync();
            }

            if (CameraDeviceSelectDialog.ShowCustomDialog(out int camIndex) != DialogResult.OK)
            {
                CamIndex = -1;
                return;
            }
            CamIndex = camIndex;
            backgroundWorkerVideoCapture.RunWorkerAsync(CamIndex);
        }

        private void Label2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e?.Button == MouseButtons.Right)
            {
                ActiveControl = null;
            }
        }

        /// <summary>
        /// Create hotkey
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (btn_Scan.Enabled && e?.KeyCode == Keys.C)
            {
                btn_Scan.PerformClick();
                if (_pauseVideoCapture)
                {
                    btn_ExtractBaseOnROIProfile.PerformClick();
                }
            }
            base.OnKeyDown(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _imageSelectedRegion?.Dispose();
        }
        #endregion
        #region function

        private void CheckbtnPrevandNext()
        {
            if (_currentImageIndex > 0)
            {
                btn_Prev.Enabled = true;
            }
            else
            {
                btn_Prev.Enabled = false;
            }
            if (_currentImageIndex < _images.Count - 1)
            {
                btn_Next.Enabled = true;
            }
            else
            {
                btn_Next.Enabled = false;
            }
            txt_BoxPage.Text = $"{_currentImageIndex + 1}/{_images.Count}";
        }

        private void EnableCommonButton(bool enable = true)
        {
            btn_Prev.Enabled = enable;
            btn_Next.Enabled = false;
            btn_ActivePictureBox.Enabled = enable;
            btn_RotateLeft.Enabled = enable;
            btn_RotateRight.Enabled = enable;
            btn_DeSelectedRegion.Enabled = enable;
            btn_ExtractText.Enabled = enable;
            btn_ExtractCurrentImageBaseOnRegionProfile.Enabled = enable;
            btn_ExtractBaseOnROIProfile.Enabled = enable;
        }

        private void ClearDataGridView()
        {
            dataGridView_Result.ClearSelection();
            dataGridView_Result.Columns.Clear();
            dataGridView_Result.Rows.Clear();
            dataGridView_Result.Tag = null;
        }

        private void ClearPoint()
        {
            _pointsForDrawRect.Clear();
            pictureBox_ScanImage.Refresh();
        }

        private void CreateDataGridView(ROIProfile regionProfile = null)
        {
            ClearDataGridView();
            dataGridView_Result.Columns.Add("number", "STT");
            dataGridView_Result.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            if (regionProfile == null)
            {
                dataGridView_Result.Tag = false;
                dataGridView_Result.Columns.Add("result", "Kết quả");
            }
            else
            {
                dataGridView_Result.Tag = regionProfile;
                foreach (ROI col in regionProfile.Regions)
                {
                    dataGridView_Result.Columns.Add(col.RegionName, col.RegionName);
                }
            }
        }

        private void FillDataGridViewRow(List<string> cells)
        {
            int numRows = dataGridView_Result.Rows.Count;
            cells.Insert(0, numRows.ToString());
            dataGridView_Result.Rows.Add(cells.ToArray());
        }

        private void AnimateOCR()
        {
            this.InvokeOnUIThreadASync(() =>
            {
                toolStripStatuslabel.Text = "OCR Processing...";
                toolStripProgressBar.Enabled = true;
                toolStripProgressBar.Visible = true;
                pictureBox_ScanImage.Enabled = false;
                EnableCommonButton(false);
            });
        }
        #endregion
        #region backroundworker

        private void BackgroundWorkerForLoadImage_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorkerVideoCapture.IsBusy)
            {
                backgroundWorkerVideoCapture.CancelAsync();
            }

            this.InvokeOnUIThreadASync(() =>
            {
                toolStripStatuslabel.Text = "Loading Image...";
                toolStripProgressBar.Enabled = true;
                toolStripProgressBar.Visible = true;
                openToolStripMenuItem1.Enabled = false;
                EnableCommonButton(false);
                toolStripStatusLabelImgSize.Text = "Nothing.";
            });
            if (e.Argument != null)
            {
                if (e.Argument is int index)
                {
                    if (index >= 0 && index < _images.Count)
                    {
                        if (_currentImageIndex != index)
                        {
                            _currentImageIndex = index;
                        }
                        this.InvokeOnUIThreadASync(() => pictureBox_ScanImage.Image = _images?[_currentImageIndex].GetOriginalImage().Bitmap);
                    }
                    return;
                }
                _images.Clear();
                string fileOrDir = e.Argument as string;
                if (fileOrDir.CheckIfIsFileAndExist())
                {
                    IEnumerable<CImage> imageImport = _importImage.ImportFromFile(fileOrDir);
                    if (imageImport.Count() > 0)
                    {
                        _images.AddRange(imageImport);
                    }
                    else
                    {
                        MessageBox.Show("Định dạng ảnh không được  hổ trợ.", "Lỗi không hổ trợ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (fileOrDir.CheckIfIsFolderAndExist())
                {
                    _images.AddRange(_importImage.ImportFromFolder(fileOrDir));
                }
                else
                {
                    return;
                }
                if (_images.Count == 0)
                {
                    return;
                }

                _currentImageIndex = 0;
                this.InvokeOnUIThreadASync(() => pictureBox_ScanImage.Image = _images?[_currentImageIndex].GetOriginalImage().Bitmap);
            }
        }

        private void BackgroundWorkerForLoadImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.InvokeOnUIThreadASync(() =>
            {
                toolStripProgressBar.Enabled = false;
                toolStripProgressBar.Visible = false;
                openToolStripMenuItem1.Enabled = true;
                EnableCommonButton(true);
                toolStripStatuslabel.Text = "Loading Success.";
                toolStripStatusLabelImgSize.Text = $"Image size: {_images[_currentImageIndex].GetOriginalImage().Size.Width}px*{_images[_currentImageIndex].GetOriginalImage().Size.Height}px*{_images[_currentImageIndex].GetOriginalImage().NumberOfChannels} channel";
                CheckbtnPrevandNext();
            });
        }

        private (IImage imgOriginal, IImage imgDrawed, RotatedRect rotated) _resultCache = (null, null, RotatedRect.Empty);
        private void BackgroundWorkerVideoCapture_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            if (e.Argument == null)
            {
                return;
            }

            if (!(e.Argument is int camIndex))
            {
                return;
            }
            IDetectPaperArea detectPaper = DetectPaperArea.MakeInstance();
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
                        if (m.IsEmpty)
                        {
                            break;
                        }
                        try
                        {
                            _resultCache = detectPaper.DetectAndDrawPaperArea(m, _resultCache.rotated);
                            this.InvokeOnUIThreadSync(() =>
                            {
                                pictureBox_ScanImage.Image = _resultCache.imgDrawed.Bitmap;
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

        private void BackgroundWorkerVideoCapture_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _pauseVideoCapture = false;
            btn_Scan.Text = "Scan/Capture";
            btn_Scan.Enabled = false;
            pictureBox_ScanImage.Image = null;
        }

        private void BackgroundWorkerForScanner_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(ScannerID))
            {
                return;
            }
            this.InvokeOnUIThreadASync(() =>
            {
                toolStripStatuslabel.Text = "Scan Processing...";
                toolStripProgressBar.Enabled = true;
                toolStripProgressBar.Visible = true;
                pictureBox_ScanImage.Enabled = false;
                EnableCommonButton(false);
            });
            ITempFilesResource<ImageFile> tempFiles = TempFilesScannerResource<ImageFile>.DefaultInstance();
            _images.Clear();
            // maybe not working
            _images.AddRange(WIAScannerControl.Scan(ScannerID, e).Select(f => new CImage(tempFiles.GetFullPath(f))));
            if (_images.Count > 0)
            {
                _currentImageIndex = 0;
                this.InvokeOnUIThreadASync(() => pictureBox_ScanImage.Image = _images?[_currentImageIndex].GetOriginalImage().Bitmap);
            }
        }

        private void BackgroundWorkerForScanner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.InvokeOnUIThreadASync(() =>
            {
                toolStripProgressBar.Enabled = false;
                toolStripProgressBar.Visible = false;
                EnableCommonButton(true);
                CheckbtnPrevandNext();
                toolStripStatuslabel.Text = "Scan Completed.";
                toolStripStatusLabelImgSize.Text = $"Image size: {_images[_currentImageIndex].GetOriginalImage().Size.Width}px*{_images[_currentImageIndex].GetOriginalImage().Size.Height}px*{_images[_currentImageIndex].GetOriginalImage().NumberOfChannels}channel";
            });
        }

        private void backgroundWorkerForOCRFullCharacterOrROI_DoWork(object sender, DoWorkEventArgs e)
        {
            AnimateOCR();
            if (!(e.Argument is string lang))
            {
                return;
            }
            BackgroundWorker bw = sender as BackgroundWorker;
            IOCR oCR = OCRWraper.Instance(lang);
            List<string> pages = new List<string>();
            if (_imageSelectedRegion != null)
            {
                pages.Add(oCR.GetUtf8Text(_imageSelectedRegion));
            }
            else
            {
                foreach (CImage image in _images)
                {
                    if (bw.CancellationPending)
                    {
                        break;
                    }
                    this.InvokeOnUIThreadASync(() =>
                    {
                        pictureBox_ScanImage.Image = image.GetOriginalImage().Bitmap;
                    });
                    pages.Add(oCR.GetUtf8Text(image));
                    image.Release();
                }
            }
            this.InvokeOnUIThreadASync(() =>
            {
                foreach (List<string> page in pages.Select(p => new List<string> { p }))
                {
                    FillDataGridViewRow(page);
                }
            });
        }

        private void BackgroundWorkerForOCRROISingleImage_DoWork(object sender, DoWorkEventArgs e)
        {
            AnimateOCR();
            if (!(e.Argument is ROIProfile roiProfile))
            {
                return;
            }

            BackgroundWorker bw = sender as BackgroundWorker;
            IOCRROI oCR = OCRWraper.DefaultInstance();
            CImage image = _images[_currentImageIndex];
            this.InvokeOnUIThreadASync(() =>
            {
                pictureBox_ScanImage.Image = image.GetOriginalImage().Bitmap;
            });
            List<Dictionary<string, string>> res = oCR.GetUtf8TextBaseOnRegions(image, roiProfile, out IImage imgdrawd);
            if (bw.CancellationPending)
            {
                return;
            }
            this.InvokeOnUIThreadASync(() =>
            {
                pictureBox_ScanImage.Image = imgdrawd.Bitmap;
            });
            this.InvokeOnUIThreadASync(() =>
            {
                foreach (Dictionary<string, string> row in res)
                {
                    IEnumerable<string> tmp = row.Select(cell => cell.Value);
                    if (tmp.Any(s => string.IsNullOrWhiteSpace(s)))
                    {
                        continue;
                    }
                    FillDataGridViewRow(tmp.ToList());
                }
            });
        }

        private void BackgroundWorkerForOCRROIAllImage_DoWork(object sender, DoWorkEventArgs e)
        {
            AnimateOCR();
            if (!(e.Argument is ROIProfile roiProfile))
            {
                return;
            }

            BackgroundWorker bw = sender as BackgroundWorker;
            IOCRROI oCR = OCRWraper.DefaultInstance();
            List<Dictionary<string, string>> pages = new List<Dictionary<string, string>>();
            foreach (CImage image in _images)
            {
                if (bw.CancellationPending)
                {
                    break;
                }
                this.InvokeOnUIThreadASync(() =>
                {
                    pictureBox_ScanImage.Image = image.GetOriginalImage().Bitmap;
                });
                List<Dictionary<string, string>> res = oCR.GetUtf8TextBaseOnRegions(image, roiProfile, out IImage imgdrawd);
                pages.AddRange(res);
                this.InvokeOnUIThreadASync(() =>
                {
                    pictureBox_ScanImage.Image = imgdrawd.Bitmap;
                });
                this.InvokeOnUIThreadASync(() =>
                {
                    foreach (Dictionary<string, string> row in res)
                    {
                        IEnumerable<string> tmp = row.Select(cell => cell.Value);
                        if (tmp.Any(s => string.IsNullOrWhiteSpace(s)))
                        {
                            continue;
                        }
                        FillDataGridViewRow(tmp.ToList());
                    }
                });
                image.Release();
            }
            this.InvokeOnUIThreadASync(() =>
            {
                pictureBox_ScanImage.Image = _images[_currentImageIndex].GetOriginalImage().Bitmap;
            });
        }

        private void backgroundWorkerForOCR_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.InvokeOnUIThreadASync(() =>
            {
                toolStripProgressBar.Enabled = false;
                toolStripProgressBar.Visible = false;
                EnableCommonButton(true);
                CheckbtnPrevandNext();
                toolStripStatuslabel.Text = "OCR Completed.";
            });
        }

        #endregion

        #endregion

        private void Btn_Scan_EnabledChanged(object sender, EventArgs e)
        {
            if ((sender as Button).Enabled)
            {
                ActiveControl = (sender as Button);
            }
        }
    }
}
