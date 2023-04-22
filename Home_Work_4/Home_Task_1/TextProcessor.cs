using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_1
{
    class TextProcessor
    {// За умовою задачі текст не може бути в одній стрічці(
        private string text;

        public TextProcessor(string text)
        {
            this.text = text;
        }

        public List<string> GetSentencesWithParentheses()
        {
            List<string> sentences = GetSentences();
            List<string> sentencesWithParentheses = new List<string>();

            foreach (string sentence in sentences)
            {
                if (sentence.Contains("(") && sentence.Contains(")")
                    || sentence.Contains("[") && sentence.Contains("]")
                    || sentence.Contains("{") && sentence.Contains("}"))
                {
                    sentencesWithParentheses.Add(sentence);
                }
            }

            return sentencesWithParentheses;
        }

        private List<string> GetSentences()
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
    }
}
}
