using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_8._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Args = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = Args[0];
            int columns = Args[1];
            char[,] matrix = new char[rows, columns];
            int playerRow = 0;
            int playerCol = 0;
            for (int i = 0; i < rows; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = row[j];
                    if (matrix[i, j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
            string commands = Console.ReadLine();
            foreach (var command in commands)
            {
                bool onRabbit = false;
                bool outOfTheBoard = false;
                switch (command)
                {
                    case 'U':
                        if (playerRow - 1 < 0)
                        {
                            outOfTheBoard = true;
                            matrix[playerRow, playerCol] = '.';
                            break;
                        }
                        if (matrix[playerRow - 1,playerCol] == 'B')
                        {
                            onRabbit = true;
                            matrix[playerRow, playerCol] = '.';
                            playerRow--;
                            break;
                        }
                        matrix[playerRow, playerCol] = '.';
                        matrix[playerRow - 1, playerCol] = 'P';
                        playerRow--;
                        break;
                    case 'D':
                        if (playerRow + 1 >= rows)
                        {
                            outOfTheBoard = true;
                            matrix[playerRow, playerCol] = '.';
                            break;
                        }
                        if (matrix[playerRow + 1, playerCol] == 'B')
                        {
                            onRabbit = true;
                            matrix[playerRow, playerCol] = '.';
                            playerRow++;
                            break;
                        }
                        matrix[playerRow, playerCol] = '.';
                        matrix[playerRow + 1, playerCol] = 'P';
                        playerRow++;
                        break;
                    case 'L':
                        if (playerCol - 1 < 0)
                        {
                            outOfTheBoard = true;
                            matrix[playerRow, playerCol] = '.';
                            break;
                        }
                        if (matrix[playerRow, playerCol - 1] == 'B')
                        {
                            onRabbit = true;
                            matrix[playerRow, playerCol] = '.';
                            playerCol--;
                            break;
                        }
                        matrix[playerRow, playerCol] = '.';
                        matrix[playerRow, playerCol - 1] = 'P';
                        playerCol--;
                        break;
                    case 'R':
                        if (playerCol + 1 >= columns)
                        {
                            outOfTheBoard = true;
                            matrix[playerRow, playerCol] = '.';
                            break;
                        }
                        if (matrix[playerRow, playerCol + 1] == 'B')
                        {
                            onRabbit = true;
                            matrix[playerRow, playerCol] = '.';
                            playerCol++;
                            break;
                        }
                        matrix[playerRow, playerCol] = '.';
                        matrix[playerRow, playerCol + 1] = 'P';
                        playerCol++;
                        break;
                }
                List<int[]> list = new List<int[]>();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (matrix[i,j] == 'B')
                        {
                            list.Add(new int[] { i, j });
                        }
                    }
                }
                bool bunnyOnPlayer = false;
                foreach (var bunny in list)
                {
                    if (AreInside(bunny[0] + 1 , bunny[1],rows,columns))
                    {
                        if (matrix[bunny[0] + 1, bunny[1]] == 'P')
                        {
                            bunnyOnPlayer = true;
                            playerRow = bunny[0] + 1;
                            playerCol = bunny[1];
                        }
                        matrix[bunny[0] + 1, bunny[1]] = 'B';
                    }
                    if (AreInside(bunny[0] - 1, bunny[1], rows, columns))
                    {
                        if (matrix[bunny[0] - 1, bunny[1]] == 'P')
                        {
                            bunnyOnPlayer = true;
                            playerRow = bunny[0] - 1;
                            playerCol = bunny[1];
                        }
                        matrix[bunny[0] - 1, bunny[1]] = 'B';
                    }
                    if (AreInside(bunny[0], bunny[1] + 1, rows, columns))
                    {
                        if (matrix[bunny[0], bunny[1] + 1] == 'P')
                        {
                            bunnyOnPlayer = true;
                            playerRow = bunny[0];
                            playerCol = bunny[1] + 1;
                        }
                        matrix[bunny[0], bunny[1] + 1] = 'B';
                    }
                    if (AreInside(bunny[0], bunny[1] - 1, rows, columns))
                    {
                        if (matrix[bunny[0], bunny[1] - 1] == 'P')
                        {
                            bunnyOnPlayer = true;
                            playerRow = bunny[0];
                            playerCol = bunny[1] - 1;
                        }
                        matrix[bunny[0], bunny[1] - 1] = 'B';
                    }
                }
                if (outOfTheBoard || bunnyOnPlayer || onRabbit)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            Console.Write(matrix[i, j]);
                        }
                        Console.WriteLine();
                    }
                    if (outOfTheBoard)
                    {
                        Console.WriteLine($"won: {playerRow} {playerCol}");
                    }
                    else
                    {
                        Console.WriteLine($"dead: {playerRow} {playerCol}");
                    }
                    Environment.Exit(0);
                }
            }
        }
        static bool AreInside(int row, int col, int rows, int columns)
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
