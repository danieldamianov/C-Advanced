using System;
using System.Collections.Generic;

namespace _6._Traffic_Light
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int passing = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < passing; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }

            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
