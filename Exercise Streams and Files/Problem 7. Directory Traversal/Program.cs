using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_7._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();
            string[] files = Directory.GetFiles(directoryPath);
            Dictionary<string, List<FileInfo>> dictionary = new Dictionary<string, List<FileInfo>>();
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                if (dictionary.ContainsKey(extension) == false)
                {
                    dictionary.Add(extension, new List<FileInfo>());
                }
                dictionary[extension].Add(fileInfo);
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
                        writer.WriteLine($"--{file.Name} - {(double)file.Length / 1024 :f3}kb");
                    }
                }
            }
        }
    }
}
