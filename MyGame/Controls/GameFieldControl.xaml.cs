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

namespace MyGame.Controls
{
    /// <summary>
    /// Логика взаимодействия для GameFieldControl.xaml
    /// </summary>
    public partial class GameFieldControl : UserControl
    {
        public GameFieldControl()
        {
            InitializeComponent();
        }

        static GameFieldControl()
        {
            WidthBackgroundProperty = DependencyProperty.Register(nameof(WidthInfo),
                typeof(double), typeof(GameFieldControl));
            HeightBackgroundProperty = DependencyProperty.Register(nameof(HeightInfo),
                typeof(double), typeof(GameFieldControl));
            MazeProperty = DependencyProperty.Register(nameof(Maze),
                typeof(Path), typeof(GameFieldControl), new PropertyMetadata(null, OnMazeChanged));
        }

        public static readonly DependencyProperty WidthBackgroundProperty;
        public double WidthInfo
        {
            get { return (double)GetValue(WidthBackgroundProperty); }
            set { SetValue(WidthBackgroundProperty, value); }
        }

        public static readonly DependencyProperty HeightBackgroundProperty;
        public double HeightInfo
        {
            get { return (double)GetValue(HeightBackgroundProperty); }
            set { SetValue(HeightBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MazeProperty;
        public Path Maze
        {
            get { return (Path)GetValue(MazeProperty); }
            set { SetValue(MazeProperty, value); }
        }

        private void BackgroundCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            WidthInfo = BackgroundCanvas.ActualWidth;
            HeightInfo = BackgroundCanvas.ActualHeight;
        }

        public static void OnMazeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var field = obj as GameFieldControl;
            if (field == null)
                throw new Exception("Fuck its not GameFieldControl");
            var path = args.NewValue as Path;
            if (path == null)
                throw new Exception("Fuck its not a Path");
            
            field.MyCanvas.Children.Clear();
            field.MyCanvas.Children.Add(path);
            field.MyCanvas.Margin = new Thickness((field.BackgroundCanvas.ActualWidth - field.BackgroundCanvas.ActualHeight) / 2, 0, 0, 0);
        }
    }
}
