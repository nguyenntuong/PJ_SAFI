using System.IO;

namespace OCR.Utils.Extensions.Objects
{
    public static class StringExtension
    {
        public static bool CheckIfIsFileAndExist(this string path)
        {
            return File.Exists(path);
        }

        public static bool CheckIfIsFolderAndExist(this string path)
        {
            return Directory.Exists(path);
        }
    }
}
