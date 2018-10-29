using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class CharacterEventArgs:EventArgs
    {
        public string Massege { get; set; }
        public Cell prevCell { get; set; }
        public Cell nextCell { get; set; }
        public Direction dir { get; set; }

        public override string ToString()
        {
            return Massege + ' ' + prevCell.location.ToString() + ' ' + dir.ToString() + ' ' + nextCell.location.ToString();
        }
    }
}
