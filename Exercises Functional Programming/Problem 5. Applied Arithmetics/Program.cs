using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> action = x => Console.Write(x + " ");
            Func<int, int> funcAdd = x => x + 1;
            Func<int, int> funcMultiply = x => x * 2;
            Func<int, int> funcSubtract = x => x - 1;
            List<int> nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    Environment.Exit(0);
                }
                switch (command)
                {
                    case "add":
                        nums = nums.Select(funcAdd).ToList();
                        break;
                    case "multiply":
                        nums = nums.Select(funcMultiply).ToList();
                        break;
                    case "subtract":
                        nums = nums.Select(funcSubtract).ToList();
                        break;
                    case "print":
                        nums.ForEach(action);
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
