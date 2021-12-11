using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NomogramPrint.Models;

namespace NomogramPrint.Servicies
{
    public class ExcelParser
    {
        public DbContext GetData()
        {
            DbContext context = new DbContext();
            for (int i = 380; i > 350; i--)
                context.Kilometers.Add(new Kilometer { Number = i, Digits = "00-00" });
            return context;
        }
    }
}
