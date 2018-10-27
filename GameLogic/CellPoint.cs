using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class CellPoint
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public CellPoint(int row, int col)
        {
            Row = row;
            Column = col;
        }

        public override bool Equals(object obj)
        {
            var point = obj as CellPoint;
            return point != null &&
                   Row == point.Row &&
                   Column == point.Column;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator==(CellPoint thisPoint, CellPoint otherPoint)
        {
            return thisPoint.Equals(otherPoint);
        }
        public static bool operator!=(CellPoint thisPoint, CellPoint otherPoint)
        {
            return !thisPoint.Equals(otherPoint);
        }
    }
}
