using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MyGame;

namespace MyGame.Converters
{
    class PositionToTexture : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Positions position = (Positions)value;
            string path = Environment.CurrentDirectory;
            switch (position)
            {
                case Positions.Front:
                    path += @"\Resources\Pictures\front.png";
                    break;
                case Positions.Left:
                    path += @"\Resources\Pictures\left.png";
                    break;
                case Positions.Down:
                    path += @"\Resources\Pictures\down.png";
                    break;
                case Positions.Right:
                    path += @"\Resources\Pictures\right.png";
                    break;
            }
            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
