using System;
using System.Linq;

namespace Problem_1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = x => Console.WriteLine(x);
            Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(action);
        }
    }
}
