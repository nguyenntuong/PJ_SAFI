using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
