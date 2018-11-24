using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    [Serializable]
    public class Enemy : Character, IEnemy
    {
        public Enemy(Cell cell)
        {
            Location = cell;
            HP = 100;
        }

        public IHuntingAlgorithm algorithm { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Hunt()
        {
            throw new NotImplementedException();
        }
    }
}
