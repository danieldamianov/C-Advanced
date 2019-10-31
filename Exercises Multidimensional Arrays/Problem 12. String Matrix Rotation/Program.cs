using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_12._String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Match match = Regex.Match(input, @"^Rotate\((?<degrees>[0-9]+)\)$");
            int degrees = int.Parse(match.Groups["degrees"].Value) % 360;
            List<string> list = new List<string>();
            int maxLength = 0;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                list.Add(line);
                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }
            char[,] matrix = new char[list.Count,maxLength];
            for (int i = 0; i < list.Count; i++)
            {
                char[] arr = list[i].ToCharArray();
                for (int j = 0; j < arr.Length; j++)
                {
                    matrix[i, j] = arr[j];
                }
                for (int j = arr.Length; j < maxLength; j++)
                {
                    matrix[i, j] = ' ';
                }
            }
            /*for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }*/
            switch (degrees)
            {
                case 0:
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write(matrix[i, j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 90:
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        for (int j = matrix.GetLength(0) - 1; j >= 0; j--)
                        {
                            Console.Write(matrix[j, i]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 180:
                    for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                    {
                        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                        {
                            Console.Write(matrix[i, j]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 270:
                    for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            Console.Write(matrix[j, i]);
                        }
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}
