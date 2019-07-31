using System.Collections.Generic;
using OCR.Processors.Handlers;

namespace OCR.Processors.Interfaces
{
    internal interface IImportImage
    {
        IEnumerable<CImage> ImportFromFolder(string path);
        IEnumerable<CImage> ImportFromFile(string path);
    }
}
