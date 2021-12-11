using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomogramPrint.Models
{
    public class DbContext
    {

        public DbContext()
        {
            Kilometers = new List<Kilometer>();
        }

        public List<Kilometer> Kilometers { get; set;}
    }
}
