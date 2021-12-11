using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomogramPrint.Models
{
    public interface IObject
    {
        int Kilometers { get; set; }
        int Meters { get; set; }
    }
}
