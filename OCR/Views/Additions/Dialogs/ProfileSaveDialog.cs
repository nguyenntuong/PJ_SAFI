using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCR.Models.Locals;
using OCR.DAO.Interfaces;
using OCR.DAO.Locals;
using OCR.Utils.Extensions.UIs;

namespace OCR.Views.Additions.Dialogs
{
    public partial class ProfileSaveDialog : Form
    {
        #region static
        public static DialogResult ShowCustomDialog(ROIProfile profile)
        {
            ProfileSaveDialog dialog = new ProfileSaveDialog(profile);
            return dialog.ShowDialog();
        }
        #endregion

        #region instance
        #region dependencyinjection
        private readonly IROIProfilesResource _roiProfiles = ROIProfilesResource.DefaultInstance();
        private readonly IPaperResource _paperProfiles = PaperResource.DefaultInstance();
        #endregion
        private ROIProfile _regionProfile;

        private ProfileSaveDialog(ROIProfile profile)
        {
            InitializeComponent();
            _regionProfile = profile;
        }

        private void ProfileSaveDialog_Load(object sender, EventArgs e)
        {
            cbb_PaperSize.UpdateUI(_paperProfiles.Profiles, _regionProfile.PaperSize);
            txt_ProfileName.Text = _regionProfile.Name;
            lstRegion.UpdateUI(_regionProfile.Regions);
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            if (cbb_PaperSize.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn kích thước khổ giấy.", "Thiếu thông tin.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_ProfileName.Text))
            {
                MessageBox.Show("Vui lòng đặt tên cho profile này.", "Thiếu thông tin.");
                return;
            }
            if (_roiProfiles.Profiles.Contains(txt_ProfileName.Text))
            {
                if (MessageBox.Show("Profile này đã tồn tại, muốn ghi đè?.", "Trùng lập.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }
            }
            _regionProfile.Name = txt_ProfileName.Text.Trim();
            _regionProfile.PaperSize = cbb_PaperSize.SelectedItem.ToString().Trim();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion
    }
}
