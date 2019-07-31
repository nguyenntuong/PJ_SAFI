using System;
using System.Windows.Forms;

namespace OCR.Views.Forms.ForTest
{
    public partial class ThresholdAdjustForm : Form
    {
        private Action<object, int> _action;
        public ThresholdAdjustForm(Action<object, int> ThresholdFromAdjustChange)
        {
            InitializeComponent();
            _action = ThresholdFromAdjustChange;
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            lbl_ThresholdValue.Text = trackBar1.Value.ToString();
            _action.Invoke(sender, trackBar1.Value);
        }
    }
}
