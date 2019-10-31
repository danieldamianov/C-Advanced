using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Args = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = Args[0];
            int columns = Args[1];
            string snake = Console.ReadLine();
            char[,] matrix = new char[rows, columns];
            bool order = false;
            int count = 0;
            for (int row = rows - 1; row >= 0; row--)
            {
                if (!order)
                {
                    for (int col = columns - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[count % snake.Length];
                        count++;
                    }
                }
                else
                {
                    for (int col = 0; col < columns; col++)
                    {
                        matrix[row, col] = snake[count % snake.Length];
                        count++;
                    }
                }
                order = !order;
            }
            int[] shotArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rowShot = shotArgs[0];
            int colShot = shotArgs[1];
            int radius = shotArgs[2];
            int sum = radius * radius;
            for (int row = rowShot - radius; row <= rowShot + radius; row++)
            {
                for (int col = colShot - radius; col <= colShot + radius; col++)
                {
                    if (((rowShot - row) * (rowShot - row) + (colShot - col) * (colShot - col)) <= sum)
                    {
                        if (AreInside(row,col,rows,columns))
                        {
                            matrix[row, col] = ' ';
                        }
                    }
                }
            }
            for (int col = 0; col < columns; col++)
            {
                Stack<char> stack = new Stack<char>();
                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row,col] != ' ')
                    {
                        stack.Push(matrix[row, col]);
                    }
                }
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (stack.Any())
                    {
                        matrix[row, col] = stack.Pop();
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "");
                }
                Console.WriteLine();
            }
        }
        static bool AreInside(int row , int col, int rows , int columns)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= columns)
            {
                return false;
            }
            return true;
        }
    }
}
