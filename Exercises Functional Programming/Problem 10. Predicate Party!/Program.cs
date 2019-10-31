using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Party!")
                {
                    break;
                }
                string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commandArgs[0] == "Remove")
                {
                    if (commandArgs[1] == "StartsWith")
                    {
                        list = list.Where(x => x.StartsWith(commandArgs[2]) == false).ToList();
                    }
                    else if (commandArgs[1] == "EndsWith")
                    {
                        list = list.Where(x => x.EndsWith(commandArgs[2]) == false).ToList();
                    }
                    else
                    {
                        list = list.Where(x => x.Length != int.Parse(commandArgs[2])).ToList();
                    }
                }
                else
                {
                    if (commandArgs[1] == "StartsWith")
                    {
                        var p = list.Where(x => x.StartsWith(commandArgs[2])).ToArray();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (p.Contains(list[i]))
                            {
                                list.Insert(i + 1, list[i]);
                                i++;
                            }
                        }

                    }
                    else if (commandArgs[1] == "EndsWith")
                    {
                        var p = list.Where(x => x.EndsWith(commandArgs[2])).ToArray();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (p.Contains(list[i]))
                            {
                                list.Insert(i + 1, list[i]);
                                i++;
                            }
                        }
                    }
                    else
                    {
                        var p = list.Where(x => x.Length == int.Parse(commandArgs[2])).ToArray();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (p.Contains(list[i]))
                            {
                                list.Insert(i + 1, list[i]);
                                i++;
                            }
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ",list) + " are going to the party!");
            }
        }
    }
}
