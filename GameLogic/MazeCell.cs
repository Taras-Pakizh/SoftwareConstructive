using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class MazeCell:Cell
    {
        public MazeCell(int _id = 0)
        {
            Id = _id;
            connections = new Cell[4];
        }

        public MazeCell(int row, int col, int _id = 0)
        {
            location = new CellPoint(row, col);
            Id = _id;
            connections = new Cell[4];
        }
    }
}
