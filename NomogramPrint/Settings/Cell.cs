using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomogramPrint
{
    // Составляющие целой ячейки километра.
    public class Cell
    {

        public Cell(float wrapHeight) :
            this(wrapHeight, CellContentType.None) { }

        public Cell(float wrapHeight, CellContentType contentType)
        {
            ContentType = contentType;
            WrapHeight = wrapHeight;
        }

        public CellContentType ContentType { get; set; }
        public float WrapHeight { get; set; }
    }

    // На основе типа будут методы отрисовки
    // пока сыро.
    public enum CellContentType
    {
        Number,
        Objects,
        None
    }
}
