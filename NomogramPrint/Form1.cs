using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NomogramPrint.Drawing;
using NomogramPrint.Models;
using NomogramPrint.Servicies;

namespace NomogramPrint
{
    public partial class Form1 : Form
    {

        private DrawSettings _drawSettings;
        private Drawer _drawer;
        private ExcelParser _excelParser;
        private DbContext _context;

        public Form1()
        {
            InitializeComponent();

            var kilometerSettings = new KilometerSettings(30, 200, 400, Color.Black);
            kilometerSettings.Cells = new List<Cell>
            {
                new Cell(0.15f, CellContentType.None),
                new Cell(0.2f, CellContentType.None),
                new Cell(0.2f, CellContentType.Number),
                new Cell(0.45f, CellContentType.Objects)
            };
            _drawSettings = new DrawSettings(kilometerSettings);
            _drawer = new Drawer(_drawSettings);

            _excelParser = new ExcelParser();
            _context = _excelParser.GetData();
           
        }

        private Point GetTopPoint(Point point) =>
            new Point(point.X + point.Y, 0);


        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            var test = new Bitmap(4000, 1000);

            using (Graphics gr = Graphics.FromImage(test))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                _drawer.DrawKilometers(gr, _context.Kilometers);
                
            }

            var img = (Image)test;
            
            img.Save("test.png");
            CreateGraphics().DrawImage(img, new Point(0, 0));

        }

    }
}
