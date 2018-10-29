using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace GameLogic.Tests
{
    [TestClass()]
    public class KruskalAlgorithmTests
    {
        private Maze maze;

        [TestInitialize]
        public void Init()
        {
            maze = new KruskalAlgorithm().CreateMaze(10, 10, new object());
        }

        /// <summary>
        /// Check if exists closed cells
        /// </summary>
        [TestMethod()]
        public void WhereTest()
        {
            var cells = maze.GetCells();
            foreach(var rows in cells)
            {
                if (rows.Where(x => x.Id == 0).ToArray().Length != 0)
                {
                    Debug.WriteLine("Fuck");
                    Assert.Fail();
                }
                foreach (var cell in rows)
                {
                    int count = 0;
                    foreach (var wall in cell)
                        if (wall == null || wall is NotCell)
                            count++;
                    if (count >= 4)
                    {
                        Debug.WriteLine(cell.Up + " " + cell.Right + " " + cell.Down + " " + cell.Left);
                        Debug.WriteLine(count);
                        Assert.Fail();
                    }
                }
            }
        }

        [TestMethod]
        public void ComparerTest()
        {
            var cells = maze.GetCells();
            List<Cell> allCells = new List<Cell>();
            foreach (var rows in cells)
                allCells.AddRange(rows);
            allCells = allCells.OrderBy(x => x.location, CellPoint.GetInstance()).ToList();

            Cell[][] sortedCells = new Cell[cells.Length][];
            for (int i = 0; i < sortedCells.Length; ++i)
                sortedCells[i] = allCells.Skip(i * cells.Length).Take(cells.Length).ToArray();

            for (int row = 0; row < cells.Length; ++row)
                for (int col = 0; col < cells[0].Length; ++col)
                    if (cells[row][col].location != sortedCells[row][col].location)
                        Assert.Fail();
        }

        [TestMethod]
        public void AnonimTest()
        {
            var anonim = maze.characters.Select(x => new { Character = x, point = x.location.location });
            var group = anonim.GroupBy(x => x.point);
            if (anonim.Count() != group.Count())
                Assert.Fail();
        }
    }
}