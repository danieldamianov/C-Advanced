using System;
using System.Collections.Generic;

namespace Problem_8._Recursive_Fibonacci
{
    class Program
    {
        static Dictionary<long, long> dictionary = new Dictionary<long, long>();
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            Console.WriteLine(Fib(num));
        }
        static long Fib(long num)
        {
            if (num <= 2)
            {
                return dictionary[num] = 1;
            }
            if (dictionary.ContainsKey(num) == false)
            {
                dictionary[num] = Fib(num - 1) + Fib(num - 2);
            }
            return dictionary[num];
        }
    }
}
