using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    _ShowMenu();
                    break;
            }
        }

        private void _ShowMenu()
        {
            if (StackPanel_Menu.Visibility == Visibility.Hidden)
                StackPanel_Menu.Visibility = Visibility.Visible;
            else StackPanel_Menu.Visibility = Visibility.Hidden;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
