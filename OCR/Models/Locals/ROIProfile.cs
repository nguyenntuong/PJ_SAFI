using System;
using System.Collections.Generic;

namespace OCR.Models.Locals
{
    [Serializable]
    public class ROIProfile
    {
        public string TemplateFile { get; set; }
        public string PaperSize { get; set; }
        public string Name { get; set; }
        public List<ROI> Regions { get; set; }
    }
}
