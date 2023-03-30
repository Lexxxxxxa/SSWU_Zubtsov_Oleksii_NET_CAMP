namespace Task_1
{
    internal class Task_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix size");
            Console.Write("Row ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Columns ");
            int m = int.Parse(Console.ReadLine());

            if (n <= 0 || m <= 0) { Console.WriteLine("Incorect incoming data"); }

            int[,] matrix = new int[n, m];

            int snake = 1;
            int startColumns = 0;
            int startRow = 0;
            int endRow = n - 1;
            int endCol = m - 1;

            while (startRow <= endRow && startColumns <= endCol)
            {
                for (int i = startRow; i <= endRow; ++i)
                {
                    matrix[i, startColumns] = snake;
                    snake++;
                }
                startColumns++;

                for (int i = startColumns; i <= endCol; ++i)
                {
                    matrix[endRow, i] = snake;
                    snake++;
                }
                endRow--;

                if (startColumns <= endCol)
                {
                    for (int i = endRow; i >= startRow; --i)
                    {
                        matrix[i, endCol] = snake;
                        snake++;
                    }
                    endCol--;
                }

                if (startRow <= endRow)
                {
                    for (int i = endCol; i >= startColumns; --i)
                    {
                        matrix[startRow, i] = snake;
                        snake++;
                    }
                    startRow++;
                }
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}