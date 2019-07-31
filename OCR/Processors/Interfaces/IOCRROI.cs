using System.Collections.Generic;
using Emgu.CV;
using OCR.Models.Locals;

namespace OCR.Processors.Interfaces
{
    internal interface IOCRROI
    {
        List<Dictionary<string, string>> GetUtf8TextBaseOnRegions(ICImage image, ROIProfile regions, out IImage imgdrawed);
        List<Dictionary<string, string>> GetUtf8TextBaseOnRegions(IImage image, ROIProfile regions, out IImage imgdrawed);
    }
}
