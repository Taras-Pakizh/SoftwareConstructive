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
        private MediaElement _GameMusic;
        private MediaElement _MenuMusic;
        private MediaElement _MenuMouseOverSound;

        private Maze maze;

        public MainWindow()
        {
            InitializeComponent();
            _MediaInit();
            _GameMusic.Play();
        }

        private void _DrawMaze()
        {

            var path = PathCreator.GetWallPath();
            maze = new KruskalAlgorithm().CreateMaze(10, 10, 5);
            CanvasInfo info = new CanvasInfo(BackgroundCanvas.ActualWidth, BackgroundCanvas.ActualHeight);
            path.Data = PathGeometryCreator.DrawLabirinth(maze, info);
            MyCanvas.Children.Add(path);
            MyCanvas.Margin = new Thickness((BackgroundCanvas.ActualWidth - BackgroundCanvas.ActualHeight) / 2, 0, 0, 0);
        }

        private void _DrawMaze(Maze loadMaze)
        {
            maze = loadMaze;
            MyCanvas.Children.Clear();
            var path = PathCreator.GetWallPath();
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

            _LoadGridSave();

            StackPanel_SaveMenu.Visibility = Visibility.Visible;
        }

        private void _LoadGridSave()
        {
            MementoCareTaker careTaker = new MementoCareTaker();
            List<SaveListElement> list = new List<SaveListElement>();
            foreach (var item in careTaker.mementos)
            {
                list.Add(new SaveListElement(item));
            }
            DataGrid_SavedGames.ItemsSource = list;
        }

        private void _LoadGridLoad()
        {
            MementoCareTaker careTaker = new MementoCareTaker();
            List<SaveListElement> list = new List<SaveListElement>();
            foreach (var item in careTaker.mementos)
            {
                list.Add(new SaveListElement(item));
            }
            DataGrid_LoadGames.ItemsSource = list;
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_LoadGames.Visibility = Visibility.Visible;

            _LoadGridLoad();

            StackPanel_Menu.Visibility = Visibility.Hidden;
        }

        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            if (maze == null)
                return;
            string name = EditSaveName.Text;
            DateTime dateTime = DateTime.Now;
            var memento = maze.Save(name);
            BinaryFormatter formatter = new BinaryFormatter();
            MementoCareTaker careTaker = new MementoCareTaker();
            careTaker.mementos.Add(memento);
            using (FileStream fs = new FileStream(MementoCareTaker.SavePath + MementoCareTaker.SaveName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, careTaker.mementos);
            }
            _LoadGridSave();
        }

        private void Button_ExitLoadMenu_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_Menu.Visibility = Visibility.Visible;
            StackPanel_LoadGames.Visibility = Visibility.Hidden;
        }

        private void Button_LoadGame_Click(object sender, RoutedEventArgs e)
        {
            string name = EditLoadName.Text;
            MementoCareTaker careTaker = new MementoCareTaker();
            if (careTaker.mementos.Find(x => x.Name == name) != null)
            {
                _DrawMaze(Maze.Load(careTaker.mementos.Find(x => x.Name == name)));
            }
            Button_ExitLoadMenu_Click(this, null);
        }
    }
}
