using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCR.Models.Locals;
using ROI = OCR.Models.Locals.ROI;

namespace OCR.Utils.Extensions.Structs
{
    public static class RectangleExtension
    {
        /*
        public static Rectangle ConvertToActualyImageSize(Rectangle rectangle,PictureBox pictureBox)
        {
            var img = pictureBox.Image;
            var pb = pictureBox;
            var wfactor = (double)img.Width / pb.ClientSize.Width;
            var hfactor = (double)img.Height / pb.ClientSize.Height;

            var resizeFactor = Math.Max(wfactor, hfactor);
            var imageSize = new Size((int)(img.Width / resizeFactor), (int)(img.Height / resizeFactor));
            rectangle.X = (int)((rectangle.X - (pb.Width / 2 - imageSize.Width / 2)) * resizeFactor);
            rectangle.Y = (int)(rectangle.Y * resizeFactor);
            rectangle.Width = (int)(rectangle.Width * resizeFactor);
            rectangle.Height = (int)(rectangle.Height * resizeFactor);
            return rectangle;
        }
        */

        //TODO Tìm cách lưu lại resizeFactor trước đó
        /// <summary>
        /// Chuyển đổi kích thước, vị trí Rect khi kích thức PictureBox thay đổi
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static Rectangle ConvertToCurrentClientSize(this Rectangle rectangle, PictureBox picBox)
        {
            if (picBox == null)
                return Rectangle.Empty;
            var img = picBox.Image;
            var pb = picBox;
            var wfactor = (double)img.Width / pb.ClientSize.Width;
            var hfactor = (double)img.Height / pb.ClientSize.Height;

            var resizeFactor = Math.Max(wfactor, hfactor);
            var imageSize = new Size((int)(img.Width / resizeFactor), (int)(img.Height / resizeFactor));
            rectangle.X = (int)((rectangle.X - (picBox.Width / 2 - imageSize.Width / 2)) * resizeFactor);
            rectangle.Y = (int)(rectangle.Y * resizeFactor);
            rectangle.Width = (int)(rectangle.Width * resizeFactor);
            rectangle.Height = (int)(rectangle.Height * resizeFactor);
            return rectangle;
        }

        /// <summary>
        /// Chuyển đổi kích thước của Rect trong Pic thành kích thước thực của ảnh
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static Rectangle ConvertToActualyImageSizeWithAcc(this Rectangle rectangle, PictureBox picBox)
        {
            if (picBox == null)
                return Rectangle.Empty;
            var img = picBox.Image;
            var pb = picBox;
            var wfactor = (int)((double)(img.Width * ROI.Acc) / pb.ClientSize.Width);
            var hfactor = (int)((double)(img.Height * ROI.Acc) / pb.ClientSize.Height);

            rectangle.Y = rectangle.Y * hfactor;
            rectangle.X = rectangle.X * wfactor;
            rectangle.Width = rectangle.Width * wfactor;
            rectangle.Height = rectangle.Height * hfactor;

            return rectangle;
        }

        public static Rectangle ConvertToActualyImageSizeRemoveAcc(this Rectangle rectangle)
        {
            rectangle.Y /= ROI.Acc;
            rectangle.X /= ROI.Acc;
            rectangle.Width /= ROI.Acc;
            rectangle.Height /= ROI.Acc;

            return rectangle;
        }

        /// <summary>
        /// Chuyển đổi kích thước của Rect từ kích thước thật sang kích thức của Pic ở mode zoom
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static Rectangle ConvertActualyImageSizeToPictureClientSize(Rectangle rectangle, PictureBox picBox)
        {
            if (picBox == null)
                return Rectangle.Empty;
            var img = picBox.Image;
            var pb = picBox;
            var wfactor = (int)(((double)img.Width / pb.ClientSize.Width) * ROI.Acc);
            var hfactor = (int)(((double)img.Height / pb.ClientSize.Height) * ROI.Acc);

            rectangle.Y = (int)(rectangle.Y / hfactor);
            rectangle.X = (int)(rectangle.X / wfactor);
            rectangle.Width = (int)(rectangle.Width / wfactor);
            rectangle.Height = (int)(rectangle.Height / hfactor);

            return rectangle;
        }

        /// <summary>
        /// Chuyển đổi một Rectangle từ vị trí ở kích thước thực của ảnh sang vị trí trong kíc thước đã thay đổi
        /// </summary>
        /// <param name="rectangle">Rect trong kích thước thật</param>
        /// <param name="paperProfile">Thông tin kích thước thật của ảnh</param>
        /// <param name="img">Thông tin kích thức ảnh cần chuyển qua</param>
        /// <returns></returns>
        public static Rectangle ConvertActualyImageSizeToImageResize(Rectangle rectangle, PaperProfile paperProfile, Image img)
        {
            if (paperProfile == null)
                return Rectangle.Empty;
            double xRatio = (double)rectangle.X / paperProfile.Width;
            double yRatio = (double)rectangle.Y / paperProfile.Height;
            double widthRatio = (double)rectangle.Width / paperProfile.Width;
            double heightRatio = (double)rectangle.Height / paperProfile.Height;

            rectangle.X = (int)((xRatio * img.Width) / ROI.Acc);
            rectangle.Y = (int)((yRatio * img.Height) / ROI.Acc);
            rectangle.Width = (int)((widthRatio * img.Width) / ROI.Acc);
            rectangle.Height = (int)((heightRatio * img.Height) / ROI.Acc);
            return rectangle;
        }
    }
}
