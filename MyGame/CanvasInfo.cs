using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GameLogic;

namespace MyGame
{
    class CanvasInfo
    {
        public double Width { get; private set; }
        public double Heigth { get; private set; }
        public Point StartPoint { get; private set; }
        public double CellSize { get; private set; }
        public double Margin { get; private set; }
        
        public double WidthCenter
        {
            get { return Width / 2; }
        }
        public double HeigthCenter
        {
            get { return Heigth / 2; }
        }
        public double WallSize
        {
            get { return (Margin - CellSize) / 2; }
        }

        public CanvasInfo(double width, double heigth)
        {
            Width = width;
            Heigth = heigth;
        }

        public CanvasInfo ModifyWithCanvas(Maze maze)
        {
            var result = new CanvasInfo(Width, Heigth);
            result.Margin = Heigth / (maze.Rows + 2);
            result.StartPoint = new Point()
            {
                X = result.Margin,
                Y = result.Margin
            };
            result.CellSize = (3 * result.Margin) / 4;
            return result;
        }
    }
}
