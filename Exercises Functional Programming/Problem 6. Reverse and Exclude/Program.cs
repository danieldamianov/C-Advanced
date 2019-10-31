using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Reverse().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            Func<int, bool> func = x => x % n != 0;
            list.Where(func).ToList().ForEach(x => Console.Write(x + " "));
        }
    }
}
