using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public static class Extentions
    {
        public static CellPoint GetCellPoint(this Maze maze, Cell cell)
        {
            for (int row = 0; row < maze.Rows; ++row)
                for (int col = 0; col < maze.Columns; ++col)
                    if ((object)maze[row, col] == (object)cell)
                        return new CellPoint(row, col);
            return new CellPoint(-1, -1);
        }

        public static CellPoint RandomCellPoint(this Maze maze, Random random)
        {
            CellPoint point;
            do
            {
                int row = random.Next(0, maze.Rows);
                int col = random.Next(0, maze.Columns);
                point = new CellPoint(row, col);
                var points = maze.characters.Select(x => x.location.location).ToList();
                if (points.Contains(point))
                    continue;
            }
            while (false);
            return point;
        }
    }
}
