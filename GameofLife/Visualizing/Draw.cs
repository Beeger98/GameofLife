using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.Visualizing
{
    public static class Draw
    {
        public static void PrintGrid(bool[,] grid)
        {
            Console.WriteLine("Next Generation");
            //Console.Clear();
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(grid[i, j] ? "X" : "0");
                }
                Console.WriteLine();
            }
        }
    }
}
