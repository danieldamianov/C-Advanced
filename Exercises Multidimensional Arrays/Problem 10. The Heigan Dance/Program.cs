using System;
using System.Collections.Generic;

namespace Problem_10._The_Heigan_Dance
{
    class Program
    {
        static int playerRow = 7;
        static int playerCol = 7;
        static double playerHealth = 18500;
        static double heiganHealth = 3000000;
        static double playersDamage = double.Parse(Console.ReadLine());
        static string command = "";
        static void Main(string[] args)
        {
            while (true)
            {
                string[] shotArgs = Console.ReadLine().Split(' ');
                string magic = shotArgs[0];
                int shotRow = int.Parse(shotArgs[1]);
                int shotColumn = int.Parse(shotArgs[2]);
                List<int[]> cells = new List<int[]>();
                for (int i = shotRow - 1; i <= shotRow + 1; i++)
                {
                    for (int j = shotColumn - 1; j <= shotColumn + 1; j++)
                    {
                        if (AreInside(i, j))
                        {
                            cells.Add(new int[] { i, j });
                        }
                    }
                }
                if (cells.Exists(x => x[0] == playerRow && x[1] == playerCol) == false)
                {
                    Check();
                    continue;
                }
                if (AreInside(playerRow - 1, playerCol) && cells.Exists(x => x[0] == playerRow - 1 && x[1] == playerCol) == false)
                {
                    Check();
                    playerRow--;
                    continue;
                }
                else if (AreInside(playerRow, playerCol + 1) && !cells.Exists(x => x[0] == playerRow && x[1] == playerCol + 1))
                {
                    Check();
                    playerCol++;
                    continue;
                }
                else if (AreInside(playerRow + 1, playerCol) && !cells.Exists(x => x[0] == playerRow + 1 && x[1] == playerCol))
                {
                    Check();
                    playerRow++;
                    continue;
                }
                else if (AreInside(playerRow, playerCol - 1) && !cells.Exists(x => x[0] == playerRow && x[1] == playerCol - 1))
                {
                    Check();
                    playerCol--;
                    continue;
                }
                heiganHealth -= playersDamage;
                if (command == "Cloud")
                {
                    playerHealth -= 3500;
                }
                if (playerHealth <= 0 || heiganHealth <= 0)
                {
                    if (heiganHealth <= 0)
                    {
                        Console.WriteLine("Heigan: Defeated!");
                    }
                    else
                    Console.WriteLine($"Heigan: {heiganHealth:f2}");
                    if (playerHealth <= 0)
                    {
                        Console.WriteLine($"Player: Killed by Plague Cloud");
                    }
                    else
                    Console.WriteLine($"Player: {playerHealth}");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                    return;
                }
                if (magic == "Cloud")
                {
                    playerHealth -= 3500;
                }
                else
                {
                    playerHealth -= 6000;
                }
                command = magic;
                if (playerHealth <= 0)
                {
                    Console.WriteLine($"Heigan: {heiganHealth:f2}");
                    if (magic == "Eruption")
                    {
                        Console.WriteLine($"Player: Killed by Eruption");
                    }
                    else
                    {
                        Console.WriteLine($"Player: Killed by Plague Cloud");
                    }
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                    return;
                }
            }
        }
        static bool AreInside(int rows, int columns)
        {
            if (rows < 0 || rows >= 15)
            {
                return false;
            }
            if (columns < 0 || columns >= 15)
            {
                return false;
            }
            return true;
        }
        static void Check()
        {
            heiganHealth -= playersDamage;
            if (heiganHealth <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                if (command == "Cloud")
                {
                    playerHealth -= 3500;
                    if (playerHealth <= 0)
                    {
                        Console.WriteLine($"Player: Killed by Plague Cloud");
                    }
                    else
                    {
                        Console.WriteLine($"Player: {playerHealth}");
                    }
                }
                else
                Console.WriteLine($"Player: {playerHealth}");
                Console.WriteLine($"Final position: {playerRow}, {playerCol}");
                Environment.Exit(0);
            }
        }
    }
}
