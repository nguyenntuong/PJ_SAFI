using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCR.Processors.Handlers;

namespace OCR.Processors.Interfaces
{
    interface IImportImage
    {
        IEnumerable<CImage> ImportFromFolder(string path);
        IEnumerable<CImage> ImportFromFile(string path);
    }
}
