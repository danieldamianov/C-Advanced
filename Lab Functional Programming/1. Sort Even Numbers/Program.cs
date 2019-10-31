using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int , bool> func = x => x % 2 == 0;
            var nums = Console.ReadLine()
                .Split(new char[] {' ',','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(func)
                .OrderBy(x => x)
                .ToList();
            Console.WriteLine(string.Join(", ",nums));
        }
    }
}
