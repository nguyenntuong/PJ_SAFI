using System.Collections.Generic;
using Emgu.CV;

namespace OCR.Processors.Interfaces
{
    internal interface IPdf2Image
    {
        List<IImage> GetImages(string path);
    }
}
