using System.Collections.Generic;
using System.IO;
using System.Linq;
using OCR.DAO.Interfaces;
using OCR.Models.Locals;
using OCR.Utils.Extensions.Objects;

namespace OCR.DAO.Locals
{
    internal class ROIProfilesResource : IROIProfilesResource
    {
        #region static
        private static object _locker = new object();
        private static ROIProfilesResource _instance = null;
        public static IROIProfilesResource DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new ROIProfilesResource();
                    }
                }
            }
            return _instance;
        }
        #endregion
        #region instace
        private const string _path = @"Resources/Data/profiles";

        private ROIProfilesResource()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }
        #endregion
        #region interface
        public List<string> Profiles => Directory.GetFiles(_path).Select(f => Path.GetFileNameWithoutExtension(f)).ToList();

        public void AddOrUpdateRegionProfile(ROIProfile regionProfile)
        {
            string path = Path.Combine(_path, $"{regionProfile.Name}");
            using (BinaryWriter binary = new BinaryWriter(File.OpenWrite(path)))
            {
                binary.Write(regionProfile.Serialize());
            }
        }

        public void DeleteRegionProfile(ROIProfile regionProfile)
        {
            string path = Path.Combine(_path, $"{regionProfile.Name}");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void DeleteRegionProfile(string regionProfileName)
        {
            string path = Path.Combine(_path, $"{regionProfileName}");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public ROIProfile GetRegionProfile(string regionProfileName)
        {
            string path = Path.Combine(_path, $"{regionProfileName}");
            if (!File.Exists(path))
            {
                return null;
            }
            using (BinaryReader binary = new BinaryReader(File.OpenRead(path)))
            {
                return binary.ReadBytes((int)binary.BaseStream.Length).DeSerialize<ROIProfile>();
            }
        }
        #endregion
    }
}
