using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHunspell;
using OCR.DAO.Interfaces;
using OCR.Libraries.Handlers;

namespace OCR.DAO.Locals
{
    class HunspellDictionaryLanguages : IHunspellDictionaryLanguages
    {
        #region static
        private static object _locker = new object();
        private static HunspellDictionaryLanguages _instance = null;
        public static HunspellDictionaryLanguages DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new HunspellDictionaryLanguages();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region instance
        private const string _path = @"Resources/Data/dictionary";
        private HunspellDictionaryLanguages()
        {
            HunspellHandler.Init();
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }
        #endregion
        #region interface
        public List<string> Languages => Directory.GetFiles(_path).Where(f => f.Contains(".dic")).Select(f => Path.GetFileNameWithoutExtension(f)).ToList();

        /// <summary>
        /// Get dictory path
        /// </summary>
        /// <param name="langName">Name of Dic</param>
        /// <returns>
        /// Key is aff file
        /// Value is dic file
        /// </returns>
        public KeyValuePair<string, string> GetDictionaryPath(string langName)
        {
            var affPath = Path.Combine(_path, $"/{langName}.aff");
            var dicPath = Path.Combine(_path, $"/{langName}.dic");
            if (!File.Exists(affPath) || !File.Exists(dicPath))
            {
                return new KeyValuePair<string, string>("", "");
            }
            return new KeyValuePair<string, string>(affPath, dicPath);
        }
        #endregion
    }
}
