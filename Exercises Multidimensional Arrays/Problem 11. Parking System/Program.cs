using System;
using System.Linq;

namespace Problem_11._Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = matrixArgs[0];
            int columns = matrixArgs[1];
            bool[][] matrix = new bool[rows][];
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }
                int[] carArgs = input.Split(' ').Select(int.Parse).ToArray();
                int entryRow = carArgs[0];
                int slotRow = carArgs[1];
                int slotColumn = carArgs[2];
                if (matrix[slotRow] == null)
                {
                    matrix[slotRow] = new bool[columns];
                }
                if (slotRow < 0 || slotRow >= rows || slotColumn < 0 || slotColumn >= columns)
                {
                    continue;
                }
                int carDistance = 0;
                carDistance += Math.Abs(entryRow - slotRow) + 1;
                if (matrix[slotRow][slotColumn] == false)
                {
                    carDistance += slotColumn;
                    Console.WriteLine(carDistance);
                    matrix[slotRow][slotColumn] = true;
                    continue;
                }
                bool left = true;
                bool right = true;
                for (int i = 1; true ; i++)
                {
                    if (slotColumn - i < 1 && slotColumn + i >= columns)
                    {
                        Console.WriteLine($"Row {slotRow} full");
                        break;
                    }
                    if (slotColumn - i < 1)
                    {
                        left = false;
                    }
                    if (slotColumn + i >= columns)
                    {
                        right = false;
                    }
                    if (left)
                    {
                        if (matrix[slotRow][slotColumn - i] == false)
                        {
                            matrix[slotRow][slotColumn - i] = true;
                            carDistance += slotColumn - i;
                            Console.WriteLine(carDistance);
                            break;
                        }
                    }
                    if (right)
                    {
                        if (matrix[slotRow][slotColumn + i] == false)
                        {
                            matrix[slotRow][slotColumn + i] = true;
                            carDistance += slotColumn + i;
                            Console.WriteLine(carDistance);
                            break;
                        }
                    }
                }
            }
        }
    }
}
