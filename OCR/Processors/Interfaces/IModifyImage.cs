using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;

namespace OCR.Processors.Interfaces
{
    interface IModifyImage
    {
        IImage RotateLeft();
        IImage RotateRight();
        IImage ThresholdBinary(int threshold);
    }
}
