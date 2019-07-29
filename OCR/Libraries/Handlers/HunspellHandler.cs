using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHunspell;

namespace OCR.Libraries.Handlers
{
    static class HunspellHandler
    {
        #region static
        private const string _binPath = @"Libraries/";
        public static void Init()
        {
            string _hsDllPath = Path.Combine(_binPath, Environment.Is64BitProcess ? "x64/Hunspellx64.dll" : "x86/Hunspellx86.dll");
            Hunspell.NativeDllPath = _hsDllPath;
        }
        #endregion
    }
}
