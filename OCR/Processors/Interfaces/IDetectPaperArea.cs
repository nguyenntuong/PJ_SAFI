using Emgu.CV;
using Emgu.CV.Structure;

namespace OCR.Processors.Interfaces
{
    internal interface IDetectPaperArea
    {
        (IImage imgOriginal, IImage imgDrawed, RotatedRect rotated) DetectAndDrawPaperArea(IImage mat, RotatedRect lastRotatedRect);
        IImage ExtractPaperArea(IImage imgOriginal, RotatedRect rotatedRect);
        IImage DetectAndExtractPaperArea(string path);
        IImage DetectAndExtractPaperArea(IImage img);
    }
}
