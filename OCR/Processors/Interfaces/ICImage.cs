using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace OCR.Processors.Interfaces
{
    interface ICImage
    {
        IImage GetOriginalImage();
        IImage GetAfterProcessImage();
    }
}
