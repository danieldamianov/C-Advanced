using System;
using System.Linq;

namespace Problem_4._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int maxSum = -1;
            int maxRow = -1, maxCol = -1;
            for (int i = 0; i < rows - 2; i++)
            {
                for (int j = 0; j < cols - 2; j++)
                {
                    int currentSum = 0;
                    currentSum += matrix[i, j];
                    currentSum += matrix[i, j + 1];
                    currentSum += matrix[i, j + 2];
                    currentSum += matrix[i + 1, j];
                    currentSum += matrix[i + 1, j + 1];
                    currentSum += matrix[i + 1, j + 2];
                    currentSum += matrix[i + 2, j];
                    currentSum += matrix[i + 2, j + 1];
                    currentSum += matrix[i + 2, j + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine(matrix[maxRow, maxCol] + " " + matrix[maxRow, maxCol + 1] + " " + matrix[maxRow, maxCol + 2]);
            Console.WriteLine(matrix[maxRow + 1, maxCol] + " " + matrix[maxRow + 1, maxCol + 1] + " " + matrix[maxRow + 1, maxCol + 2]);
            Console.WriteLine(matrix[maxRow + 2, maxCol] + " " + matrix[maxRow + 2, maxCol + 1] + " " + matrix[maxRow + 2, maxCol + 2]);
        }
    }
}
