using System.Collections.Generic;

namespace OCR.DAO.Interfaces
{
    internal interface ITesseractLanguages
    {
        string DefaultLanguage { get; }
        List<string> Languages { get; }
        string GetLanguagesDir();
    }
}
