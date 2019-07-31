using Emgu.CV;

namespace OCR.Processors.Interfaces
{
    internal interface IModifyImage
    {
        IImage RotateLeft();
        IImage RotateRight();
        IImage ThresholdBinary(int threshold);
    }
}
