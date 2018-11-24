using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MyGame.ViewModels;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.ShutdownMode = ShutdownMode.OnLastWindowClose;
            var window = new TestWindow();

            var viewmodel = new CommonViewModel();
            window.DataContext = viewmodel;
            viewmodel.PropertyChanged += window.UpdateView;

            window.Show();   
        }
    }
}
