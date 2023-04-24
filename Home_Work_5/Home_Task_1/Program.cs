namespace Home_Task_1
{// Oleksii	Zubtsov		85	5	0	85	75	30	20	61,5
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the tree coordinates for garden 1, separated by commas: ");
            string[] treeCoordinates1 = Console.ReadLine().Split(',');

            double[] treeCoords1 = Array.ConvertAll(treeCoordinates1, double.Parse);

            Garden garden1 = new Garden { TreeCoordinates = treeCoords1 };

            Console.Write("Enter the tree coordinates for garden 2, separated by commas: ");
            string[] treeCoordinates2 = Console.ReadLine().Split(',');

            double[] treeCoords2 = Array.ConvertAll(treeCoordinates2, double.Parse);

            Garden garden2 = new Garden { TreeCoordinates = treeCoords2 };

            if (garden1 < garden2)
            {
                Console.WriteLine("Garden 1 has a shorter fence than Garden 2.");
            }
            else if (garden1 > garden2)
            {
                Console.WriteLine("Garden 1 has a longer fence than Garden 2.");
            }
            else
            {
                Console.WriteLine("Garden 1 and Garden 2 have the same fence length.");
            }
        }
    }
}
