using System;
using System.Collections.Generic;

namespace sequenceWithQueue
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var sequence = new Queue<long>();
            var workingSeq = new Queue<long>();
            sequence.Enqueue(n);
            workingSeq.Enqueue(n);
            var s1 = n;
            for (int i = 0; i <= 50; i++)
            {
                var s2 = s1 + 1;
                sequence.Enqueue(s2);
                workingSeq.Enqueue(s2);
                var s3 = 2 * s1 + 1;
                sequence.Enqueue(s3);
                workingSeq.Enqueue(s3);
                var s4 = s1 + 2;
                sequence.Enqueue(s4);
                workingSeq.Enqueue(s4);

                workingSeq.Dequeue();
                s1 = workingSeq.Peek();

            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(sequence.Dequeue() + " ");
            }

        }
    }
}