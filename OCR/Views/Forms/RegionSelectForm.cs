using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
using OCR.Views.Additions.Dialogs;
using OCR.Views.Forms.ForTest;

namespace OCR.Views.Forms
{
    public partial class RegionSelectForm : Form
    {
        #region instance
        #region dependencyinjection
        private readonly IROIProfilesResource _roiProfiles = ROIProfilesResource.DefaultInstance();
        private readonly IPaperResource _paperProfiles = PaperResource.DefaultInstance();
        private readonly IAppConfig _appConfig = AppConfig.DefaultInstance();
        private readonly ITesseractLanguages _tesseractLang = TesseractLanguages.DefaultInstance();
        private readonly ITempFilesResource<IImage> _tempFiles = TempFilesImageResource<IImage>.DefaultInstance();
        private readonly IImportImage _importImage = ImportImage.Instance(DetectPaperArea.MakeInstance());
        #endregion
        /// <summary>
        /// Danh sách vùng đang được chọn
        /// </summary>
        private List<ROI> _regions = new List<ROI>();
        /// <summary>
        /// Ảnh mẫu đang hiển thị
        /// </summary>
        private CImage _image = null;

        /// <summary>
        /// Chứa tạm Cấu hình trước khi lưu và áp dụng
        /// </summary>
        private ROIProfile _currentRegionProfile = null;
        private ROIProfile CurrentRegionProfile
        {
            get => _currentRegionProfile;
            set
            {
                if (value == null)
                {
                    _regionNumber = 0;
                    _regions.Clear();
                }
                else
                {
                    _regionNumber = value.Regions.Count;
                }
                _currentRegionProfile = value;
            }
        }
        /// <summary>
        /// Đếm số vùng được chọn, dùng cho mục đích đặt tên nhanh
        /// </summary>
        private int _regionNumber = 0;

        /// <summary>
        /// Kiểm soát hành vi chuột người dùng
        /// </summary>
        private bool _isMouseButtonRelease = true;
        /// <summary>
        /// Dùng để vẽ vùng chọn khi rê chuột
        /// </summary>
        private List<Point> _pointsForDrawRect = new List<Point>(2);

        public RegionSelectForm()
        {
            InitializeComponent();
        }
        #region delegateevent
        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            pictureBox_ImgSample.Enabled = false;
            CustomDialogResult res = SelectFromDialog.ShowCustomDialog();
            switch (res)
            {
                case CustomDialogResult.LocalFile:
                    using (OpenFileDialog openFile = new OpenFileDialog())
                    {
                        if (openFile.ShowDialog() != DialogResult.OK)
                        {
                            return;
                        }

                        backgroundWorkerLoadImage.RunWorkerAsync(openFile.FileName);
                    }
                    break;
                case CustomDialogResult.VideoCapture:
                    if (SelectImageFromCameraDialog.ShowCustomDialog(out IImage img) == DialogResult.OK)
                    {
                        backgroundWorkerLoadImage.RunWorkerAsync(img);
                    }
                    break;
                case CustomDialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            ClearCancelPoint();
            DrawRectangles(ROI.Empty, true);
            if (e.Button == MouseButtons.Left)
            {
                _isMouseButtonRelease = false;
                _pointsForDrawRect.Add(e.Location);
            }
        }

        private void PicBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _pointsForDrawRect.Add(e.Location);
                if (_pointsForDrawRect.Count == 2)
                {
                    using (VectorOfPoint vector = new VectorOfPoint(_pointsForDrawRect.ToArray()))
                    {
                        Rectangle rect = CvInvoke.BoundingRectangle(vector);
                        if (rect.Width > ROI.MINIMUNSIZE && rect.Height > ROI.MINIMUNSIZE)
                        {
                            using (Graphics g = pictureBox_ImgSample.CreateGraphics())
                            {
                                using (Pen p = new Pen(Brushes.Red))
                                {
                                    g.DrawRectangle(p, rect);
                                }
                            }
                            ROI regionSelected = new ROI(
                                $"Region_{_regionNumber++}"
                                , _tesseractLang.DefaultLanguage
                                , rect
                                , ""
                                , "");
                            if (AddRegionDialog.ShowCustomDialog(_regions, regionSelected) == DialogResult.OK)
                            {
                                _regions.Add(regionSelected);
                                lstBoxRectangles.UpdateUI(_regions);
                            }
                        }
                    }
                }
                DrawRectangles();
            }
            ClearCancelPoint();
            _isMouseButtonRelease = true;
        }

        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isMouseButtonRelease)
            {
                using (VectorOfPoint vector = new VectorOfPoint(new[] { _pointsForDrawRect[0], e.Location }))
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(vector);
                    using (Graphics g = pictureBox_ImgSample.CreateGraphics())
                    {
                        pictureBox_ImgSample.Refresh();
                        using (Pen p = new Pen(Brushes.Red))
                        {
                            g.DrawRectangle(p, rect);
                        }
                    }
                }
                DrawRectangles(ROI.Empty, false);
            }
        }

        // Vxex lại các vùng chọn khi kích thước bị thay đổi
        private void PicBox_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void LstBoxRectangles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox list = sender as ListBox;
            if (list.SelectedItem == null)
            {
                return;
            }

            if (_image == null)
            {
                return;
            }

            ROI r = (ROI)list.SelectedItem;
            DrawRectangles(r);
        }

        private void RegionSelectForm_Load(object sender, EventArgs e)
        {
            cbb_PaperSize.UpdateUI(_paperProfiles.Profiles);
            cbb_RegionProfile.UpdateUI(_roiProfiles.Profiles);
            if (cbb_RegionProfile.Items.Count > 0)
            {
                cbb_RegionProfile.SelectedIndex = 0;
                CurrentRegionProfile = _roiProfiles.GetRegionProfile(cbb_RegionProfile.SelectedItem.ToString());
            }
            if (cbb_PaperSize.Items.Count > 0)
            {
                if (CurrentRegionProfile != null)
                {
                    cbb_PaperSize.SelectedItem = CurrentRegionProfile.PaperSize;
                }
                else
                {
                    cbb_PaperSize.SelectedIndex = 0;
                }
            }
            toolStrip_btnDeleteRect.Click += ToolStrip_btnDeleteRect_Click;
            toolStrip_btnChangeRegionName.Click += ToolStrip_btnChangeRegionName_Click;
        }

        private void ToolStrip_btnChangeRegionName_Click(object sender, EventArgs e)
        {
            if (lstBoxRectangles.SelectedItem == null)
            {
                return;
            }

            if (AddRegionDialog.ShowCustomDialog(_regions, (ROI)lstBoxRectangles.SelectedItem) == DialogResult.OK)
            {
                lstBoxRectangles.UpdateUI(_regions, lstBoxRectangles.SelectedItem);
            }
        }

        private void ToolStrip_btnDeleteRect_Click(object sender, EventArgs e)
        {
            ListBox list = lstBoxRectangles;
            if (list.SelectedItem == null)
            {
                return;
            }

            ROI r = (ROI)list.SelectedItem;
            _regions.Remove(r);
            list.UpdateUI(_regions);
            DrawRectangles();
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (_image == null)
            {
                MessageBox.Show("Vui lòng chọn một ảnh để có thể xem trước cấu hình.", "Thông báo.");
                return;
            }
            if (_regions.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn gì cả, hãy chọn các vùng trên ảnh, bằng cách kéo chuốt trên ảnh.", "Thông báo.");
                return;
            }
            using (ShowImageForm testForm = new ShowImageForm(
                _image.GetOriginalImage(),
                _regions.Select(r => new ROI(
                    r.RegionName
                 , r.Language
                 , r.RegionRectangle.ConvertToActualyImageSizeWithAcc(pictureBox_ImgSample)
                 , r.RegexPattern
                 , r.RegexPatternSpecialChar)
            ).ToList()))
            {
                testForm.ShowDialog();
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (CurrentRegionProfile == null || cbb_RegionProfile.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một cấu hình cụ thể, hoặc chọn lưu mới để lưu cấu hình hiện tại.", "Thông báo.");
                return;
            }
            if (!_paperProfiles.Profiles.Contains(_currentRegionProfile.PaperSize))
            {
                MessageBox.Show("Không tìm thấy thông tin loại giấy, vui lòng chọn tạo mới để tạo loại giấy dựa trên ảnh mẫu.", "Thiếu thông tin.");
                return;
            }
            if (_regions.Count == 0 && _currentRegionProfile.Regions.Count > 0)
            {
                CurrentRegionProfile.Regions = _currentRegionProfile.Regions;
            }
            else
            {
                CurrentRegionProfile.Regions = _regions.Select(r => new ROI(r.RegionName
                    , r.Language
                    , r.RegionRectangle.ConvertToActualyImageSizeWithAcc(pictureBox_ImgSample)
                    , r.RegexPattern
                    , r.RegexPatternSpecialChar)
                ).ToList();
                _roiProfiles.AddOrUpdateRegionProfile(CurrentRegionProfile);
            }
            _appConfig.SetConfig<ROIProfile>("CurrentRegionProfile", CurrentRegionProfile);
            Close();
        }

        private void Btn_SaveAs_Click(object sender, EventArgs e)
        {
            ROIProfile tempProfile = RegionProfileValidateBeforeSave();
            if (tempProfile == null)
            {
                return;
            }

            if (ProfileSaveDialog.ShowCustomDialog(tempProfile) == DialogResult.OK)
            {
                _roiProfiles.AddOrUpdateRegionProfile(tempProfile);
                cbb_PaperSize.UpdateUI(_paperProfiles.Profiles);
                cbb_RegionProfile.UpdateUI(_roiProfiles.Profiles);
                if (cbb_RegionProfile.Items.Count > 0)
                {
                    CurrentRegionProfile = tempProfile;
                    cbb_RegionProfile.SelectedItem = CurrentRegionProfile.Name;
                }
                if (cbb_PaperSize.Items.Count > 0)
                {
                    if (CurrentRegionProfile != null)
                    {
                        cbb_PaperSize.SelectedItem = CurrentRegionProfile.PaperSize;
                        _regions = CurrentRegionProfile.Regions
                                                        .Select(r => new ROI(r.RegionName
                                                        , r.Language
                                                        , r.RegionRectangle.ConvertActualyImageSizeToPictureClientSize(pictureBox_ImgSample)
                                                        , r.RegexPattern
                                                        , r.RegexPatternSpecialChar)
                                                        ).ToList();
                    }
                    else
                    {
                        cbb_PaperSize.SelectedIndex = 0;
                    }
                }
                lstBoxRectangles.UpdateUI(_regions);
                MessageBox.Show("Đã lưu lại thành công.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cbb_Profile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedItem != null)
            {
                CurrentRegionProfile = _roiProfiles.GetRegionProfile(cbb.SelectedItem.ToString());
                if (CurrentRegionProfile == null)
                {
                    cbb.UpdateUI(_roiProfiles.Profiles);
                    btn_Apply.Enabled = false;
                    btn_Preview.Enabled = false;
                    btn_Save.Enabled = false;
                    return;
                }
                btn_Apply.Enabled = true;
                btn_Preview.Enabled = true;
                btn_Save.Enabled = true;
                ValidateProfileWithSampleImage(true);
            }
            else
            {
                CurrentRegionProfile = null;
                cbb.UpdateUI(_roiProfiles.Profiles);
                cbb_RegionProfile.UpdateUI();
                pictureBox_ImgSample.Refresh();
                btn_Apply.Enabled = false;
                btn_Preview.Enabled = false;
                btn_Save.Enabled = false;
            }
        }

        private void ToolStrip_btnClearAll_Click(object sender, EventArgs e)
        {
            btn_Save.Enabled = false;
            ListBox lst = lstBoxRectangles;
            CurrentRegionProfile = null;
            _regions.Clear();
            lst.UpdateUI(_regions);
            DrawRectangles();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            ROIProfile tempProfile = RegionProfileValidateBeforeSave();
            if (tempProfile == null)
            {
                return;
            }

            if (cbb_RegionProfile.SelectedItem == null)
            {
                MessageBox.Show("Không xác định được Profile hiện tại, chọn lại.", "Lỗi không xác định", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tempProfile.Name = cbb_RegionProfile.SelectedItem.ToString().Trim();
            _roiProfiles.AddOrUpdateRegionProfile(tempProfile);
            MessageBox.Show("Cập nhật thành công.", "Cập nhật.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_ManageProfile_Click(object sender, EventArgs e)
        {
            ManageProfileDialog.ShowCustomDialog();
            List<string> lstProfile = _roiProfiles.Profiles;
            cbb_RegionProfile.UpdateUI(lstProfile, lstProfile.FirstOrDefault());
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _image?.Dispose();
        }
        #endregion
        #region funtion

        /// <summary>
        /// Kiểm tra cấu hình có hợp lệ hay chưa trước khi lưu hoặc áp dụng
        /// </summary>
        /// <returns></returns>
        private ROIProfile RegionProfileValidateBeforeSave()
        {
            if (_image == null)
            {
                MessageBox.Show("Không có hình mẫu nào được chọn.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            if (_regions.Count == 0)
            {
                MessageBox.Show("Không có vùng nào được chọn.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            PaperProfile paper = null;
            if (cbb_PaperSize.SelectedItem == null)
            {
                if (MessageBox.Show("Chưa chọn khổ giấy, muốn tạo mới dựa trên ảnh mẩu.", "Thông báo.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return null;
                }
                paper = new PaperProfile(_currentRegionProfile?.PaperSize, _image.GetOriginalImage().Size.Width, _image.GetOriginalImage().Size.Height);
                if (PaperProfileDialog.ShowCustomDialog(paper) != DialogResult.OK)
                {
                    return null;
                }
                cbb_PaperSize.UpdateUI(_paperProfiles.Profiles, paper?.Name);
            }
            paper = _paperProfiles.GetPaperProfile(cbb_PaperSize.SelectedItem.ToString().Trim());
            if (paper == null)
            {
                cbb_PaperSize.UpdateUI(_paperProfiles.Profiles);
                return null;
            }
            if (paper.Width != _image.GetOriginalImage().Size.Width && paper.Height != _image.GetOriginalImage().Size.Height)
            {
                if (MessageBox.Show("Kích thức khổ giấy không khớp với ảnh mẫu, muốn tạo mới khổ giấy?", "Xung đột", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                {
                    return null;
                }
                paper = new PaperProfile("", _image.GetOriginalImage().Size.Width, _image.GetOriginalImage().Size.Height);
                if (PaperProfileDialog.ShowCustomDialog(paper) != DialogResult.OK)
                {
                    return null;
                }
            }
            ROIProfile tempProfile = new ROIProfile
            {
                TemplateFile = _tempFiles.SaveFile(_image.GetOriginalImage()),
                Name = "",
                PaperSize = paper.Name,
                Regions = _regions.Select(r => new ROI(r.RegionName
                , r.Language
                , r.RegionRectangle.ConvertToActualyImageSizeWithAcc(pictureBox_ImgSample)
                , r.RegexPattern
                , r.RegexPatternSpecialChar)
                ).ToList(),
            };
            return tempProfile;
        }

        private void ClearCancelPoint()
        {
            _pointsForDrawRect.Clear();
        }

        //TODO fix lỗi khi người dùng thay đổi kích thức cửa sổ dẫn đến vẽ sai
        private void DrawRectangles(ROI activeegion = null, bool needRefresh = true)
        {
            if (needRefresh)
            {
                pictureBox_ImgSample.Refresh();
            }
            if (_regions.Count == 0)
            {
                return;
            }

            using (Graphics g = pictureBox_ImgSample.CreateGraphics())
            {
                using (Pen p = new Pen(Brushes.Aqua))
                {
                    Rectangle[] rectArray = _regions.Where(r => !r.Equals(activeegion)).Select(r => r.RegionRectangle).ToArray();
                    if (rectArray.Length > 0)
                    {
                        g.DrawRectangles(p, rectArray);
                    }
                }
                if (activeegion != null)
                {
                    using (Pen p = new Pen(Brushes.Red))
                    {
                        g.DrawRectangle(p, activeegion.RegionRectangle);
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra xem ảnh mẩu và cấu hình hiện tại có khớp với nhau không
        /// </summary>
        private void ValidateProfileWithSampleImage(bool fromCbb = false)
        {
            if (CurrentRegionProfile == null && cbb_RegionProfile.SelectedItem != null)
            {
                CurrentRegionProfile = _roiProfiles.GetRegionProfile(cbb_RegionProfile.SelectedItem.ToString());
            }
            if (CurrentRegionProfile != null)
            {
                PaperProfile paperSize = _paperProfiles.GetPaperProfile(CurrentRegionProfile.PaperSize);
                if (paperSize == null)
                {
                    MessageBox.Show("Định nghĩa kích thước ảnh cho cấu hình này không tồn tại.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CurrentRegionProfile = null;
                    cbb_PaperSize.SelectedItem = null;
                }
                else
                {
                    if (fromCbb && !string.IsNullOrEmpty(CurrentRegionProfile.TemplateFile))
                    {
                        string fullPath = _tempFiles.GetFullPath(CurrentRegionProfile.TemplateFile);
                        if (fullPath.CheckIfIsFileAndExist())
                        {
                            _image = new CImage(fullPath);
                            pictureBox_ImgSample.Image = _image.GetOriginalImage().Bitmap;
                        }
                    }
                    if (_image != null)
                    {
                        if (paperSize.Height != _image.GetOriginalImage().Size.Height && paperSize.Width != _image.GetOriginalImage().Size.Width)
                        {
                            MessageBox.Show("Kích thước ảnh không phù hợp với cấu hình hiện tại, hãy tạo mới hoặc chọn lại cấu hình phù hợp.", "Thông báo.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CurrentRegionProfile = null;
                        }
                        else
                        {
                            _regions = CurrentRegionProfile
                                    .Regions
                                    .Select(r => new ROI(r.RegionName
                                    , r.Language
                                    , r.RegionRectangle.ConvertActualyImageSizeToPictureClientSize(pictureBox_ImgSample)
                                    , r.RegexPattern
                                    , r.RegexPatternSpecialChar)
                                    ).ToList();
                        }
                    }
                    cbb_PaperSize.SelectedItem = CurrentRegionProfile?.PaperSize;
                    btn_Save.Enabled = true;
                    lstBoxRectangles.UpdateUI(_regions);
                    DrawRectangles();
                }
            }
        }

        #endregion
        #region backgroundworker

        private void BackgroundWorkerLoadImage_DoWork(object sender, DoWorkEventArgs e)
        {
            this.InvokeOnUIThreadASync(() =>
            {
                toolStripStatuslabel.Text = "Loading Image...";
                toolStripProgressBar.Enabled = true;
                toolStripProgressBar.Visible = true;
                toolStripStatusLabelImgSize.Text = "Nothings";
            });
            switch (e.Argument)
            {
                case null:
                default:
                    this.InvokeOnUIThreadASync(() => MessageBox.Show("Lỗi không xác định.", "Không thể mở file."));
                    break;
                case string fileName:
                    try
                    {
                        IEnumerable<CImage> images = _importImage.ImportFromFile(fileName);
                        if (images.Count() > 0)
                        {
                            _image = images.First();
                        }
                        else
                        {
                            MessageBox.Show("File không hổ trợ.", "Lỗi hổ trợ.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        this.InvokeOnUIThreadASync(() => pictureBox_ImgSample.Image = _image.GetOriginalImage().Bitmap);
                    }
                    catch (CvException ex)
                    {
                        Debug.WriteLine(ex.Message);
                        this.InvokeOnUIThreadASync(() => MessageBox.Show("Định dạng file không hổ trợ!.", "Không thể mở file."));
                    }
                    break;
                case Image<Bgr, byte> img:
                    _image = new CImage(img);
                    this.InvokeOnUIThreadASync(() => pictureBox_ImgSample.Image = _image.GetOriginalImage().Bitmap);
                    break;
            }
        }

        private void BackgroundWorkerLoadImage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.InvokeOnUIThreadASync(() =>
            {
                pictureBox_ImgSample.Enabled = true;
                toolStripProgressBar.Enabled = false;
                toolStripProgressBar.Visible = false;
                toolStripStatuslabel.Text = "Loading Success.";
                toolStripStatusLabelImgSize.Text = $"Image size: {_image.GetOriginalImage().Size.Width}px*{_image.GetOriginalImage().Size.Height}px*{_image.GetOriginalImage().NumberOfChannels} channel";
                ValidateProfileWithSampleImage();
            });
        }

        #endregion
        #endregion
    }
}
