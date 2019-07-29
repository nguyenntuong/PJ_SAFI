using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace OCR.Processors.Interfaces
{
    interface IDetectPaperArea
    {
        (IImage imgOriginal, IImage imgDrawed, RotatedRect rotated) DetectAndDrawPaperArea(IImage mat, RotatedRect lastRotatedRect);
        IImage ExtractPaperArea(IImage imgOriginal, RotatedRect rotatedRect);
        IImage DetectAndExtractPaperArea(string path);
        IImage DetectAndExtractPaperArea(IImage img);
    }
}
