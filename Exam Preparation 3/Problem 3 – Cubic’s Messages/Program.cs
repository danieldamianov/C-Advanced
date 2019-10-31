using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_3___Cubic_s_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(\d+)([a-zA-Z]+)([^a-zA-Z]*)$";
            string input;
            string output = "";
            while ((input = Console.ReadLine()) != "Over!")
            {
                int n = int.Parse(Console.ReadLine());
                if (Regex.IsMatch(input , pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    if (match.Groups[2].Value.Length != n)
                    {
                        continue;
                    }
                    List<int> indexes = new List<int>();
                    foreach (char sign in match.Groups[1].Value)
                    {
                        if (char.IsDigit(sign))
                        {
                            indexes.Add(sign - '0');
                        }
                    }
                    foreach (char sign in match.Groups[3].Value)
                    {
                        if (char.IsDigit(sign))
                        {
                            indexes.Add(sign - '0');
                        }
                    }
                    string code = "";
                    foreach (var index in indexes)
                    {
                        if (index >= 0 && index < match.Groups[2].Value.Length)
                        {
                            code += match.Groups[2].Value[index];
                        }
                        else
                        {
                            code += " ";
                        }
                    }
                    output+=$"{match.Groups[2].Value} == {code}";
                    output += Environment.NewLine;
                }
            }
            Console.WriteLine(output);
        }
    }
}
