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
            var window = new TestWindow();
            window.DataContext = new CommonViewModel();
            window.Show();
        }
    }
}
