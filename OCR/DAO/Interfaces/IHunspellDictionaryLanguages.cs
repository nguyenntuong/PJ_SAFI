using System.Collections.Generic;

namespace OCR.DAO.Interfaces
{
    internal interface IHunspellDictionaryLanguages
    {
        List<string> Languages { get; }
        KeyValuePair<string, string> GetDictionaryPath(string langName);
    }
}
