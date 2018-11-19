using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    [Serializable]
    public abstract class Character
    {
        //Properties
        public Cell location { get; set; }
        public int HP { get; set; }

        //Events
        public event CharacterEventHandler move;

        public void Move(Direction dir)
        {
            var nextCell = location.GetRelatedCell(dir);
            if (nextCell == null || nextCell is NotCell)
                return;
            move.Invoke(this, new CharacterEventArgs() { Massege = "move", prevCell = location, nextCell = nextCell, dir = dir });
            location = nextCell;
        }
    }
}
