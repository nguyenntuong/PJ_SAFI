using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using ROI = OCR.Models.Locals.ROI;

namespace OCR.Views.Forms.ForTest
{
    public partial class ShowImageForm : Form
    {
        #region instance
        private IImage _image = null;
        private List<ROI> _regions = null;
        public ShowImageForm(IImage image)
        {
            InitializeComponent();
            _image = image;
        }
        public ShowImageForm(IImage image, List<ROI> rectangles)
        {
            InitializeComponent();
            _image = (IImage)image?.Clone();
            _regions = rectangles;
        }
        private void ShowRect_Load(object sender, EventArgs e)
        {
            if (_image != null)
            {
                if (_regions != null)
                {
                    foreach (ROI rec in _regions)
                    {
                        CvInvoke.Rectangle(_image, rec.RegionRectangle, new MCvScalar(0));
                    }
                }
                pictureBox1.Image = _image.Bitmap;
            }
        }
        #endregion
    }
}
