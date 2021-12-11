using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NomogramPrint.Models;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;



namespace NomogramPrint.Servicies
{
    public class ExcelParser
    {
        public DbContext GetData()
        {
            var km = getKm();
            var iobject = getIObject();
            DbContext context = new DbContext();
            for (int i = km.Item2; i > km.Item1; i--)
                context.Kilometers.Add(new Kilometer { Number = i});
            for (int i = 0; i > iobject.Length; i++)
                context.IObject.Add(new KTSM { Kilometers = iobject[i].Item1, Meters = iobject[i].Item2 });
            return context;
        }
        public Range readFile(string path)
        {
            //Create COM Objects.
            Application excelApp = new Application();
            Workbook excelBook = excelApp.Workbooks.Open(path);
            _Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;
            //excelApp.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            return excelRange;
        }
        public (int, int) getKm()
        {
            Range excelRange = readFile(@"D:\hak\Killometrazh.xlsx");
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            var startKm = (int)excelRange.Cells[1, 1].Value2;
            var endKm = (int)excelRange.Cells[1, 2].Value2;
            //after reading, relaase the excel project
            return (startKm, endKm);
        }
        public (int, int)[] getIObject()
        {
            Range excelRange = readFile(@"D:\hak\3_Komplexy_tekhnicheskikh_sredstv_monitoringa_KTSM.xlsx");
            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            var km = new (int, int)[rows];
            for (int i = 1; i <= rows; i++)
            {
                if (excelRange.Cells[i, 1] != null && excelRange.Cells[i, 1].Value2 != null)
                    km[i].Item1 = (int)excelRange.Cells[i, 1].Value2;
                if (excelRange.Cells[i, 2] != null && excelRange.Cells[i, 2].Value2 != null)
                    km[i].Item2 = (int)excelRange.Cells[i, 2].Value2;

            }
            //after reading, relaase the excel project
            return km;

        }
    }
}