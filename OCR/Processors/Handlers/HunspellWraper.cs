using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using NHunspell;
using OCR.DAO.Interfaces;
using OCR.DAO.Locals;
using OCR.Processors.Interfaces;

namespace OCR.Processors.Handlers
{
    class HunspellWraper : IHunspellWraper, IDisposable
    {
        #region static
        public static HunspellWraper Instace(string language)
        {
            return new HunspellWraper(language);
        }
        #endregion
        #region instance
        private IHunspellDictionaryLanguages _dictionaryLanguages = null;
        private string _lang = "";
        private Hunspell _spc = null;
        private HunspellWraper(string lang)
        {
            _lang = lang;
            _dictionaryLanguages = HunspellDictionaryLanguages.DefaultInstance();
            if (!_dictionaryLanguages.Languages.Contains(_lang))
            {
                throw new Exception("Language not found.");
            }
            _spc = new Hunspell();
            var dicPath = _dictionaryLanguages.GetDictionaryPath(_lang);
            _spc.Load(dicPath.Key, dicPath.Value);
        }
        #endregion
        #region interface
        public string SpellCheck(string word)
        {
            if (string.IsNullOrEmpty(word))
                return "";
            if (!_spc.Spell(word))
            {
                var sg = _spc.Suggest(word);
                if (sg.Count > 0)
                {
                    word = sg[0];
                }
            }
            return word;
        }

        public string SpellChecks(string words)
        {
            if (string.IsNullOrEmpty(words))
                return "";
            string[] word_arr = words.Split(' ');
            for (int i = 0; i < word_arr.Length; i++)
            {
                string word = word_arr[i];
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }
                if (!_spc.Spell(word))
                {
                    var sg = _spc.Suggest(word);
                    if (sg.Count > 0)
                    {
                        word_arr[i] = sg[0];
                    }
                }
            }
            return string.Join(" ", words);
        }
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
                _spc?.Dispose();
            }

            disposed = true;
        }
        #endregion
    }
}
