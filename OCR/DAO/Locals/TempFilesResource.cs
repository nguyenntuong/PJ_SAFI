using System.IO;
using OCR.DAO.Interfaces;

namespace OCR.DAO.Locals
{
    internal class TempFilesResource : ITempFilesResource
    {
        #region static
        private static object _locker = new object();
        private static TempFilesResource _instance = null;
        public static ITempFilesResource DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new TempFilesResource();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region instance
        private const string _path = @"Resources/Data/tmp/";

        private TempFilesResource()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }
        #endregion
        #region interface
        public bool DeleteFile(string fileName)
        {
            string path = Path.Combine(_path, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public string GetFullPath(string fileName)
        {
            return Path.Combine(_path, fileName);
        }

        public string PrepateFileLocation()
        {
            string fileName = Path.GetRandomFileName();
            string path = Path.Combine(_path, fileName);
            while (File.Exists(path))
            {
                fileName = Path.GetRandomFileName();
                path = Path.Combine(_path, fileName);
            }
            return fileName;
        }
        #endregion
    }
}
