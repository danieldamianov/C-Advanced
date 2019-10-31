using System;
using System.Numerics;

namespace _4._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine(1);
                return;
            }
            if (n == 2)
            {
                Console.WriteLine("1 1");
                return;
            }
            if (n == 3)
            {
                Console.WriteLine("1 2 1");
                return;
            }
            BigInteger[][] pascal = new BigInteger[n][];
            for (int i = 1; i <= n; i++)
            {
                pascal[i - 1] = new BigInteger[i];
                pascal[i - 1][0] = 1;
                pascal[i - 1][i - 1] = 1;
            }
            pascal[2][1] = 2;
            for (int i = 2; i < n - 1; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    pascal[i + 1][j + 1] = pascal[i][j] + pascal[i][j + 1];
                }
            }
            foreach (var row in pascal)
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
