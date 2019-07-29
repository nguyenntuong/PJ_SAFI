using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.DAO.Interfaces
{
    interface ITempFilesResource<T>
    {
        string SaveFile(T ob);
        string GetFullPath(string fileName);
        bool DeleteFile(string fileName);
    }
}
