using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCR.DAO.Interfaces;

namespace OCR.DAO.Locals
{
    class AppConfig : IAppConfig
    {
        #region static
        private static object _lockerObject = new object();
        private static AppConfig _instance = null;
        public static IAppConfig DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_lockerObject)
                {
                    if (_instance == null)
                    {
                        _instance = new AppConfig();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region instance

        private readonly Dictionary<string, object> _storage = null;

        private AppConfig()
        {
            _storage = new Dictionary<string, object>();
        }
        #endregion
        #region interface
        public T GetConfig<T>(string key)
        {
            if (_storage.ContainsKey(key) && _storage[key] != null)
            {
                return (T)_storage[key];
            }
            return default;
        }

        public void SetConfig<T>(string key, T value)
        {
            if (_storage.ContainsKey(key))
            {
                if (value == null)
                {
                    _storage.Remove(key);
                }
                else
                {
                    _storage[key] = value;
                }
            }
            else
            {
                _storage.Add(key, value);
            }
        }
        #endregion
    }
}
