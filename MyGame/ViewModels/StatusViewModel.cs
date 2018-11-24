using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.ViewModels
{
    class StatusViewModel:ViewModelBase
    {
        private PlayerModelView _player;

        public PlayerModelView Player
        {
            get { return _player; }
            set
            {
                _player = value;
                OnPropertyChanged("Player");
            }
        }
    }
}
