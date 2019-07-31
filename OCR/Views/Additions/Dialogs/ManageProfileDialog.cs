using System;
using System.Windows.Forms;
using Emgu.CV;
using OCR.DAO.Interfaces;
using OCR.DAO.Locals;
using OCR.Models.Locals;
using OCR.Utils.Extensions.UIs;

namespace OCR.Views.Additions.Dialogs
{
    public partial class ManageProfileDialog : Form
    {
        #region static
        public static DialogResult ShowCustomDialog()
        {
            ManageProfileDialog dialog = new ManageProfileDialog();
            return dialog.ShowDialog();
        }
        #endregion
        #region instance
        #region dependencyinjection
        private readonly IROIProfilesResource _regionProfiles = ROIProfilesResource.DefaultInstance();
        private readonly ITempFilesResource<IImage> _tempFiles = TempFilesImageResource<IImage>.DefaultInstance();
        #endregion
        private ROIProfile _selectedRegionProfile = null;

        private ManageProfileDialog()
        {
            InitializeComponent();
        }

        private void ManageProfileDialog_Load(object sender, EventArgs e)
        {
            lst_Profiles.UpdateUI(_regionProfiles.Profiles);
        }

        private void RestoreDefaultFormState()
        {
            _selectedRegionProfile = null;
            txt_PaperName.Text = "";
            txt_PaperName.Enabled = false;
            txt_ProfileName.Text = "";
            txt_ProfileName.Enabled = false;
            txt_SampleImagePath.Text = "";
            txt_SampleImagePath.Enabled = false;
            btn_Delete.Enabled = false;
            btn_Update.Enabled = false;
            lst_Regions.Enabled = false;
            lst_Regions.UpdateUI();
        }

        private void Lst_Profiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lst = sender as ListBox;
            if (lst.SelectedItem != null)
            {
                _selectedRegionProfile = _regionProfiles.GetRegionProfile(lst.SelectedItem.ToString());
                if (_selectedRegionProfile != null)
                {
                    txt_ProfileName.Text = _selectedRegionProfile.Name;
                    txt_ProfileName.Enabled = true;
                    txt_PaperName.Text = _selectedRegionProfile.PaperSize;
                    txt_SampleImagePath.Text = _selectedRegionProfile.TemplateFile;
                    btn_Delete.Enabled = true;
                    lst_Regions.Enabled = true;
                    lst_Regions.UpdateUI(_selectedRegionProfile.Regions);
                }
                else
                {
                    MessageBox.Show("Không thể tải lên cấu hình này.", "Lỗi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lst_Profiles.UpdateUI(_regionProfiles.Profiles);
                    RestoreDefaultFormState();
                }
            }
            else
            {
                RestoreDefaultFormState();
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (_selectedRegionProfile == null)
            {
                return;
            }

            if (MessageBox.Show("Có chắc là xoá cấu hình này.", "Xác nhận.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }
            _tempFiles.DeleteFile(_selectedRegionProfile.TemplateFile);
            _regionProfiles.DeleteRegionProfile(_selectedRegionProfile);
            lst_Profiles.UpdateUI(_regionProfiles.Profiles);
            RestoreDefaultFormState();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (_selectedRegionProfile == null)
            {
                return;
            }

            if (MessageBox.Show("Bạn có muốn cập nhật cấu hình này.", "Xác nhận.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
            {
                return;
            }
            _selectedRegionProfile.Name = txt_ProfileName.Text.Trim();
            _regionProfiles.AddOrUpdateRegionProfile(_selectedRegionProfile);
            lst_Profiles.UpdateUI(_regionProfiles.Profiles, _selectedRegionProfile.Name);
        }

        private void Txt_ProfileName_TextChanged(object sender, EventArgs e)
        {
            if (_selectedRegionProfile == null)
            {
                return;
            }

            TextBox txt = sender as TextBox;
            if (txt.Text != _selectedRegionProfile.Name)
            {
                btn_Update.Enabled = true;
            }
            else
            {
                btn_Update.Enabled = false;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion
    }
}
