using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string type = Console.ReadLine();
            Func<int, bool> func = check(type);
            Action<int> action = x => Console.Write(x + " ");
            List<int> ns = new List<int>();
            for (int i = nums[0]; i <= nums[1]; i++)
            {
                ns.Add(i);
            }
            ns.Where(func).ToList().ForEach(action);
        }
        static Func<int,bool> check(string type)
        {
            if (type == "odd")
            {
                return x => Math.Abs(x) % 2 == 1;
            }
            else
            {
                return x => Math.Abs(x) % 2 == 0;
            }
        }
    }
}
