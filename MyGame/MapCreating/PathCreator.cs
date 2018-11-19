using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyGame
{
    static class PathCreator
    {
        public static Path GetWallPath()
        {
            Path path = new Path();
            path.StrokeThickness = 0;
            var imageBrush = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + @"\Resources\Pictures\wall3.png")));
            imageBrush.Viewport = new System.Windows.Rect(0, 0, 32, 32);
            imageBrush.ViewportUnits = BrushMappingMode.Absolute;
            imageBrush.TileMode = TileMode.Tile;
            path.Fill = imageBrush;
            return path;
        } 
    }
}
