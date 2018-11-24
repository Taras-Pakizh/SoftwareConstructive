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
    }
}
