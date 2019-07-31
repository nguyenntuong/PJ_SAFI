using System;
using System.IO;
using Ghostscript.NET;

namespace OCR.Libraries.Handlers
{
    public static class GhostScriptHandler
    {
        #region static
        private const string _binPath = @"Libraries/";

        public static GhostscriptVersionInfo GhostScriptVersion
        {
            get
            {
                string _gsDllPath = Path.Combine(_binPath, Environment.Is64BitProcess ? "x64/gsdll64.dll" : "x86/gsdll32.dll");
                string _gsLibPath = Path.Combine(_binPath, Environment.Is64BitProcess ? "x64/gsdll64.lib" : "x86/gsdll32.lib");
                return new GhostscriptVersionInfo(
                    new Version(0, 0, 0)
                    , _gsDllPath
                    , _gsLibPath
                    , GhostscriptLicense.GPL); ;
            }
        }
        #endregion
    }
}
