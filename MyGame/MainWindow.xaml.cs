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
using MyGame.ViewModels;
using System.Collections.ObjectModel;
using AutoMapper;
using Ninject;
using Ninject.Parameters;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameMusic _music;
        private Maze _maze;
        private MementoCareTaker _careTaker;
        private SaveList _saveList;
        private IKernel kernel;

        public MainWindow()
        {
            InitializeComponent();
            _music = new GameMusic();
            _music.Play(MusicType.GameMusic);

            kernel = new StandardKernel(new NinjectRegistration());

            _careTaker = new MementoCareTaker();

            Mapper.Initialize(x => x.CreateMap<MazeMemento, SaveListElement>());
            _saveList = new SaveList()
            {
                Elements = Mapper.Map<IEnumerable<MazeMemento>, ObservableCollection<SaveListElement>>(_careTaker.mementos)
            };
        }

        #region Logic

        private void _DrawMaze()
        {
            _maze = kernel.Get<Maze>(new NinjectArguments(15, 15, 5).GetValues());
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
            var path = kernel.Get<System.Windows.Shapes.Path>("Wall Path");
            CanvasInfo info = new CanvasInfo(BackgroundCanvas.ActualWidth, BackgroundCanvas.ActualHeight);
            path.Data = kernel.Get<PathGeometry>(new NinjectArguments(currentMaze, info).GetValues());
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

        private ObservableCollection<SaveListElement> _LoadSaveListElements(MementoCareTaker taker)
        {
            var config = Mapping.Mapping.CreateMapper_Memento_to_SaveListElement();
            return config.Map<IEnumerable<MazeMemento>, ObservableCollection<SaveListElement>>(taker.mementos);
        }

        private void _DeleteSaving(int index)
        {
            if (index == -1)
                return;
            _careTaker.RemoveAt(index);
            _saveList.Elements = _LoadSaveListElements(_careTaker);
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
            DataGrid_SavedGames.ItemsSource = _LoadSaveListElements(_careTaker);
            StackPanel_SaveMenu.Visibility = Visibility.Visible;
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            StackPanel_LoadGames.Visibility = Visibility.Visible;
            _saveList.Elements = _LoadSaveListElements(_careTaker);
            DataGrid_LoadGames.ItemsSource = _saveList.Elements;
            StackPanel_Menu.Visibility = Visibility.Hidden;
        }

        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            if (_maze == null)
                return;
            var memento = _maze.Save(EditSaveName.Text);
            _careTaker.Add(memento);
            _saveList.Elements = _LoadSaveListElements(_careTaker);

            DataGrid_SavedGames.ItemsSource = _saveList.Elements;
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
            _DrawMaze(Maze.Load(_careTaker.mementos[index]));
            Button_ExitLoadMenu_Click(this, null);
            Button_Resume_Click(this, null);
        }

        private void Button_DeleteSavedGame_Click(object sender, RoutedEventArgs e)
        {
            _DeleteSaving(DataGrid_SavedGames.SelectedIndex);
            DataGrid_SavedGames.ItemsSource = _saveList.Elements;
        }

        private void Button_DeleteLoadGame_Click(object sender, RoutedEventArgs e)
        {
            _DeleteSaving(DataGrid_LoadGames.SelectedIndex);
            DataGrid_LoadGames.ItemsSource = _saveList.Elements;
        }

        #endregion


    }
}
