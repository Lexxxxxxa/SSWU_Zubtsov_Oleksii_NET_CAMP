namespace Home_Task_1
{
    internal class Home_Task_1
    {
        public static void Main()
        {
            Console.WriteLine("Enter the text to process");
            string text = Console.ReadLine();

            List<string> sentences = GetSentences(text);
            List<string> sentencesWithParentheses = GetSentencesWithParentheses(sentences);

            Console.WriteLine("Sentences containing brackets");
            foreach (string sentence in sentencesWithParentheses)
            {
                Console.WriteLine(sentence);
            }
        }

        static List<string> GetSentences(string text)
        {
            List<string> sentences = new List<string>();
            int startIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '.' || c == '!' || c == '?')
                {
                    string sentence = text.Substring(startIndex, i - startIndex + 1).Trim();
                    sentences.Add(sentence);
                    startIndex = i + 1;
                }
            }

            string lastSentence = text.Substring(startIndex).Trim();
            if (lastSentence != "")
            {
                sentences.Add(lastSentence);
            }

            return sentences;
        }

        static List<string> GetSentencesWithParentheses(List<string> sentences)
        {
            List<string> sentencesWithParentheses = new List<string>();

            foreach (string sentence in sentences)
            {
                if (sentence.Contains("(") && sentence.Contains(")"))
                {
                    sentencesWithParentheses.Add(sentence);
                }
            }

            return sentencesWithParentheses;
        }
    }
}