using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCR.Utils.Enum;

namespace OCR.Views.Additions.Dialogs
{
    public partial class SelectFromDialog : Form
    {
        public static CustomDialogResult ShowCustomDialog()
        {
            SelectFromDialog dialog = new SelectFromDialog();
            _ = dialog.ShowDialog();
            return dialog._selectResult;
        }

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
            this.Close();
        }

        private void Btn_FileLocal_Click(object sender, EventArgs e)
        {
            _selectResult = CustomDialogResult.LocalFile;
            this.Close();
        }

        private void Btn_VideoCapture_Click(object sender, EventArgs e)
        {
            _selectResult = CustomDialogResult.VideoCapture;
            this.Close();
        }
    }
}
