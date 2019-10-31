using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_12._Inferno_III
{
    class Gem
    {
        public int GemValue { get; set; }
        public bool Excluded { get; set; }
        public Gem(int value,bool excluded)
        {
            this.GemValue = value;
            this.Excluded = excluded;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> commandsList = new List<string[]>();
            List<int> gems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Forge")
                {
                    break;
                }
                string[] commandArgs = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] == "Exclude")
                {
                    commandsList.Add(new string[] { commandArgs[1], commandArgs[2] });
                }
                else
                {
                    commandsList.RemoveAll(x => x[0] == commandArgs[1] && x[1] == commandArgs[2]);
                }
            }
            List<Gem> list = new List<Gem>();
            foreach (var item in gems)
            {
                list.Add(new Gem(item, true));
            }
            foreach (var item in commandsList)
            {
                string filterType = item[0];
                int filterParameter = int.Parse(item[1]);
                switch (filterType)
                {
                    case "Sum Left":
                        for (int i = 0; i < list.Count; i++)
                        {
                            int sum = 0;
                            sum = list[i].GemValue;
                            if (i != 0)
                            {
                                sum += list[i - 1].GemValue;
                            }
                            if (sum == filterParameter)
                            {
                                list[i].Excluded = false;
                            }
                        }
                        break;
                    case "Sum Left Right":
                        for (int i = 0; i < list.Count; i++)
                        {
                            int sum = 0;
                            sum = list[i].GemValue;
                            if (i != 0)
                            {
                                sum += list[i - 1].GemValue;
                            }
                            if (i != list.Count - 1)
                            {
                                sum += list[i + 1].GemValue;
                            }
                            if (sum == filterParameter)
                            {
                                list[i].Excluded = false;
                            }
                        }
                        break;
                    case "Sum Right":
                        for (int i = 0; i < list.Count; i++)
                        {
                            int sum = 0;
                            sum = list[i].GemValue;
                            if (i != list.Count - 1)
                            {
                                sum += list[i + 1].GemValue;
                            }
                            if (sum == filterParameter)
                            {
                                list[i].Excluded = false;
                            }
                        }
                        break;
                }
            }
            foreach (var kvp in list.Where(x => x.Excluded == true))
            {
                Console.Write(kvp.GemValue + " ");
            }
            Console.WriteLine();
        }
    }
}
