namespace Home_Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter some text:");
            string text = Console.ReadLine();

            var finder = new EmailFinder();
            Console.WriteLine(finder.FindEmailsAndAtWords(text));
        }
    }
}