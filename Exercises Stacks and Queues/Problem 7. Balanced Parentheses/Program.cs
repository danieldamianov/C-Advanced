using System;
using System.Collections.Generic;

namespace Problem_7._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' ||
                    input[i] == '{' ||
                    input[i] == '[' )
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (input[i] == ')')
                    {
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        
                    }
                    if (input[i] == ']')
                    {
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                    }
                    if (input[i] == '}')
                    {
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                    }
                }
            }
            if (stack.Count != 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
