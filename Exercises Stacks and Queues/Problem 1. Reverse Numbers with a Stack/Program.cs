using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<double> stack = new Stack<double>(Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
