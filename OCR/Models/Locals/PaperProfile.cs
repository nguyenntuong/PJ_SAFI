using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR.Models.Locals
{
    [Serializable]
    public class PaperProfile
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public PaperProfile(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }

    }
}
