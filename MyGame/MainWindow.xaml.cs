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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameMusic _music;
        private Maze _maze;

        public MainWindow()
        {
            InitializeComponent();
            _music = new GameMusic();
            _music.Play(MusicType.GameMusic);
        }

        #region Logic

        private void _DrawMaze()
        {
            _maze = new KruskalAlgorithm().CreateMaze(10, 10, 5);
            _ConvertMaze_Canvas(_maze);
        }

        private void _DrawMaze(Maze loadMaze)
        {
            _maze = loadMaze;
            _ConvertMaze_Canvas(_maze);
        }

        private void _ConvertMaze_Canvas(Maze currentMaze)
        {
            MyCanvas.Children.Clear();
            var path = PathCreator.GetWallPath();
            CanvasInfo info = new CanvasInfo(BackgroundCanvas.ActualWidth, BackgroundCanvas.ActualHeight);
            path.Data = PathGeometryCreator.DrawLabirinth(currentMaze, info);
            MyCanvas.Children.Add(path);
            MyCanvas.Margin = new Thickness((BackgroundCanvas.ActualWidth - BackgroundCanvas.ActualHeight) / 2, 0, 0, 0);
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
                _music.Stop(MusicType.GameMusic);
                _music.Play(MusicType.MenuMusic);
            }
            else
            {
                StackPanel_Menu.Visibility = Visibility.Hidden;
                _music.Stop(MusicType.MenuMusic);
                _music.Play(MusicType.GameMusic);
            }
        }

        private List<SaveListElement> _LoadSaveListElements()
        {
            MementoCareTaker careTaker = new MementoCareTaker();
            List<SaveListElement> list = new List<SaveListElement>();
            foreach (var item in careTaker.mementos)
            {
                list.Add(new SaveListElement(item));
            }
            return list;
        }

        #endregion

        #region Events

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            KeyControl(e.Key);
        }

        private void Button_MenuMouseEnter(object sender, MouseEventArgs e)
        {
            _music.Play(MusicType.MenuItemMusic);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
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
            DataGrid_SavedGames.ItemsSource = _LoadSaveListElements();
            StackPanel_SaveMenu.Visibility = Visibility.Visible;
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_LoadGames.Visibility = Visibility.Visible;
            DataGrid_LoadGames.ItemsSource = _LoadSaveListElements();
            StackPanel_Menu.Visibility = Visibility.Hidden;
        }

        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            if (_maze == null)
                return;
            string name = EditSaveName.Text;
            DateTime dateTime = DateTime.Now;
            var memento = _maze.Save(name);
            BinaryFormatter formatter = new BinaryFormatter();
            MementoCareTaker careTaker = new MementoCareTaker();
            careTaker.mementos.Add(memento);
            using (FileStream fs = new FileStream(MementoCareTaker.SavePath + MementoCareTaker.SaveName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, careTaker.mementos);
            }
            DataGrid_SavedGames.ItemsSource = _LoadSaveListElements();
        }

        private void Button_ExitLoadMenu_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_Menu.Visibility = Visibility.Visible;
            StackPanel_LoadGames.Visibility = Visibility.Hidden;
        }

        private void Button_LoadGame_Click(object sender, RoutedEventArgs e)
        {
            var index = DataGrid_LoadGames.SelectedIndex;
            if (index == -1)
                return;
            MementoCareTaker careTaker = new MementoCareTaker();
            _DrawMaze(Maze.Load(careTaker.mementos[index]));
            Button_ExitLoadMenu_Click(this, null);
            Button_Resume_Click(this, null);
        }

        #endregion
    }
}
