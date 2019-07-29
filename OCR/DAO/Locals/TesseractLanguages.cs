using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCR.DAO.Interfaces;

namespace OCR.DAO.Locals
{
    class TesseractLanguages : ITesseractLanguages
    {
        #region static
        private static object _locker = new object();
        private static TesseractLanguages _instance = null;
        public static TesseractLanguages DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new TesseractLanguages();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region instance

        private const string _path = @"Resources/Data/tessdata";

        private string _defaultLanguage = "eng";

        private TesseractLanguages()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            if (!File.Exists(_path + $"/{DefaultLanguage}.traineddata"))
            {
                Debug.WriteLine("Default language not found, change to first language in list.");
                _defaultLanguage = Languages.FirstOrDefault();
            }
        }
        #endregion
        #region interface
        public string DefaultLanguage => _defaultLanguage;

        public List<string> Languages => Directory.GetFiles(_path).Where(f => f.Contains(".traineddata")).Select(f => Path.GetFileNameWithoutExtension(f)).ToList();

        public string GetLanguagesDir()
        {
            return Path.Combine(_path, "/");
        }
        #endregion
    }
}
