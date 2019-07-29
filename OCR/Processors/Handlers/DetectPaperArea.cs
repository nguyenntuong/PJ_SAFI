using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using OCR.Processors.Interfaces;

namespace OCR.Processors.Handlers
{
    class DetectPaperArea : IDetectPaperArea
    {
        #region static

        public static DetectPaperArea MakeInstance()
        {
            return new DetectPaperArea();
        }
        #endregion
        #region instance
        private DetectPaperArea()
        {

        }
        #endregion
        #region interface
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgmat">is Mat</param>
        /// <param name="lastrotatedrect"></param>
        /// <returns></returns>
        public (IImage imgOriginal, IImage imgDrawed, RotatedRect rotated) DetectAndDrawPaperArea(IImage imgmat, RotatedRect lastrotatedrect)
        {
            if (imgmat == null)
                return (null, null, RotatedRect.Empty);
            Mat mat = imgmat as Mat;
            if (mat == null)
                throw new Exception("imgmat must be Mat object.");
            RotatedRect rotate = lastrotatedrect;
            Image<Bgr, byte> original = mat.ToImage<Bgr, byte>();

            bool isRotateRectFound = false;
            float factor = 1000f / Math.Max(mat.Width, mat.Height);
            using (Image<Bgr, byte> imgColor = original.Resize(factor, Inter.Linear))
            {
                /// Convert to Gray image and try to make edges more distinct
                using (Image<Gray, byte> imGray = imgColor.Convert<Gray, byte>().PyrDown().PyrUp())
                {
                    //// Remove noise
                    using (var imGrayAfterPyr = imGray
                        .ThresholdBinary(new Gray(150), new Gray(255))
                        // Tách các khu vực ra thành từng thành phần riêng lẽ
                        .Erode(3)
                        //.ThresholdAdaptive(new Gray(255), AdaptiveThresholdType.GaussianC, ThresholdType.Binary, 5, new Gray(0))
                        )
                    {
                        using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                        {
                            CvInvoke.FindContours(imGrayAfterPyr, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                            var contourlist = Enumerable
                                .Range(0, contours.Size)
                                .Select(i => contours[i])
                                .OrderByDescending(c => CvInvoke.ContourArea(c))
                                .Take(5);

                            foreach (var c in contourlist)
                            {
                                using (VectorOfPoint v = new VectorOfPoint())
                                {
                                    var peri = CvInvoke.ArcLength(c, true);
                                    CvInvoke.ApproxPolyDP(c, v, 0.1 * peri, true);
                                    if (v != null && v.ToArray().Length == 4 && CvInvoke.IsContourConvex(v))
                                    {
                                        rotate = CvInvoke.MinAreaRect(v);
                                        var _2YMaxPoint = rotate.GetVertices().OrderByDescending(p => p.Y).Take(2).ToList();
                                        bool isRotate = false;
                                        if (_2YMaxPoint[1].X > _2YMaxPoint[0].X)
                                        {
                                            if (rotate.Angle > 0)
                                            {
                                                isRotate = true;
                                            }
                                        }
                                        else
                                        {
                                            if (rotate.Angle < -45)
                                            {
                                                isRotate = true;
                                            }
                                        }
                                        if (isRotate)
                                        {
                                            if (rotate.Size.Height + 1 >= imGrayAfterPyr.Size.Width && rotate.Size.Width + 1 >= imGrayAfterPyr.Size.Height)
                                                continue;
                                        }
                                        else
                                        {
                                            if (rotate.Size.Width + 1 >= imGrayAfterPyr.Size.Width && rotate.Size.Height + 1 >= imGrayAfterPyr.Size.Height)
                                                continue;
                                        }
                                        isRotateRectFound = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            var imgDraw = original.Clone();
            if (isRotateRectFound)
            {
                rotate = new RotatedRect()
                {
                    Size = new SizeF(rotate.Size.Width / factor, rotate.Size.Height / factor),
                    Angle = rotate.Angle,
                    Center = new PointF
                    {
                        X = rotate.Center.X / factor,
                        Y = rotate.Center.Y / factor,
                    }
                };
            }
            imgDraw.Draw(rotate, new Bgr(0, 0, 255), 2);
            return (original, imgDraw, rotate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgOriginal">is Image<Bgr, byte></param>
        /// <param name="rotatedRect"></param>
        /// <returns></returns>
        public IImage ExtractPaperArea(IImage imgOriginal, RotatedRect rotatedRect)
        {
            if (imgOriginal == null)
                return null;
            Image<Bgr, byte> imgColor = imgOriginal as Image<Bgr, byte>;
            if (imgColor == null)
                throw new Exception("imgmat must be Image<Bgr, byte> object.");

            Image<Bgr, byte> imgReturn = imgColor;
            if (rotatedRect.Size != SizeF.Empty)
                imgReturn = imgColor.Copy(rotatedRect);
            var _2YMaxPoint = rotatedRect.GetVertices().OrderByDescending(p => p.Y).Take(2).ToList();
            if (_2YMaxPoint[1].X > _2YMaxPoint[0].X)
            {
                if (rotatedRect.Angle > 0)
                {
                    imgReturn = imgReturn.Rotate(90, new Bgr(255, 255, 255), false);
                }
            }
            else
            {
                if (rotatedRect.Angle < -45)
                {
                    imgReturn = imgReturn.Rotate(-90, new Bgr(255, 255, 255), false);
                }
            }
            return imgReturn;
        }

        public IImage DetectAndExtractPaperArea(string path)
        {
            var rs = DetectAndDrawPaperArea(new Mat(path), RotatedRect.Empty);
            return ExtractPaperArea(rs.imgOriginal, rs.rotated);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img">is Mat</param>
        /// <returns></returns>
        public IImage DetectAndExtractPaperArea(IImage img)
        {
            var rs = DetectAndDrawPaperArea(img, RotatedRect.Empty);
            return ExtractPaperArea(rs.imgOriginal, rs.rotated);
        }
        #endregion
    }
}
