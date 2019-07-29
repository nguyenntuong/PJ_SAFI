using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.Processors.Interfaces
{
    interface IHunspellWraper
    {
        string SpellCheck(string word);
        string SpellChecks(string words);
    }
}
