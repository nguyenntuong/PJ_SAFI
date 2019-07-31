using System;
using System.IO;
using NHunspell;

namespace OCR.Libraries.Handlers
{
    internal static class HunspellHandler
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
