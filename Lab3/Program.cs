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
            maze = new KruskalAlgorithm().CreateMaze(50, 50, 99);
            PrintMaze();
            PrintIdMaze();
            Console.ReadKey();
        }

        static void PrintMaze()
        {
            var cells = maze.GetCells();
            foreach (var row in cells)
            {
                foreach (var cell in row)
                {
                    StringBuilder builder = new StringBuilder();
                    if (cell.Down == null || cell.Down is NotCell)
                        builder.Append('_');
                    else builder.Append(' ');
                    if (cell.Right == null || cell.Right is NotCell)
                        builder.Append('|');
                    else builder.Append(' ');
                    Console.Write(builder.ToString());
                }
                Console.WriteLine();
            }
        }

        static void PrintIdMaze()
        {
            var cells = maze.GetCells();
            foreach(var row in cells)
            {
                foreach(var cell in row)
                {
                    Console.Write(cell.Id + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
