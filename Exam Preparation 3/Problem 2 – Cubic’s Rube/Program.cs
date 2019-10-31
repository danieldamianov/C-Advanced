using System;
using System.Linq;
using System.Numerics;

namespace Problem_2___Cubic_s_Rube
{
    class Program
    {
        static long size = long.Parse(Console.ReadLine());
        static void Main(string[] args)
        {
            BigInteger[,,] cube = new BigInteger[size, size, size];
            string input;
            BigInteger counter = 0;
            BigInteger sum = 0;
            while ((input = Console.ReadLine()) != "Analyze")
            {
                long[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                if (AreInside(tokens[0], tokens[1], tokens[2]) && tokens[3] != 0)
                {
                    counter++;
                    sum += tokens[3];
                    cube[tokens[0], tokens[1], tokens[2]] += tokens[3];
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(size * size * size - counter);

        }
        static bool AreInside(BigInteger f, BigInteger s, BigInteger t)
        {
            if (f < 0 || f >= size)
            {
                return false;
            }
            if (s < 0 || s >= size)
            {
                return false;
            }
            if (t < 0 || t >= size)
            {
                return false;
            }
            return true;
        }
    }
}
