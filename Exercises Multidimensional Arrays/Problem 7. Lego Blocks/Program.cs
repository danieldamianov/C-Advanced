using System;
using System.Linq;

namespace Problem_7._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] first = new int[rows][];
            int[][] second = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                first[i] = row;
            }
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                second[i] = row;
            }
            int size = first[0].Length + second[0].Length;
            bool equal = true;
            for (int i = 1; i < rows; i++)
            {
                if ((first[i].Length + second[i].Length) != size)
                {
                    equal = false;
                    break;
                }
            }
            if (equal == false)
            {
                int sum = 0;
                for (int i = 0; i < rows; i++)
                {
                    sum += first[i].Length + second[i].Length;
                }
                Console.WriteLine($"The total number of cells is: {sum}");
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    Console.Write($"[{string.Join(", ", first[i])}, ");
                    Console.WriteLine($"{string.Join(", ",second[i].Reverse())}]");
                }
            }
        }
    }
}
