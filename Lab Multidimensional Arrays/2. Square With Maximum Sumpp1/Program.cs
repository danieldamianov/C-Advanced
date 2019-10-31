using System;
using System.Linq;

namespace _2._Square_With_Maximum_Sumpp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] par = Console.ReadLine().Split(", ", StringSplitOptions.None).Select(int.Parse).ToArray();
            int[,] matrix = new int[par[0], par[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(", ", StringSplitOptions.None).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int[,] maxMatrix = new int[2, 2];
            for (int i = 0; i < matrix.GetLength(0) - 1 ; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int[,] currentMatrix = new int[2, 2];
                    currentMatrix[0, 0] = matrix[i, j];
                    currentMatrix[0, 1] = matrix[i, j + 1];
                    currentMatrix[1, 0] = matrix[i + 1, j];
                    currentMatrix[1, 1] = matrix[i + 1, j + 1];
                    if (MatrixSum(currentMatrix) > MatrixSum(maxMatrix))
                    {
                        maxMatrix = currentMatrix;
                    }
                }
            }
            for (int i = 0; i < maxMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < maxMatrix.GetLength(1); j++)
                {
                    Console.Write(maxMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(MatrixSum(maxMatrix));
        }
        static int MatrixSum(int[,] matrix)
        {
            int sum = 0;
            sum += matrix[0, 0];
            sum += matrix[0, 1];
            sum += matrix[1, 0];
            sum += matrix[1, 1];
            return sum;
        }
    }
}
