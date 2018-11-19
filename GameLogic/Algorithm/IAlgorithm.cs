using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public interface IAlgorithm
    {
        Maze CreateMaze(int rows, int cols, object info);
    }
}
