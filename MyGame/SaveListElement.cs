using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace MyGame
{
    public class SaveListElement
    {
        public string Name { get; set; }
        public DateTime TimeOfSaving { get; set; }

        public SaveListElement() { }

        public SaveListElement(MazeMemento memento)
        {
            Name = memento.Name;
            TimeOfSaving = memento.DateAndTime;
        }
    }
}
