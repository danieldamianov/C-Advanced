using System;
using System.Collections.Generic;

namespace _3._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }
            Stack<int> stack = new Stack<int>();
            while (n != 1)
            {
                stack.Push(n % 2);
                n /= 2;
            }
            stack.Push(1);
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
