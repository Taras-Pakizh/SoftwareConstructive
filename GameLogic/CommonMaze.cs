using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class CommonMaze:Maze
    {
        /// <summary>
        /// Creating cells but not connecting them
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public CommonMaze(int rows, int cols)
        {
            cells = new MazeCell[rows][];
            for (int i = 0; i < cells.Length; ++i)
                cells[i] = new MazeCell[cols];
            for (int i = 0; i < cells.Length; ++i)
                for (int j = 0; j < cells[0].Length; ++j)
                    cells[i][j] = new MazeCell();

            for (int i = 0; i < cells[0].Length; ++i)
            {
                cells[0][i].Up = NotCell.GetInstance();
                cells[cells.Length - 1][i].Down = NotCell.GetInstance();
            }
            for(int i = 0; i < cells.Length; ++i)
            {
                cells[i][0].Left = NotCell.GetInstance();
                cells[i][cells[0].Length - 1] = NotCell.GetInstance();
            }
        }
        public CommonMaze(Cell[][] _cells)
        {
            cells = new MazeCell[_cells.Length][];
            for (int i = 0; i < cells.Length; ++i)
                cells[i] = new MazeCell[_cells[0].Length];
            for (int i = 0; i < cells.Length; ++i)
                for (int j = 0; j < cells[0].Length; ++j)
                    cells[i][j] = new MazeCell(_cells[i][j].Id);
        }
    }
}
