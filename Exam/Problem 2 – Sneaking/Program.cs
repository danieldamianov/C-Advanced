using System;

namespace Problem_2___Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] room = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();
            }
            int cols = room[0].Length;
            char[] commands = Console.ReadLine().ToCharArray();
            foreach (var command in commands)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        if (room[row][col] == 'b' || room[row][col] == 'd')
                        {
                            if (room[row][col] == 'b' && col == room[row].Length - 1)
                            {
                                room[row][col] = 'd';
                            }
                            else if(room[row][col] == 'd' && col == 0)
                            {
                                room[row][col] = 'b';
                            }
                            else if (room[row][col] == 'b')
                            {
                                room[row][col + 1] = 'b';
                                room[row][col] = '.';
                                col++;
                            }
                            else
                            {
                                room[row][col - 1] = 'd';
                                room[row][col] = '.';
                            }
                        }
                    }
                }

                int[] samPos = new int[2];
                int[] nikolPos = new int[2];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < room[i].Length; j++)
                    {
                        if (room[i][j] == 'S')
                        {
                            samPos[0] = i;
                            samPos[1] = j;
                        }
                        if (room[i][j] == 'N')
                        {
                            nikolPos[0] = i;
                            nikolPos[1] = j;
                        }
                    }
                }
                for (int i = 0; i < cols; i++)
                {
                    if (room[samPos[0]][i] == 'b' && samPos[1] >= i) //!!!!!!!!!!!!!!!!!! <=
                    {
                        Console.WriteLine($"Sam died at {samPos[0]}, {samPos[1]}");
                        room[samPos[0]][samPos[1]] = 'X';
                        PrintMatrix(room);
                        Environment.Exit(0);
                    }
                    if (room[samPos[0]][i] == 'd' && samPos[1] <= i) //!!!!!!!!!!!!!!!!!!!!!! <=
                    {
                        Console.WriteLine($"Sam died at {samPos[0]}, {samPos[1]}");
                        room[samPos[0]][samPos[1]] = 'X';
                        PrintMatrix(room);
                        Environment.Exit(0);
                    }
                }
                switch (command)
                {
                    case 'U':
                        room[samPos[0] - 1][samPos[1]] = 'S';
                        room[samPos[0]][samPos[1]] = '.';
                        samPos[0]--;
                        break;
                    case 'D':
                        room[samPos[0] + 1][samPos[1]] = 'S';
                        room[samPos[0]][samPos[1]] = '.';
                        samPos[0]++;
                        break;
                    case 'L':
                        room[samPos[0]][samPos[1] - 1] = 'S';
                        room[samPos[0]][samPos[1]] = '.';
                        samPos[1]--;
                        break;
                    case 'R':
                        room[samPos[0]][samPos[1] + 1] = 'S';
                        room[samPos[0]][samPos[1]] = '.';
                        samPos[1]++;
                        break;
                }
                if (samPos[0] == nikolPos[0])
                {
                    Console.WriteLine($"Nikoladze killed!");
                    room[nikolPos[0]][nikolPos[1]] = 'X';
                    PrintMatrix(room);
                    Environment.Exit(0);
                }
                /*
                Console.WriteLine();
                PrintMatrix(room);
                Console.WriteLine();
                */
            }
        }

        private static void PrintMatrix(char [][] room)
        {
            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    Console.Write(room[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
