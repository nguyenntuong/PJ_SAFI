using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using OCR.DAO.Interfaces;
using OCR.DAO.Locals;
using OCR.Models.Locals;
using OCR.Processors.Interfaces;
using OCR.Utils.Extensions.Structs;

namespace OCR.Processors.Handlers
{
    internal class OCRWraper : IOCR, IOCRROI
    {
        #region static
        private static ITesseractLanguages _languages = TesseractLanguages.DefaultInstance();
        private static object _locker = new object();
        private static readonly Dictionary<string, Tesseract> _tesseracts = new Dictionary<string, Tesseract>();
        public static IOCRROI DefaultInstance()
        {
            return new OCRWraper();
        }
        public static IOCR Instance()
        {
            if (!_tesseracts.ContainsKey(_languages.DefaultLanguage))
            {
                lock (_locker)
                {
                    if (!_tesseracts.ContainsKey(_languages.DefaultLanguage))
                    {
                        _tesseracts.Add(_languages.DefaultLanguage, GetTesseractWithLanguage(_languages.DefaultLanguage));
                    }
                }
            }
            return new OCRWraper(_languages.DefaultLanguage);
        }
        public static IOCR Instance(string lang)
        {
            if (!_languages.Languages.Contains(lang))
            {
                throw new Exception("Language not found.");
            }
            if (!_tesseracts.ContainsKey(lang))
            {
                lock (_locker)
                {
                    if (!_tesseracts.ContainsKey(lang))
                    {
                        _tesseracts.Add(lang, GetTesseractWithLanguage(lang));
                    }
                }
            }
            return new OCRWraper(lang);
        }
        private static Tesseract GetTesseractWithLanguage(string lang)
        {
            return new Tesseract(_languages.GetLanguagesDir(), lang, OcrEngineMode.Default);
        }
        private static void InitialLaguagePack(ROIProfile regions)
        {
            foreach (ROI r in regions.Regions)
            {
                if (!_tesseracts.ContainsKey(r.Language))
                {
                    _tesseracts.Add(r.Language, GetTesseractWithLanguage(r.Language));
                }
            }
        }
        #endregion
        #region instance
        private string _currentLanguages;
        private OCRWraper(string lang)
        {
            _currentLanguages = lang;
        }
        private OCRWraper()
        {
            _currentLanguages = null;
        }
        #endregion
        #region interface
        public string GetUtf8Text(ICImage image)
        {
            if (image == null)
            {
                return "";
            }

            _tesseracts[_currentLanguages].SetImage(image.GetAfterProcessImage());
            return _tesseracts[_currentLanguages].GetUTF8Text();
        }

        public string GetUtf8Text(IImage image)
        {
            if (image == null)
            {
                return "";
            }

            _tesseracts[_currentLanguages].SetImage(image);
            return _tesseracts[_currentLanguages].GetUTF8Text();
        }

        public string GetUtf8Text(IImage image, Rectangle roi)
        {
            if (image == null)
            {
                return "";
            }

            using (Image<Gray, byte> gray = new Image<Gray, byte>(image.Bitmap))
            {
                Image<Gray, byte> roiCrop = gray.Copy(roi);
                _tesseracts[_currentLanguages].SetImage(roiCrop);
                return _tesseracts[_currentLanguages].GetUTF8Text();
            }
        }

        public List<Dictionary<string, string>> GetUtf8TextBaseOnRegions(ICImage image, ROIProfile regions, out IImage imgdrawed)
        {
            imgdrawed = null;
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            if (image == null)
            {
                return result;
            }

            if (regions == null)
            {
                return result;
            }

            IPaperResource paperResource = PaperResource.DefaultInstance();
            PaperProfile paperProfile = paperResource.GetPaperProfile(regions.PaperSize);
            if (paperProfile == null)
            {
                return result;
            }

            InitialLaguagePack(regions);
            Dictionary<string, string> onePage = new Dictionary<string, string>();
            Image<Gray, byte> imgThre = image.GetAfterProcessImage() as Image<Gray, byte>;
            Image<Bgr, byte> imgTmp = imgThre.Copy().Convert<Bgr, byte>();
            foreach (ROI region in regions.Regions)
            {
                Rectangle rect = region.RegionRectangle.ConvertActualyImageSizeToImageResize(paperProfile, imgThre.Bitmap);
                imgThre.ROI = rect;
                imgTmp.Draw(rect, new Bgr(Color.Red), 1);
                _tesseracts[region.Language].SetImage(imgThre.Copy());
                string txt = _tesseracts[region.Language].GetUTF8Text();
                MatchCollection ms = Regex.Matches(txt, region.GenaratedRegexPattern, RegexOptions.Multiline);
                Match m = ms.Cast<Match>().OrderByDescending(s => s.Length).Take(1).FirstOrDefault();
                onePage.Add(region.RegionName, m?.Value);
                imgThre.ROI = Rectangle.Empty;
            }
            imgdrawed = imgTmp;
            result.Add(onePage);
            return result;
        }

        public List<Dictionary<string, string>> GetUtf8TextBaseOnRegions(IImage image, ROIProfile regions, out IImage imgdrawed)
        {
            imgdrawed = null;
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            if (image == null)
            {
                return result;
            }

            if (regions == null)
            {
                return result;
            }

            IPaperResource paperResource = PaperResource.DefaultInstance();
            PaperProfile paperProfile = paperResource.GetPaperProfile(regions.PaperSize);
            if (paperProfile == null)
            {
                return result;
            }

            InitialLaguagePack(regions);
            Dictionary<string, string> onePage = new Dictionary<string, string>();
            Image<Gray, byte> imgOriginal = image is Image<Gray, byte> ? image as Image<Gray, byte> : new Image<Gray, byte>(image.Bitmap);
            Image<Bgr, byte> imgColor = imgOriginal.Copy().Convert<Bgr, byte>();
            foreach (ROI region in regions.Regions)
            {
                Rectangle rect = region.RegionRectangle.ConvertActualyImageSizeToImageResize(paperProfile, imgOriginal.Bitmap);
                imgOriginal.ROI = rect;
                imgColor.Draw(rect, new Bgr(Color.Red), 1);
                _tesseracts[region.Language].SetImage(imgOriginal.Copy());
                string txt = _tesseracts[region.Language].GetUTF8Text();
                MatchCollection ms = Regex.Matches(txt, region.GenaratedRegexPattern, RegexOptions.Multiline);
                Match m = ms.Cast<Match>().OrderByDescending(s => s.Length).Take(1).FirstOrDefault();
                onePage.Add(region.RegionName, m?.Value);
                imgOriginal.ROI = Rectangle.Empty;
            }
            imgdrawed = imgColor;
            result.Add(onePage);
            return result;
        }
        #endregion
    }
}
