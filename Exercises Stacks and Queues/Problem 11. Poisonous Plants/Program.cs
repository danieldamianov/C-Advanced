using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach (var num in elements)
            {
                stack.Push(num);
            }*/
            







            
            int dayCounter = 0;
            int n = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            foreach (var item in elements.Reverse())
            {
                queue.Enqueue(item);
            }
            bool isDead = true;
            while (isDead)
            {
                isDead = false;
                int count = queue.Count;
                for (int i = 0; i < count - 1; i++)
                {
                    int currentPlant = queue.Dequeue();
                    if (currentPlant <= queue.Peek())
                    {
                        queue.Enqueue(currentPlant);
                    }
                    else
                    {
                        isDead = true;
                    }
                }
                queue.Enqueue(queue.Dequeue());
                queue.TrimExcess();
                dayCounter++;
            }
            Console.WriteLine(dayCounter - 1);
        }
    }
}
