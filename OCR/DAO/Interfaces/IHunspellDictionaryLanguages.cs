using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.DAO.Interfaces
{
    interface IHunspellDictionaryLanguages
    {
        List<string> Languages { get; }
        KeyValuePair<string, string> GetDictionaryPath(string langName);
    }
}
