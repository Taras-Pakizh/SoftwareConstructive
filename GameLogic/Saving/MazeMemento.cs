using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    [Serializable]
    public class MazeMemento
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public DateTime DateAndTime { get; private set; }

        public MazeMemento() { }

        public MazeMemento(string _Name, string _path)
        {
            Name = _Name;
            Path = _path;
            DateAndTime = DateTime.Now;
        }
    }
}
