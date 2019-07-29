using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;
using OCR.Libraries.Handlers;
using OCR.Processors.Interfaces;

namespace OCR.Processors.Handlers
{
    class Pdf2Image : IPdf2Image
    {
        #region static
        /// <summary>
        /// File need to Convert
        /// </summary>
        public readonly static IReadOnlyList<string> FileTypeSupport = new List<string>
        {
            ".pdf"
        };

        public static Pdf2Image DefaultInstance()
        {
            return new Pdf2Image();
        }
        #endregion
        #region instance
        private GhostscriptVersionInfo _ghostScript = GhostScriptHandler.GhostScriptVersion;

        private Pdf2Image()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List Image<Bgr,byte></returns>
        public List<IImage> GetImages(string path)
        {
            try
            {
                using (var rasterizer = new GhostscriptRasterizer())
                {
                    rasterizer.Open(path, _ghostScript, false);
                    var imgs = new List<IImage>();
                    for (int i = 1; i <= rasterizer.PageCount; i++)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            var pdf2PNG = rasterizer.GetPage(300, 300, i);
                            pdf2PNG.Save(memoryStream, ImageFormat.Png);
                            using (var bmp = new Bitmap(memoryStream))
                            {
                                imgs.Add(new Image<Bgr, byte>(bmp));
                            }
                        }
                    }
                    return imgs;
                }
            }
            catch (Ghostscript.NET.GhostscriptLibraryNotInstalledException e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        #endregion
    }
}
