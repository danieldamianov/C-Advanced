using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem_4._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] Args = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] queueArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            foreach (var item in queueArgs)
            {
                queue.Enqueue(item);
            }
            int par = Math.Min(Args[0], Args[1]);
            for (int i = 0; i < par; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (queue.Contains(Args[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
