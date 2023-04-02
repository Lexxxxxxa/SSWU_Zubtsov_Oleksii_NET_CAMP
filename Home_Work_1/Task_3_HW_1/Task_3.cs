using System;

namespace Task_3
{
    internal class Task_3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cube size:");
            int size = int.Parse(Console.ReadLine());

            int[,,] cube = new int[size, size, size];

            FilledCube(size, cube);
            CubeOutput(size, cube);
            HoleSearching(size, cube);
        }

        static void HoleSearching(int size, int[,,] cube)
        {
            bool hasHole = false;

            for (int i = 0; i < size; i++)
            {
                if (cube[i, 0, 0] == 0 && cube[i, size - 1, size - 1] == 0)
                {
                    hasHole = true;
                    Console.WriteLine($"We come across a hole starting at ({i}, 0, 0) and ending at ({i}, {size - 1}, {size - 1}).");
                    break;
                }
                if (cube[0, i, 0] == 0 && cube[size - 1, i, size - 1] == 0)
                {
                    hasHole = true;
                    Console.WriteLine($"We come across a hole starting at (0, {i}, 0) and ending at ({size - 1}, {i}, {size - 1}).");
                    break;
                }
                if (cube[0, 0, i] == 0 && cube[size - 1, size - 1, i] == 0)
                {
                    hasHole = true;
                    Console.WriteLine($"We come across a hole starting at (0, 0, {i}) and ending at  ({size - 1}, {size - 1}, {i}).");
                    break;
                }
            }

            if (!hasHole)
            {
                Console.WriteLine("The cube does not have a through linear hole");
            }
        }
    

        static void FilledCube(int size, int[,,] cube)

        {
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
        }

        static void CubeOutput(int size, int[,,] cube)
        {
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