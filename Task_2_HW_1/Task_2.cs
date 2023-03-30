namespace Task_2
{
    internal class Task_2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter matrix size");
            Console.Write("Row ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Columns ");
            int m = int.Parse(Console.ReadLine());

            if (n <= 0 || m <= 0)
            {
                Console.WriteLine("Incorect incoming data");
                Environment.Exit(0);
            }

            Random random = new Random();
            int[,] matrix = new int[n, m];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(17);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            int maxSequenceLength = 0, startColumnWithMaxSequence = 0, endColumnWithMaxSequence = 0, rowWithMaxSequence = -1, curentColor = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sequenceLength = 1, startIndex = 0;

                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1])
                    {
                        if (sequenceLength == 1)
                        {
                            startIndex = j;
                        }
                        sequenceLength++;

                        if (sequenceLength >= maxSequenceLength)
                        {
                            maxSequenceLength = sequenceLength;
                            startColumnWithMaxSequence = startIndex;
                            endColumnWithMaxSequence = j + 1;
                            rowWithMaxSequence = i;
                            curentColor = matrix[i, j];
                        }
                    }
                    else
                    {
                        sequenceLength = 1;
                    }
                }
            }

            if (maxSequenceLength == 0)
            {
                Console.WriteLine("Sequence not found");
            }
            else
            {
                Console.WriteLine($"Colour of the longest horizontal line {curentColor}");
                Console.WriteLine($"Start of sequence [{rowWithMaxSequence},{startColumnWithMaxSequence}]");
                Console.WriteLine($"End of sequence [{rowWithMaxSequence},{endColumnWithMaxSequence}]");
                Console.WriteLine($"Sequence length {maxSequenceLength}");
            }
            Console.ReadKey();
        }
    }
}