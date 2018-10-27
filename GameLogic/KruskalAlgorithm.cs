using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class KruskalAlgorithm : IAlgorithm
    {
        private Maze labyrinth;

        public Maze CreateMaze(int Row, int Col, object info)
        {
            labyrinth = new CommonMaze(Row, Col);
            Random random = new Random();
            int Sets = Row * Col;

            Cell CurrentCell;
            int row, col, NextId = 1;
            while (Sets > 1)
            {
                row = random.Next(0, labyrinth.Rows);
                col = random.Next(0, labyrinth.Columns);
                CurrentCell = labyrinth[row, col];
                if (CurrentCell.IsWalls())
                {
                    int WallId;
                    Cell cell;
                    do
                    {
                        WallId = random.Next(0, 4);
                        cell = GetNextCell(new CellPoint(row, col), (Direction)WallId);
                        if (CurrentCell.GetRelatedCell(WallId) == null && cell is Cell) break;
                    } while (true);
                    if (ConnectCells(CurrentCell, (Direction)WallId, cell))
                    {
                        UniteAllID(CurrentCell, CurrentCell.GetRelatedCell(WallId), ref NextId);
                        --Sets;
                    }
                }
                else continue;
            }
            return labyrinth;
        }

        //Methods
        private void UniteAllID(Cell first, Cell second, ref int NextId)
        {
            int Id1 = first.Id;
            int Id2 = second.Id;

            if (Id1 != 0 && Id2 != 0)
                for (int i = 0; i < labyrinth.Rows; ++i)
                    for (int j = 0; j < labyrinth.Columns; ++j)
                        if (labyrinth[i, j].Id == Id2) labyrinth[i, j].Id = Id1;

            if (Id1 == 0 && Id2 == 0)
            {
                first.Id = NextId;
                second.Id = NextId;
                ++NextId;
            }
            else if (Id1 == 0)
                first.Id = Id2;
            else if (Id2 == 0)
                second.Id = Id1;
        }
        private bool ConnectCells(Cell cell, Direction dir, Cell nextCell)
        {
            if (cell.Id == nextCell.Id)
                if (cell.Id != 0)
                    return false;
            cell.ConnectCells(nextCell, dir);
            return true;
        }
        private Cell GetNextCell(CellPoint point, Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    point.Row--;
                    if (point.Row < 0) return NotCell.GetInstance();
                    break;
                case Direction.Right:
                    point.Column++;
                    if (point.Column >= labyrinth.Columns) return NotCell.GetInstance();
                    break;
                case Direction.Down:
                    point.Row++;
                    if (point.Row >= labyrinth.Rows) return NotCell.GetInstance();
                    break;
                case Direction.Left:
                    point.Column--;
                    if (point.Column < 0) return NotCell.GetInstance();
                    break;
            }
            return labyrinth[point];
        }
    }
}
