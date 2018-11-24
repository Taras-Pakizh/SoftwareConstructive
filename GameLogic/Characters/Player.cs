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
        private readonly int MinimumHP = 0;
        private readonly int MaximumHP = 100;

        public int Minimum
        {
            get { return MinimumHP; }
        }

        public int Maximum
        {
            get { return MaximumHP; }
        }

        public Player(Cell cell)
        {
            Location = cell;
            HP = 100;
        }
    }
}
