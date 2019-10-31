using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_8._Full_Directory_Traversal
{
    class Program
    {
        static List<FileInfo> files = new List<FileInfo>();
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();
            GetAllFiles(directoryPath);
            Dictionary<string, List<FileInfo>> dictionary = new Dictionary<string, List<FileInfo>>();
            foreach (var file in files)
            {
                string extension = file.Extension;
                if (dictionary.ContainsKey(extension) == false)
                {
                    dictionary.Add(extension, new List<FileInfo>());
                }
                dictionary[extension].Add(file);
                dictionary = dictionary.OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, y => y.Value);

            }
            using (var writer = new StreamWriter("report.txt"))
            {
                foreach (var ext in dictionary)
                {
                    writer.WriteLine(ext.Key);
                    foreach (var file in ext.Value.OrderBy(x => x.Length))
                    {
                        writer.WriteLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                    }
                }
            }
        }
        static void GetAllFiles(string directoryPath)
        {
            foreach (var file in Directory.GetFiles(directoryPath))
            {
                files.Add(new FileInfo(file));
            }
            foreach (var direct in Directory.GetDirectories(directoryPath))
            {
                GetAllFiles(direct);
            }
        }
    }
}
