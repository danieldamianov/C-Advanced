using System;
using System.Linq;

namespace Problem_1._Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int r = input[0];
            int c = input[1];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Console.WriteLine();
            for (int i = 0; i < r; i++)
            {
                for (int j = i; j < c + i; j++)
                {
                    Console.Write(alphabet[i]);
                    Console.Write(alphabet[j]);
                    Console.Write(alphabet[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
