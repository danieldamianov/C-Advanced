using System;
using System.IO;
using System.Text;

namespace Lab_Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "In-memory text.";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            using (var memoryStream = new MemoryStream(bytes))
            {
                while (true)
                {
                    int readByte = memoryStream.ReadByte();
                    if (readByte == -1)
                        break;
                    Console.Write((char)readByte);
                }
            }
            Console.WriteLine();
        }
    }
}
