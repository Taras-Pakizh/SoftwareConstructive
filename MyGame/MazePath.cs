using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyGame
{
    class MazePath
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Point point { get; set; }

        public MazePath() { }

        public MazePath(Point _point, double size)
        {
            point = _point;
            Width = size;
            Height = size;
        }

        public static MazePath operator +(MazePath first, MazePath second)
        {
            if (first.point.Y != second.point.Y)
                throw new Exception("Cant add this paths");
            return new MazePath()
            {
                point = first.point,
                Width = (second.point.X - first.point.X) + second.Width,
                Height = first.Height
            };
        }
    }
}
