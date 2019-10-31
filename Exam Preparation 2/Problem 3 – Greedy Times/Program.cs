using System;
using System.Collections.Generic;
using System.Linq;
                                                                
namespace Problem_3___Greedy_Times
{       
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, ulong>> dictionary = new Dictionary<string, Dictionary<string, ulong>>();
            ulong bagCapacity = ulong.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < input.Length - 1; i+=2)
            {
                string item = input[i];
                ulong amount = ulong.Parse(input[i + 1]);
                if (DefineType(item) == 0)
                {
                    continue;
                }
                switch (DefineType(item))
                {
                    case 1:
                        if (dictionary.ContainsKey("Cash") == false)
                        {
                            dictionary.Add("Cash", new Dictionary<string, ulong>());
                        }
                        decimal gemAmount = 0;
                        decimal cashAmount = 0;
                        decimal goldAmount = 0;
                        if (dictionary.ContainsKey("Gem"))
                        {
                            gemAmount = dictionary["Gem"].Sum(x => (decimal)x.Value);
                        }
                        if (dictionary.ContainsKey("Cash"))
                        {
                            cashAmount = dictionary["Cash"].Sum(x => (decimal)x.Value);
                        }
                        if (dictionary.ContainsKey("Gold"))
                        {
                            goldAmount = dictionary["Gold"].Sum(x => (decimal)x.Value);
                        }
                        cashAmount += amount;
                        if (gemAmount + cashAmount + goldAmount > bagCapacity)
                        {
                            break;
                        }
                        if (cashAmount > gemAmount)
                        {
                            break;
                        }
                        if (dictionary["Cash"].ContainsKey(item) == false)
                        {
                            dictionary["Cash"].Add(item, 0);
                        }
                        dictionary["Cash"][item] += amount;
                        break;
                    case 2:
                        if (dictionary.ContainsKey("Gem") == false)
                        {
                            dictionary.Add("Gem", new Dictionary<string, ulong>());
                        }
                        decimal gemAmount1 = 0;
                        decimal cashAmount1 = 0;
                        decimal goldAmount1 = 0;
                        if (dictionary.ContainsKey("Gem"))
                        {
                            gemAmount1 = dictionary["Gem"].Sum(x => (decimal)x.Value);
                        }
                        if (dictionary.ContainsKey("Cash"))
                        {
                            cashAmount1 = dictionary["Cash"].Sum(x => (decimal)x.Value);
                        }
                        if (dictionary.ContainsKey("Gold"))
                        {
                            goldAmount1 = dictionary["Gold"].Sum(x => (decimal)x.Value);
                        }
                        gemAmount1 += amount;
                        if (gemAmount1 + cashAmount1 + goldAmount1 > bagCapacity)
                        {
                            break;
                        }
                        if (cashAmount1 > gemAmount1)
                        {
                            break;
                        }
                        if (goldAmount1 < gemAmount1)
                        {
                            break;
                        }
                        if (dictionary["Gem"].ContainsKey(item) == false)
                        {
                            dictionary["Gem"].Add(item, 0);
                        }
                        dictionary["Gem"][item] += amount;
                        break;
                    case 3:
                        if (dictionary.ContainsKey("Gold") == false)
                        {
                            dictionary.Add("Gold", new Dictionary<string, ulong>());
                        }
                        decimal gemAmount2 = 0;
                        decimal cashAmount2 = 0;
                        decimal goldAmount2 = 0;
                        if (dictionary.ContainsKey("Gem"))
                        {
                            gemAmount2 = dictionary["Gem"].Sum(x => (decimal)x.Value);
                        }
                        if (dictionary.ContainsKey("Cash"))
                        {
                            cashAmount2 = dictionary["Cash"].Sum(x => (decimal)x.Value);
                        }
                        if (dictionary.ContainsKey("Gold"))
                        {
                            goldAmount2 = dictionary["Gold"].Sum(x => (decimal)x.Value);
                        }
                        goldAmount2 += amount;
                        if (gemAmount2 + cashAmount2 + goldAmount2 > bagCapacity)
                        {
                            break;
                        }
                        if (goldAmount2 < gemAmount2)
                        {
                            break;
                        }
                        if (dictionary["Gold"].ContainsKey(item) == false)
                        {
                            dictionary["Gold"].Add(item, 0);
                        }
                        dictionary["Gold"][item] += amount;
                        break;
                }
            }
            foreach (var type in dictionary.Where(x => x.Value.Count != 0).OrderByDescending(x => x.Value.Sum(k => (decimal)k.Value)))
            {
                Console.WriteLine($"<{type.Key}> ${dictionary[type.Key].Sum(x => (decimal)x.Value)}");
                foreach (var item in type.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
        // 1 - cash
        // 2 - gem
        // 3 - gold
        static int DefineType(string item)
        {
            if (item == "Gold")
            {
                return 3;
            }
            if (item.Length == 3)
            {
                return 1;
            }
            if (item.EndsWith("gem")||item.EndsWith("Gem"))
            {
                return 2;
            }
            return 0;
        }
    }
}
