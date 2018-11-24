using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.ViewModels
{
    class PlayerModelView:ViewModelBase
    {
        private int _HP;
        private Cell _location;
        private int _minimun;
        private int _maximun;

        public int HP
        {
            get { return _HP; }
            set
            {
                _HP = value;
                OnPropertyChanged("HP");
            }
        }

        public Cell Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged("Location");
            }
        }

        public int Minimum
        {
            get { return _minimun; }
            set
            {
                _minimun = value;
                OnPropertyChanged("Minimum");
            }
        }

        public int Maximum
        {
            get { return _maximun; }
            set
            {
                _maximun = value;
                OnPropertyChanged("Maximum");
            }
        }
    }
}
