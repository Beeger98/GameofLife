using System.Drawing;

namespace Kraemer;

internal static class Program
{
    private static void Main()
    {
        var size = new Point(30, 15);
        var field = CreateField(size, 60);

        for (var i = 0; i < 1000; i++)
        {
             PrintField(field);
             field = NextStep(field);
             
             Task.Delay(750).Wait();
             Console.Clear();
        }
    }

    private static bool[,] NextStep(bool[,] field)
    {
        var target = new bool[field.GetLength(0), field.GetLength(1)];
        for (var row = 0; row < field.GetLength(0); row++)
            for (var col = 0; col < field.GetLength(1); col++)
                target[row, col] = GetAliveNeighbours(field, row, col) switch
                {
                    2 => field[row, col], 
                    3 => true, 
                    _ => false
                };
        
        return target;
    }

    private static int GetAliveNeighbours(bool[,] field, int row, int col)
    {
        var count = 0;
        
        for (var rowOffset = -1; rowOffset <= 1; rowOffset++)
        {
            for (var colOffset = -1; colOffset <= 1; colOffset++)
            {
                if (rowOffset == 0 && colOffset == 0)
                    continue;
                
                var neighborRow = row + rowOffset;
                var neighborCol = col + colOffset;
                
                if (neighborRow < 0 || neighborRow >= field.GetLength(0) ||
                    neighborCol < 0 || neighborCol >= field.GetLength(1)) continue;
                
                if (field[neighborRow, neighborCol])
                    count++;
            }
        }
        
        return count;
    }
    
    private static bool[,] CreateField(Point size, int aliveCellCount)
    {
        var field = new bool[size.Y, size.X];
        var spawnedCells = 0;

        while (spawnedCells < aliveCellCount)
        {
            var x = new Random().Next(size.X);
            var y = new Random().Next(size.Y);

            if (field[y, x])
                continue;

            field[y, x] = true;
            spawnedCells++;
        }

        return field;
    }

    private static void PrintField(bool[,] field)
    {
        for (var row = 0; row < field.GetLength(0); row++)
        {
            for (var col = 0; col < field.GetLength(1); col++)
            {
                Console.ForegroundColor = field[row, col] ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(field[row, col] ? "x " : "+ ");
            }

            Console.WriteLine();
        }
    }
}