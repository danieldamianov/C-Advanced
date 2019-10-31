using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();
            maxNumbers.Push(0);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                switch (query[0])
                {
                    case 1:
                        if (query[1] >= maxNumbers.Peek())
                        {
                            maxNumbers.Push(query[1]);
                        }
                        numbers.Push(query[1]);
                        break;
                    case 2:
                        if (numbers.Peek() == maxNumbers.Peek())
                        {
                            maxNumbers.Pop();
                        }
                        numbers.Pop();
                        break;
                    default:
                        Console.WriteLine(maxNumbers.Peek());
                        break;
                }
                
            }
        }
    }
}
