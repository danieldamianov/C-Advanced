using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Problem_5._Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>
            {
                "part0.mp4.gz",
                "part1.mp4.gz",
                "part2.mp4.gz",
                "part3.mp4.gz",
                "part4.mp4.gz",
                "part5.mp4.gz",
                "part6.mp4.gz",
                "part7.mp4.gz",
                "part8.mp4.gz",
                "part9.mp4.gz",
            };
            Slice("dff.mp4", @"D:\външна памет\Dani's docs\C#\C# Advanced\Exercise Streams and Files\Problem 6. Zipping Sliced Files", 10);
            Assemble(list, @"D:\външна памет\Dani's docs\C#\C# Advanced\Exercise Streams and Files\Problem 6. Zipping Sliced Files");
        }
        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long lengthOfEachPart = (long)Math.Ceiling((double)reader.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentLengthOfPart = 0;
                    string filePath = destinationDirectory + $@"\part{i}.{sourceFile.Substring(sourceFile.LastIndexOf('.') + 1)}.gz";
                    using (GZipStream writer = new GZipStream(new FileStream(filePath, FileMode.Create),CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[4096];
                        while (reader.Read(buffer, 0, 4096) != 0)
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
            string fileDirect = destinationDirectory + @"\Zaedno." + files[0].Substring(files[0].LastIndexOf('.') + 1) + ".gz";
            using (GZipStream write = new GZipStream(new FileStream(fileDirect, FileMode.Create),CompressionLevel.Optimal))
            {
                foreach (var file in files)
                {
                    byte[] buffer = new byte[4096];
                    using (FileStream read = new FileStream(file, FileMode.Open))
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
