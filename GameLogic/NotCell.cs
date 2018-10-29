using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class NotCell:Cell
    {
        private static NotCell instance;
        
        public static NotCell GetInstance()
        {
            if (instance == null)
                instance = new NotCell();
            return instance;
        }

        private NotCell() { }
    }
}
