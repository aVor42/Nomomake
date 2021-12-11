using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NomogramPrint
{
    public class DrawSettings
    {

        public DrawSettings():
            this(new KilometerSettings())
        { }

        public DrawSettings(KilometerSettings kilometerSettings)
        {
            KilometerSettings = kilometerSettings;
        }

        public  KilometerSettings KilometerSettings { get; set; }

        public void SetAllSameColor(Color color)
        {
            KilometerSettings.Color = color;
        }


    }
}
