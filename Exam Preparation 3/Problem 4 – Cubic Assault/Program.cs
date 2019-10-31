using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem_4___Cubic_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            var regions = new Dictionary<string, Dictionary<string, BigInteger>>();
            string input;
            while ((input = Console.ReadLine()) != "Count em all")
            {
                string[] tokens = input.Split(new string[] { " -> "}, StringSplitOptions.RemoveEmptyEntries);
                if (regions.ContainsKey(tokens[0]) == false)
                {
                    regions.Add(tokens[0], new Dictionary<string, BigInteger>());
                    regions[tokens[0]].Add("Green", 0);
                    regions[tokens[0]].Add("Red", 0);
                    regions[tokens[0]].Add("Black", 0);
                }
                regions[tokens[0]][tokens[1]] += BigInteger.Parse(tokens[2]);
                if (regions[tokens[0]]["Green"] > 0)
                {
                    regions[tokens[0]]["Red"] += regions[tokens[0]]["Green"] / 1000000;
                    regions[tokens[0]]["Green"] = regions[tokens[0]]["Green"] % 1000000;
                }
                if (regions[tokens[0]]["Red"] > 0)
                {
                    regions[tokens[0]]["Black"] += regions[tokens[0]]["Red"] / 1000000;
                    regions[tokens[0]]["Red"] = regions[tokens[0]]["Red"] % 1000000;
                }
            }
            foreach (var region in regions.OrderByDescending(x => x.Value["Black"]).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var type in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {type.Key} : {type.Value}");
                }
            }
            
        }
    }
}
