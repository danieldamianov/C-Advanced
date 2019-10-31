using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Func<string, bool> func = x => sum(x) >= n;
            List<string> list = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Console.WriteLine(list.FirstOrDefault(func));
        }
        static long sum(string str)
        {
            long sum = 0;
            foreach (var s in str)
            {
                sum += s;
            }
            return sum;
        }
    }
}
