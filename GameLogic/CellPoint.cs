using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    [Serializable]
    public class CellPoint
    {
        public int Row { get; set; }
        public int Column { get; set; }

        private static CellPoint point;

        public CellPoint(int row, int col)
        {
            Row = row;
            Column = col;
        }

        public static CellPoint GetInstance()
        {
            if (point == null)
                point = new CellPoint(-1, -1);
            return point;
        }

        public override string ToString()
        {
            return "Row: " + Row + " Column: " + Column;
        }

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    var point = obj as CellPoint;
        //    return point != null &&
        //           Row == point.Row &&
        //           Column == point.Column;
        //}

        //public static bool operator ==(CellPoint first, CellPoint second)
        //{
        //    return first.Equals(second);
        //}

        //public static bool operator !=(CellPoint first, CellPoint second)
        //{
        //    return !first.Equals(second);
        //}
    }
}
