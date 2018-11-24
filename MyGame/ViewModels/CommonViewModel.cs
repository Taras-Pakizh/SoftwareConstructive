using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.ViewModels
{
    class CommonViewModel:ViewModelBase
    {
        private string _visiblePanel;

        public string VisiblePanel
        {
            get { return _visiblePanel; }
            set
            {
                _visiblePanel = value;
                OnPropertyChanged("VisiblePanel");
            }
        }

        
    }
}
