using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Enemy:Character
    {
        public Enemy(Cell cell)
        {
            location = cell;
            HP = 100;
        }
    }
}
