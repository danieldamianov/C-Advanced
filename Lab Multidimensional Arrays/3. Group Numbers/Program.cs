using System;
using System.Linq;

namespace _3._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[][] jagged = new int[3][];
            jagged[0] = input.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            jagged[1] = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            jagged[2] = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();
            foreach (var row in jagged)
            {
                foreach (var num in row)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
