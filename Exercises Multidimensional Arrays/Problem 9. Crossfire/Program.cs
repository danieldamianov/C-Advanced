using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9._Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> matrix = new List<List<int>>();
            int[] matrixArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int columns = matrixArgs[1];
            int counter = 1;
            for (int i = 0; i < rows; i++)
            {
                matrix.Add(new List<int>());
                for (int j = 0; j < columns; j++)
                {
                    matrix[i].Add(counter);
                    counter++;
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Nuke it from orbit")
                {
                    break;
                }
                int[] commandArgs = input.Split(' ').Select(int.Parse).ToArray();
                int row = commandArgs[0];
                int col = commandArgs[1];
                int radius = commandArgs[2];
                for (int i = col - radius; i <= col + radius; i++)
                {
                    if (AreInside(row , i , matrix))
                    {
                        matrix[row][i] = 0;
                    }
                }
                for (int i = row - radius; i <= row + radius; i++)
                {
                    if (AreInside(i , col , matrix))
                    {
                        matrix[i][col] = 0;
                    }
                }
                for (int i = 0; i < matrix.Count; i++)
                {
                    matrix[i] = matrix[i].Where(x => x != 0).ToList();
                }
                matrix = matrix.Where(x => x.Any()).ToList();
            }
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }
        }
        static bool AreInside(int row , int col , List<List<int>> matrix)
        {
            if (row < 0 || row >= matrix.Count)
            {
                return false;
            }
            if (col < 0 || col >= matrix[row].Count)
            {
                return false;
            }
            return true;
        }
    }
}
