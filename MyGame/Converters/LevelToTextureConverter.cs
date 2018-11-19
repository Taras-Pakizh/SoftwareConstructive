using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyGame.Converters
{
    class LevelToTextureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            int level = (int)value;
            switch (level)
            {
                case 1:
                    result = Environment.CurrentDirectory + @"\Resources\Pictures\path.png";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
