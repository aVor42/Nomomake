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
            Objects = new List<IObject>();
        }

        public int Number { get; set; }
        public List<IObject> Objects { get; set; }
    }
}
