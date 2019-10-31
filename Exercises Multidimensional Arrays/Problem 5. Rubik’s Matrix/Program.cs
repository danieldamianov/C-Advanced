using System;
using System.Linq;

namespace Problem_5._Rubik_s_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            int[] Args = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = Args[0];
            int columns = Args[1];
            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = count;
                    count++;
                }
            }
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] currentCommand = Console.ReadLine().Split(' ');
                int numberOfRowOrColumn = int.Parse(currentCommand[0]);
                string direction = currentCommand[1];
                int moves = int.Parse(currentCommand[2]);
                switch (direction)
                {
                    case "up":
                        moves = moves % rows;
                        for (int move = 0; move < moves; move++)
                        {
                            int first = matrix[0, numberOfRowOrColumn];
                            for (int row = 0; row < rows - 1; row++)
                            {
                                matrix[row, numberOfRowOrColumn] = matrix[row + 1, numberOfRowOrColumn];
                            }
                            matrix[rows - 1, numberOfRowOrColumn] = first;
                        }
                        break;
                    case "down":
                        moves = moves % rows;
                        for (int move = 0; move < moves; move++)
                        {
                            int last = matrix[rows - 1, numberOfRowOrColumn];
                            for (int row = rows - 1; row >= 1; row--)
                            {
                                matrix[row, numberOfRowOrColumn] = matrix[row - 1, numberOfRowOrColumn];
                            }
                            matrix[0, numberOfRowOrColumn] = last;
                        }
                        break;
                    case "left":
                        moves = moves % columns;
                        for (int move = 0; move < moves; move++)
                        {
                            int first = matrix[numberOfRowOrColumn , 0];
                            for (int col = 0; col <= columns - 2; col++)
                            {
                                matrix[numberOfRowOrColumn , col] = matrix[numberOfRowOrColumn, col + 1];
                            }
                            matrix[numberOfRowOrColumn,columns - 1] = first;
                        }
                        break;
                    case "right":
                        moves = moves % columns;
                        for (int move = 0; move < moves; move++)
                        {
                            int last = matrix[numberOfRowOrColumn,columns - 1];
                            for (int col = columns - 1; col >= 1; col--)
                            {
                                matrix[numberOfRowOrColumn, col] = matrix[numberOfRowOrColumn, col - 1];
                            }
                            matrix[numberOfRowOrColumn, 0] = last;
                        }
                        break;
                }
            }
            count = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (matrix[row , col] == count)
                    {
                        Console.WriteLine($"No swap required");
                    }
                    else
                    {
                        bool found = false;
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                if (matrix[i , j] == count) 
                                {
                                    found = true;
                                    int temp = matrix[row, col];
                                    matrix[row, col] = matrix[i, j];
                                    matrix[i, j] = temp;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                    }
                    count++;
                }
            }
        }
    }
}
