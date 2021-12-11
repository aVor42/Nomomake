using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NomogramPrint.Models
{
    public class Kilometer
    {

        public Kilometer() :
            this(0)
        { }

        public Kilometer(int number)
        {
            Number = number;
            Images = new List<string>();
        }

        public int Number { get; set; }
        public string Triangle { get; set; }
        public string Digits { get; set; }
        public List<string> Images { get; set; }
    }
}
