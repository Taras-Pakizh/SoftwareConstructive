using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab3Ling
{
    class Program
    {
        private static Maze maze;

        static void Main(string[] args)
        {
            //maze = new KruskalAlgorithm().CreateMaze(25, 25, 99);
            //PrintMaze();
            //PrintIdMaze();

            //maze = new KruskalAlgorithm().CreateMaze(3, 3, 3);

            BinaryFormatter formatter = new BinaryFormatter();

            List<MazeMemento> list = new List<MazeMemento>();
            list.Add(new MazeMemento("Hello", "World"));
            

            using (FileStream fs = new FileStream(@"D:\LP\LP_5_semester\Designig of Sortware\Labs\MyGame\Resources\Saves\Mementos.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);

                Console.WriteLine("Объект сериализован");
            }

            MementoCareTaker careTaker = new MementoCareTaker();
            Console.WriteLine(careTaker.mementos[0].Name);

            //// десериализация из файла people.dat
            //using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            //{
            //    maze = (Maze)formatter.Deserialize(fs);

            //    Console.WriteLine("Объект десериализован");
                
            //}

            //PrintMaze();

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
