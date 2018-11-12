using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    [Serializable]
    public class Player : Character
    {
        public Player(Cell cell)
        {
            location = cell;
            HP = 100;
        }
    }
}
