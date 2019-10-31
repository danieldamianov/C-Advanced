using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem_3___Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                text+=Console.ReadLine();
            }
            string pattern = @"((?<hash>\[)|{)[^\[{]*?(?<numbers>\d{3,})[^\]}]*?(?(hash)\]|})";
            //Console.WriteLine(Regex.Matches(text, pattern).Count());
            foreach (Match match in Regex.Matches(text, pattern))
            {
                //Console.WriteLine(match.Value);
                if (match.Groups["numbers"].Value.Length % 3 != 0)
                {
                    continue;
                }
                int blockLength = match.Value.Length;
                string numbersString = match.Groups["numbers"].Value;
                //Console.WriteLine(numbersString);
                List<int> numbers = new List<int>();
                for (int i = 0; i < numbersString.Length; i += 3)
                {
                    numbers.Add(int.Parse(numbersString.Substring(i, 3)));
                    //Console.WriteLine(int.Parse(numbersString.Substring(i, 3)));
                }
                numbers = numbers.Select(x => x - blockLength).ToList();
                //Console.WriteLine(string.Join(" ",numbers));
                foreach (var code in numbers)
                {
                    Console.Write((char)code);
                }
            }
        }
    }
}
