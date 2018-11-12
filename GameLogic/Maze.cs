using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameLogic
{
    [Serializable]
    public abstract class Maze
    {
        //Vars
        protected Cell[][] cells;
        public List<Character> characters;
        public Player player;
        public Dictionary<CellPoint, Character> characterDictionry;

        //Properties
        public int Rows
        {
            get { return cells.Length; }
        }
        public int Columns
        {
            get { return cells[0].Length; }
        }
        public Cell this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                    throw new IndexOutOfRangeException();
                return cells[row][col];
            }
        }
        public Cell this[CellPoint point]
        {
            get
            {
                if (point.Row < 0 || point.Row >= Rows || point.Column < 0 || point.Column >= Columns)
                    throw new IndexOutOfRangeException();
                return cells[point.Row][point.Column];
            }
        }


        /// <summary>
        /// Its not copy
        /// </summary>
        /// <returns></returns>
        public Cell[][] GetCells()
        {
            return cells;
        }

        public MazeMemento Save(string Name)
        {
            string path = MementoCareTaker.SavePath;
            path += Name + ".dat";
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
            return new MazeMemento(Name, path);
        }
    }
}
