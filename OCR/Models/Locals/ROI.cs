using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.Models.Locals
{
    [Serializable]
    public class ROI
    {
        public const int Acc = 1000;
        public static ROI Empty => null;
        public string RegionName { get; set; }
        public Rectangle RegionRectangle { get; set; }
        public string Language { get; set; }
        public string RegexPattern { get; set; }
        public string RegexPatternSpecialChar { get; set; }
        public ROI(string name, string lang, Rectangle rectangle, string regexpattern, string specialchar)
        {
            RegexPattern = regexpattern ?? "";
            RegexPatternSpecialChar = specialchar ?? "";
            RegionName = name ?? "";
            RegionRectangle = rectangle;
            Language = lang ?? "";
        }

        public string GenaratedRegexPattern
        {
            get
            {
                if (string.Equals(RegexPattern, ".*"))
                {
                    return ".*";
                }
                else if (string.IsNullOrEmpty(RegexPattern))
                {
                    return "";
                }
                else
                {
                    if (string.IsNullOrEmpty(RegexPatternSpecialChar))
                    {
                        return $"[{RegexPattern}]*";
                    }
                    else
                    {
                        return $"[{RegexPattern}\\{RegexPatternSpecialChar}]*";
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"{RegionName} : {Language} : {{{RegionRectangle.ToString()}}}";
        }
    }
}
