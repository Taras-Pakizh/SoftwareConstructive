using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public abstract class Cell:IEnumerable
    {
        //Vars
        protected Cell[] connections;

        //Properties
        public int Id { get; set; }
        public Cell Up
        {
            get { return connections[0]; }
            set { connections[0] = value; }
        }
        public Cell Right
        {
            get { return connections[1]; }
            set { connections[1] = value; }
        }
        public Cell Down
        {
            get { return connections[2]; }
            set { connections[2] = value; }
        }
        public Cell Left
        {
            get { return connections[3]; }
            set { connections[3] = value; }
        }


        //IEnuberable
        public IEnumerator GetEnumerator()
        {
            return connections.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return connections.GetEnumerator();
        }

        //Methods
        public Cell GetRelatedCell(Direction direction)
        {
            return connections[(int)direction];
        }
        public Cell GetRelatedCell(int WallId)
        {
            return connections[WallId];
        }
        public bool IsWalls()
        {
            foreach (var item in connections)
                if (item != null && item is Cell)
                    return true;
            return false;
        }

        public void ConnectCells(Cell cell, Direction dir)
        {
            connections[(int)dir] = cell;
            switch (dir)
            {
                case Direction.Up:
                    dir = Direction.Down;
                    break;
                case Direction.Right:
                    dir = Direction.Left;
                    break;
                case Direction.Down:
                    dir = Direction.Up;
                    break;
                case Direction.Left:
                    dir = Direction.Right;
                    break;
            }
            cell.connections[(int)dir] = this;
        }
        public void ConnectCells(Cell cell, int WallId)
        {
            ConnectCells(cell, (Direction)WallId);
        }
    }
}
