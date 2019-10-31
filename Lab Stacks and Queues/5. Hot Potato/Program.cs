using System;
using System.Collections.Generic;

namespace _5._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Queue<string> queue = new Queue<string>(input);
            int toss = int.Parse(Console.ReadLine());
            while (queue.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    var child = queue.Dequeue();
                    queue.Enqueue(child);
                }
                Console.WriteLine("Removed " + queue.Dequeue());
            }
            Console.WriteLine($"Last is " + queue.Dequeue());
        }
    }
}
