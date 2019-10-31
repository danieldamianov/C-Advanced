using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> func = x => Math.Abs(x) % 2 == 0;
            Func<int, bool> func1 = x => Math.Abs(x) % 2 == 1;
            List<int> nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var evenList = nums.Where(func).OrderBy(x => x).ToList();
            var oddList = nums.Where(func1).OrderBy(x => x).ToList();
            Console.Write(string.Join(" ", evenList) + " ");
            Console.WriteLine(string.Join(" ",oddList));
        }
    }
}
