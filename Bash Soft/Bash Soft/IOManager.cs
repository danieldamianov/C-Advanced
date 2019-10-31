using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bash_Soft
{
    public static class IOManager
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split(@"\").Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(path);
            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split(@"\").Length - initialIdentation;
                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");
            }
        }
    }
}
