using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class CanvasInfo
    {
        public double Width { get; private set; }
        public double Heigth { get; private set; }
        
        public double WidthCenter
        {
            get { return Width / 2; }
        }
        public double HeigthCenter
        {
            get { return Heigth / 2; }
        }

        public CanvasInfo(double width, double heigth, double step)
        {
            Width = width;
            Heigth = heigth;
        }
    }
}
