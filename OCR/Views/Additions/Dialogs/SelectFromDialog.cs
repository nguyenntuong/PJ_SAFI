using System;
using System.Windows.Forms;
using OCR.Utils.Enum;

namespace OCR.Views.Additions.Dialogs
{
    public partial class SelectFromDialog : Form
    {
        #region static
        public static CustomDialogResult ShowCustomDialog()
        {
            SelectFromDialog dialog = new SelectFromDialog();
            _ = dialog.ShowDialog();
            return dialog._selectResult;
        }

        #endregion
        #region instance
        private CustomDialogResult _selectResult = CustomDialogResult.Cancel;

        private SelectFromDialog()
        {
            InitializeComponent();
        }

        private void SelectFromDialog_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            _selectResult = CustomDialogResult.Cancel;
            Close();
        }

        private void Btn_FileLocal_Click(object sender, EventArgs e)
        {
            _selectResult = CustomDialogResult.LocalFile;
            Close();
        }

        private void Btn_VideoCapture_Click(object sender, EventArgs e)
        {
            _selectResult = CustomDialogResult.VideoCapture;
            Close();
        }
        #endregion
    }
}
