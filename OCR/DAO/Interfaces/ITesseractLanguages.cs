using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.DAO.Interfaces
{
    interface ITesseractLanguages
    {
        string DefaultLanguage { get; }
        List<string> Languages { get; }
        string GetLanguagesDir();
    }
}
