using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4___Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int infoIndex = int.Parse(Console.ReadLine());
            string input;
            Dictionary<string, Dictionary<string, string>> people = new Dictionary<string, Dictionary<string, string>>();
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] tokens = input.Split(new char[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (people.ContainsKey(tokens[0]) == false)
                {
                    people.Add(tokens[0], new Dictionary<string, string>());
                }
                for (int i = 1; i < tokens.Length; i += 2)
                {
                    people[tokens[0]][tokens[i]] = tokens[i + 1];
                }
            }
            int infoIndexOfName = 0;
            string name = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
            Console.WriteLine($"Info on {name}:");
            foreach (var info in people[name].OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{info.Key}: {info.Value}");
                infoIndexOfName += info.Key.Length;
                infoIndexOfName += info.Value.Length;
            }
            Console.WriteLine($"Info index: {infoIndexOfName}");
            if (infoIndexOfName >= infoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {infoIndex - infoIndexOfName} more info.");
            }
        }
    }
}
