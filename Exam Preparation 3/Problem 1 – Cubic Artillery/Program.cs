using System;
using System.Collections.Generic;

namespace Problem_1___Cubic_Artillery
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Bunker> bunkers = new Queue<Bunker>();
            int totalCapacity = int.Parse(Console.ReadLine());
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Bunker Revision")
            {
                string[] tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string tokenString in tokens)
                {
                    char token = tokenString[0];
                    if (char.IsLetter(token))
                    {
                        bunkers.Enqueue(new Bunker(token));
                    }
                    else
                    {
                        int weapon = int.Parse(tokenString);
                        if (bunkers.Peek().CurrentCapacity() + weapon <= totalCapacity)
                        {
                            bunkers.Peek().Weapons.Add(weapon);
                        }
                        else
                        {
                            while (bunkers.Count != 1)
                            {
                                if (bunkers.Peek().CurrentCapacity() + weapon <= totalCapacity)
                                {
                                    bunkers.Peek().Weapons.Add(weapon);
                                    break;
                                }
                                else
                                {
                                    if (bunkers.Peek().Weapons.Count > 0)
                                    {
                                        Console.WriteLine($"{bunkers.Peek().Name} -> {string.Join(", ", bunkers.Peek().Weapons)}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{bunkers.Peek().Name} -> Empty");
                                    }
                                    bunkers.Dequeue();
                                }
                            }
                            if (weapon <= totalCapacity)
                            {
                                while (totalCapacity - bunkers.Peek().CurrentCapacity() < weapon)
                                {
                                    bunkers.Peek().Weapons.RemoveAt(0);
                                }
                                bunkers.Peek().Weapons.Add(weapon);
                            }
                        }
                    }
                }
            }
        }
    }
    class Bunker
    {
        public char Name { get; set; }
        public List<int> Weapons { get; set; }
        public int CurrentCapacity()
        {
            int currentCapacity = 0;
            foreach (var weapon in this.Weapons)
            {
                currentCapacity += weapon;
            }
            return currentCapacity;
        }
        public Bunker(char name)
        {
            this.Name = name;
            this.Weapons = new List<int>();
        }
    }
}
