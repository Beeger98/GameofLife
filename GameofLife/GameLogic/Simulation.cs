using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife.GameLogic
{
    class Simulation
    {
        public static bool[,] NextGeneration(bool[,] currentGen)
        {
            var newGen = new bool[currentGen.GetLength(0), currentGen.GetLength(0)];
            
            var status = false;
            for (int i = 0; i <= currentGen.GetLength(0) - 1; i++)
            {
                
                for (var j = 0; j <= currentGen.GetLength(0) - 1; j++)
                {
                    var aliveNeighbors = 0;
                    // Töten den Rand
                    if (j == 0 || i == 0 || i == currentGen.GetLength(0) - 1 || j == currentGen.GetLength(1) - 1)
                    {
                        continue;
                    }
                    // Make sure that its in bounds
                    //if()
                    // Check for Neighbors 
                    
                    if (i > 0 && j > 0 && currentGen[i-1, j - 1]) aliveNeighbors++; // Top-Left
                    if (i > 0 && currentGen[i-1, j]) aliveNeighbors++; // Top
                    if (i > 0 && j < currentGen.GetLength(1) - 1 && currentGen[i-1, j+1]) aliveNeighbors++; // Top-Right
                    if (j > 0 && currentGen[i, j-1]) aliveNeighbors++; // Left
                    if (j < currentGen.GetLength(1) - 1 && currentGen[i, j+1]) aliveNeighbors++; // Right
                    if (i < currentGen.GetLength(0) - 1 && j > 0 && currentGen[i+1, j-1]) aliveNeighbors++; // Bottom-Left
                    if (i < currentGen.GetLength(0) - 1 && currentGen[i+1, j]) aliveNeighbors++; // Bottom
                    if (i < currentGen.GetLength(0) - 1 && j < currentGen.GetLength(1) - 1 && currentGen[i + 1, j + 1]) aliveNeighbors++; // Bottom-Right


                    switch (aliveNeighbors)
                    {
                        case 3:
                            newGen[i, j] = true;
                            break;
                        case 2:
                            newGen[i, j] = currentGen[i, j];
                            break;
                        default:
                            newGen[i, j] = false;
                            break;
                    }




                }

            }





            return newGen;
            throw new NotImplementedException();
        }
    }
}
