using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter("results.txt");
            StreamReader streamReader = new StreamReader("text.txt");
            StreamReader streamReader1 = new StreamReader("words.txt");
            using (streamWriter)
            {
                using (streamReader)
                {
                    using (streamReader1)
                    {
                        string text = streamReader.ReadToEnd().ToLower();
                        string word = streamReader1.ReadLine();
                        while (word != null)
                        {
                            streamWriter.WriteLine($"{word} - {Regex.Matches(text, $@"\b{word}\b").Count}");
                            word = streamReader1.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
