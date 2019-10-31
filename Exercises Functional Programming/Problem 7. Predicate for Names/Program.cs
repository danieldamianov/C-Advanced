using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Func<string, bool> func = x => x.Length <= n;
            list.Where(func).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
