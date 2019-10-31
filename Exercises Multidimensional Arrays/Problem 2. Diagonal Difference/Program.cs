using System;
using System.Linq;

namespace Problem_2._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            double[,] matrix = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                var row = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            double secondDiag = 0;
            double firstDiag = 0;
            for (int i = 0; i < size; i++)
            {
                secondDiag += matrix[i , size - i - 1];
                firstDiag += matrix[i, i];
            }
            Console.WriteLine(Math.Abs(firstDiag - secondDiag));
        }
    }
}
