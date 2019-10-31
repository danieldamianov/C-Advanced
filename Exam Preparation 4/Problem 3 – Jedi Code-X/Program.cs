using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_3___Jedi_Code_X
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                text += Console.ReadLine();
            }
            string jediPatternInput = Console.ReadLine();
            string messagePatternInput = Console.ReadLine();
            string jediPattern = jediPatternInput + "(?<value>" + @"[a-zA-Z]{" + jediPatternInput.Length + "})" + "(?![a-zA-Z])";
            string messagePattern = messagePatternInput + "(?<value>" + @"[a-zA-Z0-9]{" + messagePatternInput.Length + "})" + "(?![a-zA-Z0-9])";
            //Console.WriteLine(string.Join(" ",Regex.Matches(text , jediPattern)));
            //Console.WriteLine(string.Join(" ", Regex.Matches(text , messagePattern)));
            var jediNames = Regex.Matches(text, jediPattern);
            var messageNames = Regex.Matches(text, messagePattern);
            int[] indexes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int jedaiIndex = 1;
            foreach (var index in indexes)
            {
                if (index < 1 || index > messageNames.Count)
                {
                    continue;
                }
                if (jedaiIndex > jediNames.Count)
                {
                    break;
                }
                Console.WriteLine($"{jediNames[jedaiIndex - 1].Groups["value"]} - {messageNames[index - 1].Groups["value"]}");
                jedaiIndex++;
            }
        }
    }
}
