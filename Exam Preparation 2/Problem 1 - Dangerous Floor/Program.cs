using System;

namespace Problem_1___Dangerous_Floor
{
    class Program
    {
        const int size = 8;
        static bool AreInside(int rows , int columns)
        {
            if (rows < 0 || rows >= size)
            {
                return false;
            }
            if (columns < 0 || columns >= size)
            {
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            char[,] board = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                string[] line = Console.ReadLine().Split(',');
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = line[j][0];
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                char figure = command[0];
                int currentRow = int.Parse(command[1].ToString());
                int currentColumn = int.Parse(command[2].ToString());
                int finalRow = int.Parse(command[4].ToString());
                int finalColumn = int.Parse(command[5].ToString());
                if (board[currentRow,currentColumn] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                bool checkForThird = true;
                switch (figure)
                {
                    case 'K':
                        bool isValid = false;
                        if ((currentRow == finalRow && currentColumn == finalColumn - 1)||
                            (currentRow == finalRow && currentColumn == finalColumn + 1) ||
                            (currentRow == finalRow + 1 && currentColumn == finalColumn + 1) ||
                            (currentRow == finalRow + 1 && currentColumn == finalColumn) ||
                            (currentRow == finalRow + 1 && currentColumn == finalColumn - 1) ||
                            (currentRow == finalRow - 1 && currentColumn == finalColumn + 1) ||
                            (currentRow == finalRow - 1 && currentColumn == finalColumn) ||
                            (currentRow == finalRow - 1 && currentColumn == finalColumn - 1) )
                        {
                            isValid = true;
                        }
                        if (isValid == false)
                        {
                            Console.WriteLine("Invalid move!");
                            checkForThird = false;
                        }
                        break;
                    case 'R':
                        bool isValid1 = false;
                        if (currentRow == finalRow || currentColumn == finalColumn)
                        {
                            isValid1 = true;
                        }
                        if (isValid1 == false)
                        {
                            Console.WriteLine("Invalid move!");
                            checkForThird = false;
                        }
                        break;
                    case 'B':
                        bool isValid2 = false;
                        if (Math.Abs(currentRow - finalRow) == Math.Abs(currentColumn - finalColumn))
                        {
                            isValid2 = true;
                        }
                        if (isValid2 == false)
                        {
                            Console.WriteLine("Invalid move!");
                            checkForThird = false;
                        }
                        break;
                    case 'Q':
                        bool isValid4 = false;
                        if (Math.Abs(currentRow - finalRow) == Math.Abs(currentColumn - finalColumn) || currentRow == finalRow || currentColumn == finalColumn)
                        {
                            isValid4 = true;
                        }
                        if (isValid4 == false)
                        {
                            Console.WriteLine("Invalid move!");
                            checkForThird = false;
                        }
                        break;
                    case 'P':
                        bool isValid3 = false;
                        if (currentRow == finalRow + 1 && currentColumn == finalColumn)
                        {
                            isValid3 = true;
                        }
                        if (isValid3 == false)
                        {
                            Console.WriteLine("Invalid move!");
                            checkForThird = false;
                        }
                        break;
                }
                if (checkForThird)
                {
                    if (AreInside(finalRow, finalColumn) == false)
                    {
                        Console.WriteLine("Move go out of board!");
                    }
                    else
                    {
                        board[currentRow, currentColumn] = 'x';
                        board[finalRow, finalColumn] = figure;
                    }
                }
            }
        }
    }
}
