using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }
            for (int counter = 0; counter < n; counter++)
            {
                bool isSolution = true;
                int fuel = 0;
                for (int i = 0; i < n; i++)
                {
                    int[] currentStation = queue.Dequeue();
                    queue.Enqueue(currentStation);
                    int currentFuel = currentStation[0];
                    int currentDist = currentStation[1];
                    fuel = fuel + currentFuel - currentDist;
                    if (fuel < 0)
                    {
                        isSolution = false;
                        counter += i;
                        break;
                    }
                }
                if (isSolution)
                {
                    Console.WriteLine(counter);
                    return;
                }
            }
        }
    }
}
