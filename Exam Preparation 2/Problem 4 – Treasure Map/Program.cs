using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_4___Treasure_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern1 = @"![^#!]*?(?<![a-zA-Z0-9])(?<street>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#!]*(?<!\d)((?<number>\d{3})-(?<password>\d{6}|\d{4}))(?!\d)[^#!]*?#";
            string pattern = @"#[^#!]*?(?<![a-zA-Z0-9])(?<street>[a-zA-Z]{4})(?![a-zA-Z0-9])[^#!]*(?<!\d)((?<number>\d{3})-(?<password>\d{6}|\d{4}))(?!\d)[^#!]*?!";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                MatchCollection matches1 = Regex.Matches(input, pattern1);
                List<Match> list = new List<Match>();
                foreach (Match match in matches)
                {
                    list.Add(match);
                }
                foreach (Match match in matches1)
                {
                    list.Add(match);
                }
                list = list.OrderBy(x => x.Index).ToList();
                Match myMatch = list[list.Count / 2];
                Console.WriteLine($"Go to str. {myMatch.Groups["street"].Value} {myMatch.Groups["number"].Value}. Secret pass: {myMatch.Groups["password"].Value}.");
            }
        }
    }
}
