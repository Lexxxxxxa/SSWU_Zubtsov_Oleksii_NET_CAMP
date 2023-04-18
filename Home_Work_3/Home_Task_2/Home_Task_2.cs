namespace Home_Task_2
{
    internal class Home_Task_2
    {//діаграма зовсім не правильна. Немає класу помпи. Клас задачі як мінімум використовує інші класи. Взаємозв'язки між класами побудовані не правильно.
        // Клас, який містить Main не має розв'язувати задачу. 
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the text");
            string text = Console.ReadLine();

            Console.WriteLine("Enter a feed to search for");
            string searchString = Console.ReadLine();
            int index = FindSecondOccurrence(text, searchString);
            if (index == -1)
            {
                Console.WriteLine("No feed was found");
            }
            else
            {
                Console.WriteLine($"The index of the second occurrence of the feed {index}");
            }

            int count = CountWordsStartingWithCapitalLetter(text);
            Console.WriteLine($"Number of words starting with a capital letter {count}");

            Console.WriteLine("Enter text to replace words with double letters");
            string replacementText = Console.ReadLine();
            string resultText = ReplaceWordsWithDoubleLetters(text, replacementText);
            Console.WriteLine($"Text after replacing words with double letters {resultText}");
        }

        static int FindSecondOccurrence(string text, string searchString)
        {
            int index = text.IndexOf(searchString, StringComparison.Ordinal);
            if (index == -1)
            {
                return -1;
            }
            else
            {
                index = text.IndexOf(searchString, index + 1, StringComparison.Ordinal);
                return index;
            }
        }

        static int CountWordsStartingWithCapitalLetter(string text)
        {
            return text.Split(' ')
                       .Count(word => !string.IsNullOrWhiteSpace(word) && char.IsUpper(word[0]));
        }

        static string ReplaceWordsWithDoubleLetters(string text, string replacementText)
        {
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length >= 2 && words[i].ToLower().Distinct().Count() == 1)
                {
                    words[i] = replacementText;
                }
            }
            // Загублено початковий розподіл пробільних символів.
            return string.Join(" ", words);
        }
    }
}
