using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;
using OCR.Libraries.Handlers;
using OCR.Processors.Interfaces;

namespace OCR.Processors.Handlers
{
    internal class Pdf2Image : IPdf2Image
    {
        #region static
        /// <summary>
        /// File need to Convert
        /// </summary>
        public static readonly IReadOnlyList<string> FileTypeSupport = new List<string>
        {
            ".pdf"
        };

        private static object _lockerObject = new object();
        private static Pdf2Image _instance = null;
        public static IPdf2Image DefaultInstance()
        {
            if (_instance == null)
            {
                lock (_lockerObject)
                {
                    if (_instance == null)
                    {
                        _instance = new Pdf2Image();
                    }
                }
            }
            return _instance;
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
        /// <returns>List Mat</returns>
        public List<IImage> GetImages(string path)
        {
            try
            {
                using (GhostscriptRasterizer rasterizer = new GhostscriptRasterizer())
                {
                    rasterizer.Open(path, _ghostScript, false);
                    List<IImage> imgs = new List<IImage>();
                    for (int i = 1; i <= rasterizer.PageCount; i++)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            Image pdf2PNG = rasterizer.GetPage(300, 300, i);
                            pdf2PNG.Save(memoryStream, ImageFormat.Png);
                            using (Bitmap bmp = new Bitmap(memoryStream))
                            {
                                imgs.Add(new Image<Bgr, byte>(bmp).Mat);
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
