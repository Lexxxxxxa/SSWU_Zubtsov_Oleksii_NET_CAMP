using static Home_Task_2.Store;

namespace Home_Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter store name:");
            var storeName = Console.ReadLine();
            var store = new Store(storeName);
            var box = new Box();

            while (true)
            {
                Console.WriteLine("Enter section name (or 'done' to finish):");
                var sectionName = Console.ReadLine();

                if (sectionName == "done")
                {
                    break;
                }

                store.AddSection(sectionName);

                while (true)
                {
                    Console.WriteLine($"Enter product name for section '{sectionName}' (or 'done' to finish):");
                    var productName = Console.ReadLine();

                    if (productName == "done")
                    {
                        break;
                    }

                    Console.WriteLine("Enter product dimensions (width height depth):");
                    var dimensions = Console.ReadLine().Split(' ');

                    if (dimensions.Length != 3)
                    {
                        Console.WriteLine("Invalid dimensions");
                        continue;
                    }

                    if (!int.TryParse(dimensions[0], out var width) ||
                        !int.TryParse(dimensions[1], out var height) ||
                        !int.TryParse(dimensions[2], out var depth))
                    {
                        Console.WriteLine("Invalid dimensions");
                        continue;
                    }

                    store.AddProduct(sectionName, productName, width, height, depth);
                }
            }

            Console.WriteLine("Packing items into boxes...");
            box.PackItemsIntoBoxes();
        }
    }
}