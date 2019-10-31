using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1___Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> locks = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse().Select(int.Parse));
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            int bulletValueUsed = 0;
            int counterOfBarrel = 0;
            while (true)
            {
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfIntelligence - bulletValueUsed}");
                    Environment.Exit(0);
                }
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    Environment.Exit(0);
                }
                var bullet = bullets.Pop();
                var locker = locks.Peek();
                if (bullet <= locker)
                {
                    Console.WriteLine("Bang!");
                    locks.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                bulletValueUsed += pricePerBullet;
                counterOfBarrel++;
                if (counterOfBarrel == sizeOfBarrel && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    counterOfBarrel = 0;
                }
            }
        }
    }
}
