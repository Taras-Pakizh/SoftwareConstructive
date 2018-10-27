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
        }

        /// <summary>
        /// Check if exists closed cells 
        /// </summary>
        static void WhereUsage()
        {
            
        }
    }
}
