using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> commands = new List<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Print")
                {
                    break;
                }
                string[] commandArgs = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] == "Add filter")
                {
                    commands.Add(commandArgs[1] + " " + commandArgs[2]);
                }
                else
                {
                    commands.Remove(commandArgs[1] + " " + commandArgs[2]);
                }
            }
            for (int i = 0; i < commands.Count; i++)
            {
                string[] commandArgs = commands[i].Split(' ');
                if (commandArgs.Length == 3)
                {
                    commandArgs[0] = commandArgs[0] + " " + commandArgs[1];
                    commandArgs[1] = commandArgs[2];
                }
                if (commandArgs[0] == "Starts with")
                {
                    people = people.Where(x => !x.StartsWith(commandArgs[1])).ToList();
                }
                else if(commandArgs[0] == "Ends with")
                {
                    people = people.Where(x => !x.EndsWith(commandArgs[1])).ToList();
                }
                else if (commandArgs[0] == "Length")
                {
                    people = people.Where(x => x.Length != int.Parse(commandArgs[1])).ToList();
                }
                else if(commandArgs[0] == "Contains")
                {
                    people = people.Where(x => !x.Contains(commandArgs[1])).ToList();
                }
            }
            Console.WriteLine(string.Join(" ",people));
        }
    }
}
