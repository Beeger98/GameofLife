namespace GameofLife.GameLogic
{
    static class Spawn
    {
        public static bool[,] CreateField(int fieldsize, int spawnCells)
        {
            bool[,] field = new bool[fieldsize, fieldsize];
            Random rand = new Random();
            for (int i = 0; i < spawnCells; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(fieldsize);
                    y = rand.Next(fieldsize);
                } while (field[x, y]); // Ensure we don't spawn on an already alive cell
                field[x, y] = true;
            }
            return field;
        }
    }
}
