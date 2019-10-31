using System;
using System.Collections.Generic;

namespace Problem_9._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<long> fib = new Stack<long>();
            fib.Push(0);
            fib.Push(1);
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                long first = fib.Pop();
                long second = fib.Pop();
                fib.Push(second);
                fib.Push(first);
                fib.Push(first + second);
            }
            Console.WriteLine(fib.Pop());
        }
    }
}
