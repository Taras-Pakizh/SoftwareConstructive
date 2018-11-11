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

using GameLogic;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaElement _GameMusic;
        private MediaElement _MenuMusic;
        private MediaElement _MenuMouseOverSound;

        public MainWindow()
        {
            InitializeComponent();
            _MediaInit();
            _GameMusic.Play();
        }

        private void _MediaInit()
        {
            _MenuMouseOverSound = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual
            };
            _GameMusic = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual
            };
            _MenuMusic = new MediaElement()
            {
                LoadedBehavior = MediaState.Manual,
                UnloadedBehavior = MediaState.Manual
            };
            _MenuMouseOverSound.Source = new Uri("D://LP/LP_5_semester/Designig of Sortware/Labs/MyGame/game_menu_select.wav");
            _GameMusic.Source = new Uri("D://LP/LP_5_semester/Designig of Sortware/Labs/MyGame/IlCostruttoreDiPonti.mp3");
            _MenuMusic.Source = new Uri("D://LP/LP_5_semester/Designig of Sortware/Labs/MyGame/MenuMusic.m4a");
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
            {
                StackPanel_Menu.Visibility = Visibility.Visible;
                _GameMusic.Stop();
                _MenuMusic.Play();
            }
            else
            {
                StackPanel_Menu.Visibility = Visibility.Hidden;
                _MenuMusic.Stop();
                _GameMusic.Play();
            }
        }

        private void Button_MenuMouseEnter(object sender, MouseEventArgs e)
        {
            _MenuMouseOverSound.Position = TimeSpan.FromSeconds(0);
            _MenuMouseOverSound.Play();
        }
    }
}
