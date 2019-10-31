using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int n = int.Parse(Console.ReadLine());
            if (n <= 0)
            {
                Environment.Exit(0);
            }
            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }
            var divisorList = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToList();
            Console.WriteLine(string.Join(" ",list.Where(x => isPerfect(x,divisorList))));
        }
        static bool isPerfect(int num , List<int> divisors)
        {
            foreach (var n in divisors)
            {
                if (num % n != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
