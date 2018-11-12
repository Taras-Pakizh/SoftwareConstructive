using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using GameLogic;

namespace MyGame
{
    static class PathGeometryCreator
    {
        public static PathGeometry DrawLabirinth(Maze maze, CanvasInfo info)
        {
            PathGeometry geometry = new PathGeometry();

            var walls = _GetWallsInfo(maze, info);
            foreach(var wall in walls)
            {
                geometry.Figures.Add(_GetWallFigure(wall));
            }

            return geometry;
        }

        private static List<Wall> _GetWallsInfo(Maze maze, CanvasInfo info)
        {

        }

        private static PathFigure _GetWallFigure(Wall walls)
        {

        }

        private static void test()
        {
            PathGeometry geometry = new PathGeometry();
            PathFigure Wall = new PathFigure()
            {
                StartPoint = new Point(50, 50)
            };

            var polyline = new PolyLineSegment(new List<Point>
            {
                new Point(200, 50),
                new Point(200, 90),
                new Point(50, 90)
            }, true);

            Wall.Segments.Add(polyline);

            geometry.Figures.Add(Wall);

            return geometry;
        }
    }
}
