using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public interface IEnemy
    {
        IHuntingAlgorithm algorithm { get; set; }
        void Hunt();
    }
}
