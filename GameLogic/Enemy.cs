using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Enemy:Character, IEnemy
    {
        public Enemy(Cell cell)
        {
            location = cell;
            HP = 100;
        }

        public IHuntingAlgorithm algorithm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Hunt()
        {
            throw new NotImplementedException();
        }
    }
}
