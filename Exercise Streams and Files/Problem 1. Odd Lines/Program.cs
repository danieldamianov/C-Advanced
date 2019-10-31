using System;
using System.IO;

namespace Problem_1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader("text.txt");
            using (stream)
            {
                int counter = 0;
                string line = stream.ReadLine();
                while (line != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = stream.ReadLine();
                }
            }
        }
    }
}
