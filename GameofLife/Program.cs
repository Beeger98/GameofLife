using GameofLife.GameLogic;
using GameofLife.Visualizing;

namespace GameofLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var spawnCells = 15;
            var fieldsize = 15;
            var simulationrounds = 10;
            var startingField = Spawn.CreateField(fieldsize, spawnCells);
            Draw.PrintGrid(startingField);
            for (int i = 0; i < simulationrounds; i++)
            {
               
                startingField = Simulation.NextGeneration(startingField);
                Draw.PrintGrid(startingField);



            }



        }
    }
}
