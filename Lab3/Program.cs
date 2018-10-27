using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

namespace Lab3Ling
{
    class Program
    {
        private static Maze maze;

        static void Main(string[] args)
        {
            maze = new KruskalAlgorithm().CreateMaze(10, 10, new object());
            PrintMaze();
        }

        static void PrintMaze()
        {
            var cells = maze.GetCells();
            foreach (var row in cells)
                foreach (var cell in row)
                {
                    StringBuilder builder = new StringBuilder();
                    if (cell.Down != null)
                        builder.Append('_');
                    else builder.Append(' ');
                    if (cell.Right != null)
                        builder.Append('|');
                    else builder.Append(' ');
                    Console.WriteLine(builder.ToString());
                }
        }

        /// <summary>
        /// Check if exists closed cells 
        /// </summary>
        static void WhereUsage()
        {
            var cells = maze.GetCells();

        }
    }
}
