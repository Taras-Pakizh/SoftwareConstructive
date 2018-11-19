using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using GameLogic;
using System.Windows.Shapes;
using Path = System.Windows.Shapes.Path;
using System.Windows.Media;

namespace MyGame
{
    class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            //Maze
            Bind<Maze>().ToMethod(x =>
            {
                int row = (int)x.Parameters.ElementAt(0).GetValue(x, x.Request.Target);
                int col = (int)x.Parameters.ElementAt(1).GetValue(x, x.Request.Target);
                object obj = x.Parameters.ElementAt(2).GetValue(x, x.Request.Target);

                return new KruskalAlgorithm().CreateMaze(row, col, obj);
            }).When(y => y.Parameters.Count == 3);

            //Maze
            Bind<Maze>().ToMethod(x => new KruskalAlgorithm().CreateMaze(10, 10, 5));

            //Path
            Bind<Path>().ToMethod(x => PathCreator.GetWallPath()).Named("Wall Path");

            //Pathgeometry
            Bind<PathGeometry>().ToMethod(x =>
            {
                Maze maze = (Maze)x.Parameters.ElementAt(0).GetValue(x, x.Request.Target);
                CanvasInfo info = (CanvasInfo)x.Parameters.ElementAt(1).GetValue(x, x.Request.Target);
                return PathGeometryCreator.DrawLabirinth(maze, info);
            }).When(y => y.Parameters.Count == 2);
        }
    }
}
