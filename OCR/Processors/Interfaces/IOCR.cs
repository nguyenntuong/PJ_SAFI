using System.Drawing;
using Emgu.CV;

namespace OCR.Processors.Interfaces
{
    internal interface IOCR
    {
        string GetUtf8Text(ICImage image);
        string GetUtf8Text(IImage image);
        string GetUtf8Text(IImage image, Rectangle roi);
    }
}
