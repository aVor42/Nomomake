using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NomogramPrint.Models;

namespace NomogramPrint.Drawing
{
    public class Drawer
    {
        public Drawer():
            this(new DrawSettings())
        { }

        public Drawer(DrawSettings drawSettings)
        {
            DrawSettings = drawSettings;
        }

        public DrawSettings DrawSettings { get; set; }

        public void DrawKilometers(Graphics graphics, List<Kilometer> kilometers)
        {
            for(int i = 0; i < kilometers.Count; i++)
            {
                var left = DrawSettings.KilometerSettings.Width * i;
                var kilometerDrawer = new KilometerDrawer();
                
                kilometerDrawer.DrawCell(left, graphics, DrawSettings, kilometers[i]);
                kilometerDrawer.DrawDiagonal(left, graphics, DrawSettings);
            }
        }


    }
}
