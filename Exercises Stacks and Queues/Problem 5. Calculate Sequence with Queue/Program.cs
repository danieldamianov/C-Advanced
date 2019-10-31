using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Problem_5._Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                long current = queue.Dequeue();
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
                Console.Write(current + " ");
            }
        }
    }
}
