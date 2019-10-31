using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_1___Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[^\[\s]+?<(\d+)REGEH(\d+)>[^\]\s]+?\]";
            string text = Console.ReadLine();
            List<int> numbers = new List<int>();
            foreach (Match match in Regex.Matches(text, pattern))
            {
                numbers.Add(int.Parse(match.Groups[1].Value));
                numbers.Add(int.Parse(match.Groups[2].Value));
            }
            int position = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                position += numbers[i];
                Console.Write(text[position % text.Length]);
            }
        }
    }
}
