using System;
using System.IO;
using Ghostscript.NET;

namespace OCR.Libraries.Handlers
{
    public static class GhostScriptHandler
    {
        #region static
        private const string _binPath = @"Libraries/";

        private static object _locker = new object();
        private static GhostscriptVersionInfo _ghostscriptVersionInfo = null;
        public static GhostscriptVersionInfo GhostScriptVersion
        {
            get
            {
                if (_ghostscriptVersionInfo == null)
                {
                    lock (_locker)
                    {
                        if (_ghostscriptVersionInfo == null)
                        {
                            /// <summary>
                            /// Mặc dù có 64bit nhưng chỉ sử dụng 32bit vì tương thích với các thư viện còn lại
                            /// </summary>
                            string _gsDllPath = Path.Combine(_binPath, Environment.Is64BitProcess ? "x64/gsdll64.dll" : "x86/gsdll32.dll");
                            string _gsLibPath = Path.Combine(_binPath, Environment.Is64BitProcess ? "x64/gsdll64.lib" : "x86/gsdll32.lib");
                            _ghostscriptVersionInfo = new GhostscriptVersionInfo(
                                new Version(0, 0, 0)
                                , _gsDllPath
                                , _gsLibPath
                                , GhostscriptLicense.GPL);
                        }
                    }
                }
                return _ghostscriptVersionInfo;
            }
        }
        #endregion
    }
}
