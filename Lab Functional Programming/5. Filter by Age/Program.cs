using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                dictionary.Add(personArgs[0], int.Parse(personArgs[1]));
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            if (condition == "older")
            {
                dictionary = dictionary.Where(x => x.Value >= age).ToDictionary(x => x.Key,y => y.Value);
            }
            else
            {
                dictionary = dictionary.Where(x => x.Value < age).ToDictionary(x => x.Key, y => y.Value);
            }
            switch (format)
            {
                case "name":
                    foreach (var item in dictionary.Keys)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "age":
                    foreach (var item in dictionary.Values)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "name age":
                    foreach (var item in dictionary)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                    break;
            }
        }
    }
}
