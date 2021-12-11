using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NomogramPrint
{

    // Настройки для Отрисовки километров.
    public class KilometerSettings
    {

        public KilometerSettings():
            this(0f, 0f, 0f, Color.Black, new List<Cell>()) { }

        public KilometerSettings(float width, float height, float top, Color color) :
            this(width, height, top, Color.Black, new List<Cell>()) { }

        public KilometerSettings(float width, float height, float top, Color color, List<Cell> cells)
        {
            Cells = cells;
            Color = color;
            Width = width;
            Height = height;
            Top = top;
        }

        public List<Cell> Cells { get; set; }
        public Color Color { get; set; }
        public float Top { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
    }

}
