using System;
using System.IO;

namespace Problem_4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("sliceMe.mp4", FileMode.Open,FileAccess.Read);
            FileStream fileStreamOutput = new FileStream("sliceMeCopied.mp4", FileMode.Create,FileAccess.Write);
            using (fileStream)
            {
                using (fileStreamOutput)
                {
                    while (true)
                    {
                        byte[] bytes = new byte[4096];
                        int readBytes = fileStream.Read(bytes, 0, bytes.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        fileStreamOutput.Write(bytes, 0, readBytes);
                    }
                }
            }
        }
    }
}
