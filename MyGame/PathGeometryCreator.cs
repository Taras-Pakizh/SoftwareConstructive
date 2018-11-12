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
            var newInfo = info.ModifyWithCanvas(maze);

            var walls = _GetMazePaths(maze, newInfo);
            foreach(var wall in walls)
            {
                geometry.Figures.Add(_GetPathFigure(wall));
            }

            return geometry;
        }

        private static List<MazePath> _GetMazePaths(Maze maze, CanvasInfo info)
        {
            if (info.StartPoint == null || info.CellSize <= 0 || info.Margin <= 0)
                throw new MissingFieldException();

            var horizontal = _Convert_HorizontalPathInfo(_GetHorizontalPathInfo(maze, info), info);
            var vertical = _Convert_VerticalPathInfo(_GetVerticalPathInfo(maze, info), info);

            horizontal.AddRange(vertical);
            return horizontal;
        }
        private static Dictionary<CellPoint, CellPoint> _GetHorizontalPathInfo(Maze maze, CanvasInfo info)
        {
            if (info.StartPoint == null || info.CellSize <= 0 || info.Margin <= 0)
                throw new MissingFieldException();

            Dictionary<CellPoint, CellPoint> paths = new Dictionary<CellPoint, CellPoint>();
            foreach (var rowCell in maze.GetCells())
            {
                CellPoint point = rowCell[0].location;
                foreach (var cell in rowCell)
                {
                    if (point == null)
                        point = cell.location;
                    if (cell.Right == null || cell.Right is NotCell)
                    {
                        paths.Add(point, cell.location);
                        if (cell.Right is NotCell)
                            break;
                        point = null;
                    }
                }
            }
            return paths;
        }
        private static List<MazePath> _Convert_HorizontalPathInfo(Dictionary<CellPoint, CellPoint> paths, CanvasInfo info)
        {
            if (info.StartPoint == null || info.CellSize <= 0 || info.Margin <= 0)
                throw new MissingFieldException();

            List<MazePath> result = new List<MazePath>();
            foreach(var pair in paths)
            {
                MazePath path = new MazePath()
                {
                    point = new Point()
                    {
                        X = ((pair.Key.Column + 1) * info.Margin) + info.WallSize,
                        Y = ((pair.Key.Row + 1) * info.Margin) + info.WallSize
                    },
                    Width = ((pair.Value.Column - pair.Key.Column + 1) * info.Margin) - (info.WallSize * 2),
                    Height = info.CellSize
                };
                result.Add(path);
            }
            return result;
        }
        private static List<Cell> _GetVerticalPathInfo(Maze maze, CanvasInfo info)
        {
            if (info.StartPoint == null || info.CellSize <= 0 || info.Margin <= 0)
                throw new MissingFieldException();

            List<Cell> paths = new List<Cell>();
            foreach(var rowCell in maze.GetCells())
                foreach(var cell in rowCell)
                {
                    if (cell.Down is NotCell)
                        break;
                    if(cell.Down != null)
                        paths.Add(cell);
                }
            return paths;
        }
        private static List<MazePath> _Convert_VerticalPathInfo(List<Cell> cells, CanvasInfo info)
        {
            if (info.StartPoint == null || info.CellSize <= 0 || info.Margin <= 0)
                throw new MissingFieldException();

            List<MazePath> result = new List<MazePath>();
            foreach(var cell in cells)
            {
                MazePath path = new MazePath()
                {
                    point = new Point()
                    {
                        X = ((cell.location.Column + 1) * info.Margin) + info.WallSize,
                        Y = ((cell.location.Row + 2) * info.Margin) - info.WallSize
                    },
                    Width = info.CellSize,
                    Height = info.WallSize * 2
                };
                result.Add(path);
            }
            return result;
        }


        private static PathFigure _GetPathFigure(MazePath wall)
        {
            PathFigure Wall = new PathFigure()
            {
                StartPoint = wall.point
            };

            var polyline = new PolyLineSegment(new List<Point>
            {
                new Point(wall.point.X + wall.Width, wall.point.Y),
                new Point(wall.point.X + wall.Width, wall.point.Y + wall.Height),
                new Point(wall.point.X, wall.point.Y + wall.Height)
            }, true);

            Wall.Segments.Add(polyline);
            return Wall;
        }

        //private static void test()
        //{
        //    PathGeometry geometry = new PathGeometry();
        //    PathFigure Wall = new PathFigure()
        //    {
        //        StartPoint = new Point(50, 50)
        //    };

        //    var polyline = new PolyLineSegment(new List<Point>
        //    {
        //        new Point(200, 50),
        //        new Point(200, 90),
        //        new Point(50, 90)
        //    }, true);

        //    Wall.Segments.Add(polyline);

        //    geometry.Figures.Add(Wall);

        //    return geometry;
        //}
    }
}
