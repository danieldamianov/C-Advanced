using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Jedi_Galaxy
{
    class Program
    {
        static long[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        static long rows = dimensions[0];
        static long cols = dimensions[1];
        static int[,] matrix = new int[rows, cols];
        static void Main(string[] args)
        {
            long ivoAmount = 0;
            int counter = 0;
            for (long i = 0; i < rows; i++)
            {
                for (long j = 0; j < cols; j++)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                long[] ivoPos = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                long[] evilPos = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                long ivoRow = ivoPos[0];
                long ivoCol = ivoPos[1];
                long evilRow = evilPos[0];
                long evilCol = evilPos[1];
                counter = 0;
                while (AreInside(evilRow, evilCol) == false)
                {
                    evilRow--;
                    evilCol--;
                    counter++;
                    if (counter == 1000)
                    {
                        break;
                    }
                }
                while (AreInside(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                    evilRow--;
                    evilCol--;
                }
                counter = 0;
                while (AreInside(ivoRow, ivoCol) == false)
                {
                    ivoRow--;
                    ivoCol++;
                    counter++;
                    if (counter == 1000)
                    {
                        break;
                    }
                }
                while (AreInside(ivoRow, ivoCol))
                {
                    ivoAmount += matrix[ivoRow, ivoCol];
                    ivoRow--;
                    ivoCol++;
                }
            }
            Console.WriteLine(ivoAmount);
        }
        static bool AreInside(long row, long col)
        {
            if (row >= rows || row < 0)
            {
                return false;
            }
            if (col >= cols || col < 0)
            {
                return false;
            }
            return true;
        }
    }
}
