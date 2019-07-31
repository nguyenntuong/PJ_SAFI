using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCR.Processors.Interfaces;

namespace OCR.Processors.Handlers
{
    class ImportImage : IImportImage
    {
        #region static
        public static IImportImage DefaultInstance() => new ImportImage();
        public static IImportImage Instance(IDetectPaperArea detect) => new ImportImage(detect);
        #endregion
        #region instance
        #region dependencyinjection
        private readonly IDetectPaperArea _detectPaper = null;
        #endregion
        private ImportImage()
        {

        }
        private ImportImage(IDetectPaperArea detect)
        {
            _detectPaper = detect;
        }
        #endregion
        #region interface
        public IEnumerable<CImage> ImportFromFile(string path)
        {
            List<CImage> results = new List<CImage>();
            var ext = Path.GetExtension(path);
            if (Pdf2Image.FileTypeSupport.Contains(ext))
            {
                IPdf2Image convert = Pdf2Image.DefaultInstance();
                var imgs = convert.GetImages(path);
                results.AddRange(imgs.Select(img => new CImage(_detectPaper != null ? _detectPaper.DetectAndExtractPaperArea(img) : img)));
            }
            else if (CImage.ImageTypeSupport.Contains(ext))
            {
                if(_detectPaper != null)
                {
                    results.Add(new CImage(_detectPaper.DetectAndExtractPaperArea(path)));
                }
                else
                {
                    results.Add(new CImage(path));
                }
                
            }
            return results;
        }

        public IEnumerable<CImage> ImportFromFolder(string path)
        {
            List<CImage> results = new List<CImage>();
            string[] files = Directory.GetFiles(path).Where(f =>
            {
                var ext = Path.GetExtension(f);
                return Pdf2Image.FileTypeSupport.Contains(ext) || CImage.ImageTypeSupport.Contains(ext);
            }).ToArray();
            foreach (string file in files)
            {
                results.AddRange(ImportFromFile(file));
            }
            return results;
        }
        #endregion
    }
}
