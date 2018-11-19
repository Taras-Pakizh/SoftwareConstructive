using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace MyGame.ViewModels
{
    public class SaveListElement:ViewModelBase
    {
        private string _name { get; set; }
        private DateTime _timeOfSaving { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public DateTime DateAndTime
        {
            get { return _timeOfSaving; }
            set
            {
                _timeOfSaving = value;
                OnPropertyChanged("DateAndTime");
            }
        }

        public SaveListElement() { }

        public SaveListElement(MazeMemento memento)
        {
            _name = memento.Name;
            _timeOfSaving = memento.DateAndTime;
        }
    }
}
