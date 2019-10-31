using System;
using System.IO;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("text.txt");
            StreamWriter streamWriter = new StreamWriter("output.txt");
            using (streamReader)
            {
                using (streamWriter)
                {
                    int counter = 1;
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        streamWriter.WriteLine($"Line {counter}: {line}");
                        line = streamReader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
