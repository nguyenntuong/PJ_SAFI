using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Microsoft.Win32.SafeHandles;
using OCR.Processors.Interfaces;

namespace OCR.Processors.Handlers
{
    class CImage : ICImage, IModifyImage, IDisposable, ILazy
    {
        #region static
        /// <summary>
        /// Danh sách các định dạng ảnh hổ trợ, file
        /// </summary>
        public readonly static IReadOnlyList<string> ImageTypeSupport = new List<string>
        {
            ".bmp",
            ".dib",
            ".jpeg",
            ".jpg",
            ".jpe",
            ".jp2",
            ".png",
            ".pbm",
            ".pgm",
            ".ppm",
            ".sr",
            ".ras",
            ".tiff",
            ".tif"
        };

        #endregion
        #region instace
        private Image<Bgr, byte> _originalImage = null;
        private Image<Gray, byte> _afterProcessImage = null;

        private string _pathImage = null;
        private bool isEnhance = false;

        public CImage(string filepath)
        {
            if (!ImageTypeSupport.Contains(Path.GetExtension(filepath)))
            {
                throw new Exception("Image not support.");
            }
            _pathImage = filepath;
        }

        /// <summary>
        /// Bgr Image
        /// </summary>
        /// <param name="image"></param>
        public CImage(IImage image)
        {
            _pathImage = null;
            switch (image)
            {
                case Image<Bgr, byte> img:
                    _originalImage = img;
                    break;
                case Image<Gray, byte> img:
                    _originalImage = img?.Convert<Bgr, byte>();
                    _afterProcessImage = img;
                    isEnhance = true;
                    break;
                default:
                    _originalImage = null;
                    throw new Exception("Image cnot read.");
            }

        }

        /// <summary>
        /// Xữ lý tăng cường chất lượng ảnh
        /// </summary>
        private void ImageEnhance()
        {
            int max = Math.Max(_originalImage.Width, _originalImage.Height);
            float factor = max < 1500 ? 1500f / max : 1;
            _afterProcessImage = _originalImage
                .Resize(factor, Inter.Cubic)
                .SmoothGaussian(3)
                .Convert<Gray, byte>();
            isEnhance = true;
        }
        #endregion
        #region interface
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Image<Gray,byte></returns>
        public IImage GetAfterProcessImage()
        {
            if (_pathImage != null && _originalImage == null && _afterProcessImage == null)
            {
                _originalImage = new Image<Bgr, byte>(_pathImage);
                ImageEnhance();
            }
            else if (_originalImage != null && _afterProcessImage == null)
            {
                ImageEnhance();
            }
            return _afterProcessImage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Image<Bgr,byte></returns>
        public IImage GetOriginalImage()
        {
            if (_pathImage != null && _originalImage == null)
            {
                _originalImage = new Image<Bgr, byte>(_pathImage);
            }
            return _originalImage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Image<Bgr,byte></returns>
        public IImage RotateLeft()
        {
            _originalImage = (GetOriginalImage() as Image<Bgr, byte>)?.Rotate(-90, new Bgr(255, 255, 255), false);
            _afterProcessImage = (GetAfterProcessImage() as Image<Gray, byte>).Rotate(-90, new Gray(255), false);
            return _originalImage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Image<Bgr,byte></returns>
        public IImage RotateRight()
        {
            _originalImage = (GetOriginalImage() as Image<Bgr, byte>)?.Rotate(90, new Bgr(255, 255, 255), false);
            _afterProcessImage = (GetAfterProcessImage() as Image<Gray, byte>).Rotate(90, new Gray(255), false);
            return _originalImage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Image<Gray,byte></returns>
        public IImage ThresholdBinary(int threshold)
        {
            var imgThres = (GetOriginalImage() as Image<Bgr, byte>).Convert<Gray, byte>().ThresholdBinary(new Gray(threshold), new Gray(255));
            return imgThres;
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
                _originalImage?.Dispose();
                _afterProcessImage?.Dispose();
                _pathImage = null;
            }

            disposed = true;
        }

        public void Release()
        {
            if (_pathImage == null)
                return;
            _originalImage = null;
            _afterProcessImage = null;
        }
        #endregion
    }
}
