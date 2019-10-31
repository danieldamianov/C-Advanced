using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = x => Console.WriteLine(x);
            Func<string, bool> func = str => char.IsUpper(str[0]);
            Console
                .ReadLine()
                .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Where(func)
                .ToList()
                .ForEach(action);
        }
    }
}
