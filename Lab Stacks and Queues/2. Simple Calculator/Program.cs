using System;
using System.Collections.Generic;

namespace _2._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string[] input = Console.ReadLine().Split(' ');
            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }
            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string operand = stack.Pop();
                int second = int.Parse(stack.Pop());
                if (operand == "+")
                {
                    stack.Push((first + second).ToString());
                }
                else
                {
                    stack.Push((first - second).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
