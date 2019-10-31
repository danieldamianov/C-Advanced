using System;
using System.Collections.Generic;
using System.IO;

namespace Problem_5._Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>
            {
                "a.txt",
                "b.txt",
            };
            Slice("sliceMe.txt", @"D:\външна памет\Dani's docs\C#\C# Advanced\Exercise Streams and Files\Problem 5. Slicing File", 10);
            Assemble(list, @"D:\външна памет\Dani's docs\C#\C# Advanced\Exercise Streams and Files\Problem 5. Slicing File");
        }
        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long lengthOfEachPart = (long)Math.Ceiling((double)reader.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentLengthOfPart = 0;
                    string filePath = destinationDirectory + $@"\part{i}.{sourceFile.Substring(sourceFile.LastIndexOf('.') + 1)}";
                    using (FileStream writer = new FileStream(filePath,FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (reader.Read(buffer,0,4096) != 0)
                        {
                            writer.Write(buffer, 0, 4096);
                            currentLengthOfPart += 4096;
                            if (currentLengthOfPart >= lengthOfEachPart)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        static void Assemble(List<string> files, string destinationDirectory)
        {
            string fileDirect = destinationDirectory + @"\Zaedno." + files[0].Substring(files[0].LastIndexOf('.') + 1);
            using (FileStream write = new FileStream(fileDirect, FileMode.Create))
            {
                foreach (var file in files)
                {
                    byte[] buffer = new byte[4096];
                    using (FileStream read = new FileStream(file,FileMode.Open))
                    {
                        while (true)
                        {
                            int readB = read.Read(buffer, 0, 4096);
                            if (readB == 0)
                            {
                                break;
                            }
                            write.Write(buffer, 0, readB);
                        }
                    }
                }
            }
        }
    }
}
