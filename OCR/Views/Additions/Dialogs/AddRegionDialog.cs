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

namespace OCR.Views.Additions.Dialogs
{
    public partial class AddRegionDialog : Form
    {
        public static DialogResult ShowCustomDialog(List<ROI> currentList, ROI region)
        {
            AddRegionDialog form = new AddRegionDialog(currentList, region);
            return form.ShowDialog();
        }

        private ROI _regionInfer;
        private List<ROI> _currentRegionList;

        private AddRegionDialog(List<ROI> currentList, ROI region)
        {
            InitializeComponent();
            _regionInfer = region;
            _currentRegionList = currentList;
        }

        private void AddRegionForm_Load(object sender, EventArgs e)
        {
            txt_Identifer.Text = _regionInfer.RegionName;
            txt_RectRegion.Text = _regionInfer.RegionRectangle.ToString();
            cbb_Language.UpdateUI(TesseractLangSupport.Languages, _regionInfer.Language);
        }

        private void Btn_Accept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Identifer.Text))
            {
                MessageBox.Show("Định danh vùng không được trống", "Thiếu thông tin.");
                return;
            }
            if (_currentRegionList.Any(r => r.RegionName.Equals(txt_Identifer.Text.Trim())))
            {
                MessageBox.Show("Định danh vùng không được trùng nhau", "Trùng lập.");
                return;
            }
            if (cbb_Language.SelectedItem == null)
            {
                MessageBox.Show("Cần chọn ngôn ngữ cho vùng này.", "Thiếu thông tin.");
                return;
            }
            if (checkBox_AllMatch.Checked)
            {
                _regionInfer.RegexPattern = @".*";
                _regionInfer.RegexPatternSpecialChar = "";
            }
            else
            {
                string combiePattern = "";
                if (checkBox_AZaz.Checked)
                    combiePattern += @"A-Za-z";
                if (checkBox_09.Checked)
                    combiePattern += @"0-9";
                _regionInfer.RegexPattern = combiePattern;
                combiePattern = "";
                if (!string.IsNullOrEmpty(txt_SpecialCharacter.Text))
                {
                    combiePattern += new string(txt_SpecialCharacter.Text.Distinct().ToArray());
                }
                _regionInfer.RegexPatternSpecialChar = combiePattern;
            }
            _regionInfer.RegionName = txt_Identifer.Text;
            _regionInfer.Language = cbb_Language.SelectedItem.ToString().Trim();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CheckBox_AllMatch_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb.Checked)
            {
                checkBox_09.Checked = checkBox_AZaz.Checked = true;
            }
        }
    }
}
