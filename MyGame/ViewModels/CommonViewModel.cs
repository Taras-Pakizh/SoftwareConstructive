using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GameLogic;
using Ninject;

using Path = System.Windows.Shapes.Path;

namespace MyGame.ViewModels
{
    class CommonViewModel:ViewModelBase
    {
        #region Model

        private Maze _maze;
        private IKernel _kernel;

        #endregion

        public CommonViewModel()
        {
            _kernel = new StandardKernel(new NinjectRegistration());
            _visiblePanel = VisibilityPanels.Game;
        }

        #region Properties

        private VisibilityPanels _visiblePanel;
        public VisibilityPanels VisiblePanel
        {
            get { return _visiblePanel; }
            set
            {
                _visiblePanel = value;
                OnPropertyChanged(nameof(VisiblePanel));
            }
        }

        private double _canvasWidth;
        public double CanvasWidth
        {
            get { return _canvasWidth; }
            set
            {
                _canvasWidth = value;
                OnPropertyChanged(nameof(CanvasWidth));
            }
        }

        private double _canvasHeight;
        public double CanvasHeight
        {
            get { return _canvasHeight; }
            set
            {
                _canvasHeight = value;
                OnPropertyChanged(nameof(CanvasHeight));
            }
        }

        private Path _mazePath;
        public Path MazePath
        {
            get { return _mazePath; }
            set
            {
                _mazePath = value;
                OnPropertyChanged(nameof(MazePath));
            }
        } 

        #endregion

        #region Commands

        private Command _visibilityChange;
        public ICommand VisibilityChange
        {
            get
            {
                if (_visibilityChange != null)
                    return _visibilityChange;
                _visibilityChange = new Command(_VisibilityChange);
                return _visibilityChange;
            }
        }

        private Command _exitGame;
        public ICommand ExitGame
        {
            get
            {
                if (_exitGame != null)
                    return _exitGame;
                _exitGame = new Command(_ShutDown);
                return _exitGame;
            }
        }

        private Command _newGame;
        public ICommand NewGame
        {
            get
            {
                if (_newGame != null)
                    return _newGame;
                _newGame = new Command(_NewGame);
                return _newGame;
            }
        }

        #endregion

        #region CommandExecute

        private void _VisibilityChange(object obj)
        {
            if(obj == null)
                switch (VisiblePanel)
                {
                    case VisibilityPanels.Game:
                        VisiblePanel = VisibilityPanels.MainMenu;
                        break;
                    case VisibilityPanels.LoadMenu:
                        VisiblePanel = VisibilityPanels.Game;
                        break;
                    case VisibilityPanels.MainMenu:
                        VisiblePanel = VisibilityPanels.Game;
                        break;
                    case VisibilityPanels.SaveMenu:
                        VisiblePanel = VisibilityPanels.Game;
                        break;
                }
            else if(Enum.TryParse((string)obj, out VisibilityPanels panel))
            {
                VisiblePanel = panel;
            }
        }

        private void _ShutDown(object obj)
        {
            Application.Current.Shutdown();
        }
        
        private void _NewGame(object obj)
        {
            _VisibilityChange(VisibilityPanels.Game.ToString());
            _maze = _kernel.Get<Maze>(new NinjectArguments(15, 15, 5).GetValues());
            var path = _kernel.Get<System.Windows.Shapes.Path>("Wall Path");
            var info = new CanvasInfo(CanvasWidth, CanvasHeight);
            path.Data = _kernel.Get<PathGeometry>(new NinjectArguments(_maze, info).GetValues());
            MazePath = path;
        }

        #endregion
    }
}
