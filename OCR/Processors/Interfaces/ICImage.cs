using Emgu.CV;

namespace OCR.Processors.Interfaces
{
    internal interface ICImage
    {
        IImage GetOriginalImage();
        IImage GetAfterProcessImage();
    }
}
