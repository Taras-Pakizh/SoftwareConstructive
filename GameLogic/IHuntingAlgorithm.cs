using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public interface IHuntingAlgorithm
    {
        Path FindPath(Maze maze, Character hunter, Character target);
    }
}
