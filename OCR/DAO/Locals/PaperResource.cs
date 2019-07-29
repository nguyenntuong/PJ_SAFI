using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCR.DAO.Interfaces;
using OCR.Models.Locals;
using OCR.Utils.Extensions.Objects;

namespace OCR.DAO.Locals
{
    class PaperResource : IPaperResource
    {
        #region static
        private static object _locker = new object();
        private static PaperResource _instance = null;
        public static IPaperResource DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new PaperResource();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region instance
        private const string _path = @"Resources/Data/papersize";

        private PaperResource()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }
        #endregion
        #region interface
        public List<string> Profiles => Directory.GetFiles(_path).Select(f => Path.GetFileNameWithoutExtension(f)).ToList();

        public void AddOrUpdatePaperProfile(PaperProfile paperProfile)
        {
            var path = Path.Combine(_path, $"{paperProfile.Name}");
            using (BinaryWriter binary = new BinaryWriter(File.OpenWrite(path)))
            {
                binary.Write(paperProfile.Serialize());
            }
        }

        public void DeletePaperProfile(PaperProfile paperProfile)
        {
            var path = Path.Combine(_path, $"{paperProfile.Name}");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void DeletePaperProfile(string paperProfileName)
        {
            var path = Path.Combine(_path, paperProfileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public PaperProfile GetPaperProfile(string paperProfileName)
        {
            var path = Path.Combine(_path, paperProfileName);
            if (!File.Exists(path))
            {
                return null;
            }
            using (BinaryReader binary = new BinaryReader(File.OpenRead(path)))
            {
                return binary.ReadBytes((int)binary.BaseStream.Length).DeSerialize<PaperProfile>();
            }
        }
        #endregion
    }
}
