using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCR.DAO.Interfaces;
using WIA;

namespace OCR.DAO.Locals
{
    class TempFilesScannerResource<T> : ITempFilesResource<T> where T : ImageFile
    {
        #region static
        private static object _locker = new object();
        private static TempFilesScannerResource<ImageFile> _instance = null;
        public static ITempFilesResource<ImageFile> DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new TempFilesScannerResource<ImageFile>();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region instace
        private const string _path = @"Resources/Data/tmp/";

        private TempFilesScannerResource()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }
        #endregion
        #region instance
        public bool DeleteFile(string fileName)
        {
            var path = Path.Combine(_path, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public string SaveFile(T ob)
        {
            if (ob == null)
            {
                throw new Exception("Cant save file.");
            }
            var fileName = Path.GetRandomFileName() + ob.FileExtension;
            var path = Path.Combine(_path, fileName);
            while (File.Exists(path))
            {
                fileName = Path.GetRandomFileName() + ob.FileExtension;
                path = Path.Combine(_path, fileName);
            }
            try
            {
                ob.SaveFile(path);
                return fileName;
            }
            catch
            {
                throw new Exception("Cant save file.");
            }
        }

        public string GetFullPath(string fileName)
        {
            var path = Path.Combine(_path, fileName);
            if (File.Exists(path))
                return path;
            else
                return "";
        }
        #endregion
    }
}
