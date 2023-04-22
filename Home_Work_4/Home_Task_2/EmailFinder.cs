using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Home_Task_2
{
    class EmailFinder
    {// Цей регулярний вираз не розв'язав би повністю проблему.
        private const string emailRegex = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
        private const string atWordRegex = @"\b\w+@\w+\b";

        public string FindEmailsAndAtWords(string text)
        {
            List<string> emails = new List<string>();
            List<string> atWords = new List<string>();
// за домовленістю цю задачу слід було розв'язувати без регулярних виразів.
            MatchCollection emailMatches = Regex.Matches(text, emailRegex);
            foreach (Match match in emailMatches)
            {
                emails.Add(match.Value);
            }

            MatchCollection atWordMatches = Regex.Matches(text, atWordRegex);
            foreach (Match match in atWordMatches)
            {
                string atWord = match.Value;
                if (!IsValidEmail(atWord))
                {
                    atWords.Add(atWord);
                }
            }

            string result = "Valid emails: " + string.Join(", ", emails) + "\n";
            result += "Words containing '@': " + string.Join(", ", atWords);
            return result;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
