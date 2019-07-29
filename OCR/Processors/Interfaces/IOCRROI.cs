using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using OCR.Models.Locals;

namespace OCR.Processors.Interfaces
{
    interface IOCRROI
    {
        List<Dictionary<string, string>> GetUtf8TextBaseOnRegions(ICImage image, ROIProfile regions, out IImage imgdrawed);
        List<Dictionary<string, string>> GetUtf8TextBaseOnRegions(IImage image, ROIProfile regions, out IImage imgdrawed);
    }
}
