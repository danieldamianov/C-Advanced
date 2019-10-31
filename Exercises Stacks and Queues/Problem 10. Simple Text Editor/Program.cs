using System;
using System.Text;
using System.Collections.Generic;

namespace Problem_10._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            StringBuilder text = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "1")
                {
                    stack.Push(text.ToString());
                    text.Append(command[1]);
                }
                else if (command[0] == "2")
                {
                    stack.Push(text.ToString());
                    text.Remove(text.Length - int.Parse(command[1]), int.Parse(command[1]));
                }
                else if (command[0] == "3")
                {
                    Console.WriteLine(text[int.Parse(command[1]) - 1]);
                }
                else if (command[0] == "4")
                {
                    text = new StringBuilder(stack.Pop());
                }
            }
        }
    }
}
