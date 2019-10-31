using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Args = Console.ReadLine().Split(' ');
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            int par = Math.Min(int.Parse(Args[1]), int.Parse(Args[0]));
            for (int i = 0; i < par; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (stack.Contains(int.Parse(Args[2])))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
