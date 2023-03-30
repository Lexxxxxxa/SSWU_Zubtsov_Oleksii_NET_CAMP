namespace Task_3
{
    internal class Task_3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cube size:");
            int size = int.Parse(Console.ReadLine());

            int[,,] cube = new int[size, size, size];
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        cube[i, j, k] = rand.Next(2);
                    }
                }
            }

            Console.WriteLine("The cube is:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        Console.Write(cube[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}