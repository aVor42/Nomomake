using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NomogramPrint.Models;

namespace NomogramPrint
{
    public class KilometerDrawer
    {

        // point -  Левая верхняя часть ячейки
        // size -   Размеры ячейки
        private Dictionary<CellContentType, Action<Graphics, Kilometer, PointF, SizeF>> _cellsDrawing;

        public KilometerDrawer()
        {
            _cellsDrawing = new Dictionary<CellContentType,Action<Graphics, Kilometer,PointF, SizeF>>();
            _cellsDrawing[CellContentType.Number] = (graphics, kilometer, point, size) =>
            {
                var state = graphics.Save();

                graphics.TranslateTransform(point.X + size.Width / 2, point.Y + size.Height / 2);
                graphics.RotateTransform(270);

                var font = new Font(FontFamily.GenericSansSerif, 11, FontStyle.Regular);
                SizeF textSize = graphics.MeasureString(kilometer.Number.ToString(), font);
                graphics.DrawString(kilometer.Number.ToString(), font, Brushes.Black, -(textSize.Width / 2), -(textSize.Height / 2));
                graphics.Restore(state);
            };

            _cellsDrawing[CellContentType.Objects] = (graphics, kilometer, point, size) =>
            {

                foreach(var _object in kilometer.Objects)
                {
                    Bitmap objectImage;
                    switch (_object)
                    {
                        case KTSM ktsm:
                            objectImage = Resource1.ktsm;
                            break;
                        case UKSPS uksps:
                            objectImage = Resource1.uksps;
                            break;
                        default:
                            continue;
                    }
                    var state = graphics.Save();
                    graphics.TranslateTransform(point.X + size.Width / 2, point.Y + size.Height / 2);
                    graphics.DrawImage(objectImage, new PointF(-(objectImage.Width / 2), -(objectImage.Height / 2)));
                    graphics.Restore(state);
                }
                
            };

            _cellsDrawing[CellContentType.None] = (graphics, kilometer, point, size) => { };
        }

        public int Number { get; set; }
        

        private PointF GetTopDiagonalPoint(PointF bottomPoint)=>
            new PointF(bottomPoint.X + bottomPoint.Y, 0);


        // left - Номер пикселя с которого надо рисовать 
        public void DrawCell(float left, Graphics graphics, DrawSettings drawSettings, Kilometer kilometer)
        {

            var settings = drawSettings.KilometerSettings;
            var currentY = settings.Top;
            var cells = settings.Cells;
           
            
            foreach(var cell in cells)
            {
                var height = settings.Height * cell.WrapHeight;
                var width = settings.Width;

                using (var pen = new Pen(settings.Color, 1))
                    graphics.DrawRectangle(pen, left, currentY, width, height);

                _cellsDrawing[cell.ContentType](graphics, kilometer, new PointF(left, currentY), new SizeF(width, height));

                currentY += height;
            }
        }

        // left - Номер пикселя с которого надо рисовать 
        public void DrawDiagonal(float left, Graphics graphics, DrawSettings drawSettings)
        {
            var settings = drawSettings.KilometerSettings;

            var bottomPoint = new PointF(left + settings.Width, settings.Top);
            var topPoint = GetTopDiagonalPoint(bottomPoint);
            using (var pen = new Pen(settings.Color, 1))
                graphics.DrawLine(pen, bottomPoint, topPoint);
        }

    }
}
