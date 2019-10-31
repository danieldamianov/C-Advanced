using System;
using System.Linq;

namespace Problem_3._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Args = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = Args[0];
            int columns = Args[1];
            string[,] matrix = new string[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int counter = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    if ((matrix[i, j] == matrix[i + 1, j]) &&
                        (matrix[i, j] == matrix[i, j + 1]) &&
                        (matrix[i, j] == matrix[i + 1, j + 1]) )
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
