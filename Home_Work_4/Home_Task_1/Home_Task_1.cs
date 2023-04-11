namespace Home_Task_1
{
    internal class Home_Task_1
    {
        public static void Main()
        {
            Console.WriteLine("Enter the text to process");
            string text = Console.ReadLine();

            TextProcessor processor = new TextProcessor(text);
            List<string> sentencesWithParentheses = processor.GetSentencesWithParentheses();

            Console.WriteLine("Sentences containing brackets:");
            foreach (string sentence in sentencesWithParentheses)
            {
                Console.WriteLine(sentence);
            }
        }

    }
}