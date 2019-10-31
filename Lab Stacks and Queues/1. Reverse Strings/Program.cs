using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            foreach (char sym in input)
            {
                stack.Push(sym);
            }
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
