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
using OCR.Utils.Extensions.UIs;
using OCR.DAO.Interfaces;
using OCR.DAO.Locals;

namespace OCR.Views.Additions.Dialogs
{
    public partial class PaperProfileDialog : Form
    {
        #region static
        public static DialogResult ShowCustomDialog()
        {
            PaperProfileDialog dialog = new PaperProfileDialog();
            return dialog.ShowDialog();
        }

        public static DialogResult ShowCustomDialog(PaperProfile paperProfile)
        {
            PaperProfileDialog dialog = new PaperProfileDialog(paperProfile);
            return dialog.ShowDialog();
        }
        #endregion
        #region instance
        #region dependencyinjection
        private readonly IPaperResource _paperResource = PaperResource.DefaultInstance();
        #endregion
        /// <summary>
        /// Đang ở chế độ chỉnh sửa hoặc tạo mới, để điều khiển hành vi btn xác nhận
        /// </summary>
        private bool _editMode = false;
        /// <summary>
        /// Dialog đang ở trạng thái nhiệm vụ là chỉ tạo mới
        /// </summary>
        private bool _createCommand = false;
        private PaperProfile _selectedPaperProfile = null;

        private PaperProfileDialog()
        {
            InitializeComponent();
        }

        private PaperProfileDialog(PaperProfile paperProfile)
        {
            InitializeComponent();
            _selectedPaperProfile = paperProfile;
            _createCommand = true;
        }

        private void PaperProfileDialog_Load(object sender, EventArgs e)
        {
            if (_createCommand)
            {
                cbb_PaperProfile.Enabled = false;
                btn_Edit.Enabled = false;
                btn_Delete.Enabled = false;
                btn_Cancel.Enabled = false;
                btn_CreateNew.Enabled = false;
                _editMode = false;
                txt_ProfileName.Text = _selectedPaperProfile.Name;
                txt_ProfileWidth.Text = _selectedPaperProfile.Width.ToString();
                txt_ProfileHeight.Text = _selectedPaperProfile.Height.ToString();
                txt_ProfileName.Enabled = true;
                txt_ProfileWidth.Enabled = true;
                txt_ProfileHeight.Enabled = true;
            }
            else
            {
                cbb_PaperProfile.UpdateUI(_paperResource.Profiles);
            }
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            if (_selectedPaperProfile == null)
            {
                MessageBox.Show("Tệp profile không thể đọc hoặc không tồn tại, vui lòng tạo mới hoặc kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _editMode = true;
            txt_ProfileName.Text = _selectedPaperProfile.Name;
            txt_ProfileWidth.Text = _selectedPaperProfile.Width.ToString();
            txt_ProfileHeight.Text = _selectedPaperProfile.Height.ToString();
            txt_ProfileName.Enabled = true;
            txt_ProfileWidth.Enabled = true;
            txt_ProfileHeight.Enabled = true;
        }

        private void Btn_CreateNew_Click(object sender, EventArgs e)
        {
            _editMode = false;
            txt_ProfileName.Text = "";
            txt_ProfileWidth.Text = "";
            txt_ProfileHeight.Text = "";
            txt_ProfileName.Enabled = true;
            txt_ProfileWidth.Enabled = true;
            txt_ProfileHeight.Enabled = true;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            if (_selectedPaperProfile != null)
            {
                _editMode = false;
                btn_Edit.Enabled = true;
                btn_Delete.Enabled = true;
                txt_ProfileName.Text = _selectedPaperProfile.Name;
                txt_ProfileWidth.Text = _selectedPaperProfile.Width.ToString();
                txt_ProfileHeight.Text = _selectedPaperProfile.Height.ToString();
                txt_ProfileName.Enabled = false;
                txt_ProfileWidth.Enabled = false;
                txt_ProfileHeight.Enabled = false;
            }
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            string nameProfile = txt_ProfileName.Text.Trim();
            int width, height;
            if (string.IsNullOrWhiteSpace(nameProfile))
            {
                MessageBox.Show("Vui lòng không để trống tên profile.", "Thiếu thông tin.");
                return;
            }
            if (!int.TryParse(txt_ProfileWidth.Text.Trim(), out width))
            {
                MessageBox.Show("Vui lòng chỉ nhập số khi khai báo kích thước giấy.", "Thiếu thông tin.");
                return;
            }
            if (!int.TryParse(txt_ProfileHeight.Text.Trim(), out height))
            {
                MessageBox.Show("Vui lòng chỉ nhập số khi khai báo kích thước giấy.", "Thiếu thông tin.");
                return;
            }
            if (cbb_PaperProfile.Items.Contains(nameProfile))
            {
                if (!_editMode)
                {
                    if (MessageBox.Show("Profile này đã có trước, bạn muốn ghi đè lên?", "Trùng lập.", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return;
                    }
                }
            }
            if (_selectedPaperProfile == null)
                _selectedPaperProfile = new PaperProfile("", 0, 0);
            _selectedPaperProfile.Name = nameProfile;
            _selectedPaperProfile.Width = width;
            _selectedPaperProfile.Height = height;
            _paperResource.AddOrUpdatePaperProfile(_selectedPaperProfile);
            MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_createCommand)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                cbb_PaperProfile.UpdateUI(_paperResource.Profiles, nameProfile);
            }
        }

        private void Cbb_PaperProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbb = sender as ComboBox;
            if (cbb.SelectedItem != null)
            {
                _selectedPaperProfile = _paperResource.GetPaperProfile(cbb_PaperProfile.SelectedItem.ToString());
                if (_selectedPaperProfile != null)
                {
                    btn_Edit.Enabled = true;
                    btn_Delete.Enabled = true;
                    txt_ProfileName.Text = _selectedPaperProfile.Name;
                    txt_ProfileWidth.Text = _selectedPaperProfile.Width.ToString();
                    txt_ProfileHeight.Text = _selectedPaperProfile.Height.ToString();
                }
                else
                {
                    btn_Edit.Enabled = false;
                    btn_Delete.Enabled = false;
                    txt_ProfileName.Text = "";
                    txt_ProfileWidth.Text = "";
                    txt_ProfileHeight.Text = "";
                }
            }
            else
            {
                btn_Edit.Enabled = false;
                btn_Delete.Enabled = false;
                txt_ProfileName.Text = "";
                txt_ProfileWidth.Text = "";
                txt_ProfileHeight.Text = "";
            }
            txt_ProfileName.Enabled = false;
            txt_ProfileWidth.Enabled = false;
            txt_ProfileHeight.Enabled = false;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            if (_createCommand)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (_selectedPaperProfile == null)
            {
                return;
            }
            _paperResource.DeletePaperProfile(_selectedPaperProfile);
            cbb_PaperProfile.UpdateUI(_paperResource.Profiles);
        }
        #endregion
    }
}
