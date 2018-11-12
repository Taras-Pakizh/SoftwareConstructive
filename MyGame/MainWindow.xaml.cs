﻿using System;
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

        private void _DrawMaze()
        {

            var path = PathCreator.GetWallPath();

            Maze maze = new KruskalAlgorithm().CreateMaze(10, 10, 5);

            CanvasInfo info = new CanvasInfo(BackgroundCanvas.ActualWidth, BackgroundCanvas.ActualHeight);

            path.Data = PathGeometryCreator.DrawLabirinth(maze, info);

            MyCanvas.Children.Add(path);

            MyCanvas.Margin = new Thickness((BackgroundCanvas.ActualWidth - BackgroundCanvas.ActualHeight) / 2, 0, 0, 0);
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
            _MenuMouseOverSound.Source = new Uri("D://LP/LP_5_semester/Designig of Sortware/Labs/MyGame/Resources/Music/game_menu_select.wav");
            _GameMusic.Source = new Uri("D://LP/LP_5_semester/Designig of Sortware/Labs/MyGame/Resources/Music/IlCostruttoreDiPonti.mp3");
            _MenuMusic.Source = new Uri("D://LP/LP_5_semester/Designig of Sortware/Labs/MyGame/Resources/Music/MenuMusic.m4a");
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            KeyControl(e.Key);
        }

        private void KeyControl(Key key)
        {
            switch (key)
            {
                case Key.Escape:
                    _ShowMenu();
                    break;
            }
        }

        private void _ShowMenu()
        {
            if (StackPanel_SaveMenu.Visibility == Visibility.Visible)
                return;
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

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
            _DrawMaze();
            KeyControl(Key.Escape);
        }

        private void Button_Resume_Click(object sender, RoutedEventArgs e)
        {
            KeyControl(Key.Escape);
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_ExitSaveMenu_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_SaveMenu.Visibility = Visibility.Hidden;
            StackPanel_Menu.Visibility = Visibility.Visible;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_Menu.Visibility = Visibility.Hidden;
            StackPanel_SaveMenu.Visibility = Visibility.Visible;
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
