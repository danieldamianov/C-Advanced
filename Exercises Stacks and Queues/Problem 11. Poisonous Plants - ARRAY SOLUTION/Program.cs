using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11._Poisonous_Plants___ARRAY_SOLUTION
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayCounter = 0;
            int n = int.Parse(Console.ReadLine());
            List<int> plants = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var min = plants.Min();
            var index = plants.IndexOf(min);
            plants = plants.Take(index + 1).ToList();
            while (true)
            {
                List<int> plantsAlive = new List<int>();
                plantsAlive.Add(plants[0]);
                for (int i = 1; i < plants.Count; i++)
                {
                    if (plants[i] <= plants[i-1])
                    {
                        plantsAlive.Add(plants[i]);
                    }
                }
                if (plantsAlive.Count == plants.Count)
                {
                    Console.WriteLine(dayCounter);
                    return;
                }
                plants.Clear();
                for (int i = 0; i < plantsAlive.Count; i++)
                {
                    plants.Add(plantsAlive[i]);
                }
                dayCounter++;
            }
        }
    }
}
