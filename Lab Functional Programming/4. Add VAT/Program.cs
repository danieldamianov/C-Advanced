using System;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<double> action1 = x => Console.WriteLine($"{x:f2}");
            Func<double,double> action = x => x * 1.2;
            Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(action)
                .ToList()
                .ForEach(action1);
        }
    }
}
