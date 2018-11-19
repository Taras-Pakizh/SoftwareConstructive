using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.ViewModels
{
    class SaveList:ViewModelBase
    {
        private ObservableCollection<SaveListElement> _elements;

        public ObservableCollection<SaveListElement> Elements
        {
            get { return _elements; }
            set
            {
                _elements = value;
                OnPropertyChanged("Elements");
            }
        }
    }
}
