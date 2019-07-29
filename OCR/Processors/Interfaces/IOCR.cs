using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using OCR.Models.Locals;
using OCR.Processors.Interfaces;

namespace OCR.Processors.Interfaces
{
    interface IOCR
    {
        string GetUtf8Text(ICImage image);
        string GetUtf8Text(IImage image);
        string GetUtf8Text(IImage image, Rectangle roi);
    }
}
