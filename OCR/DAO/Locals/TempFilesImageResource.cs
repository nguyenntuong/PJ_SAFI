using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using OCR.DAO.Interfaces;

namespace OCR.DAO.Locals
{
    class TempFilesImageResource<T> : ITempFilesResource<T> where T : IImage
    {
        #region static
        private static object _locker = new object();
        private static TempFilesImageResource<IImage> _instance = null;
        public static ITempFilesResource<IImage> DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new TempFilesImageResource<IImage>();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region instace
        private const string _path = @"Resources/Data/tmp/";

        private TempFilesImageResource()
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
            if(ob==null)
            {
                throw new Exception("Cant save file.");
            }
            var fileName = Path.GetRandomFileName() + ".bmp";
            var path = Path.Combine(_path, fileName);
            while (File.Exists(path))
            {
                fileName = Path.GetRandomFileName() + ".bmp";
                path = Path.Combine(_path, fileName);
            }
            try
            {
                ob.Bitmap.Save(path, ImageFormat.Bmp);
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
