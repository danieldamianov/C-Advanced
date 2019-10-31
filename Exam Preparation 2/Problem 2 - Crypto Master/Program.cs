using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ',','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int lengthOfSequence = numbers.Length;
            int bestSequenceLength = 0;
            for (int counterOfTheStep = 1; counterOfTheStep < lengthOfSequence; counterOfTheStep++)
            {
                for (int counterOfStartingPosition = 0; counterOfStartingPosition < lengthOfSequence; counterOfStartingPosition++)
                {
                    int currentPosition = counterOfStartingPosition;
                    int currentSequenceLength = 1;
                    while (true)
                    {
                        int targetPosition = (currentPosition + counterOfTheStep) % lengthOfSequence;
                        if (numbers[targetPosition] <= numbers[currentPosition])
                        {
                            break;
                        }
                        currentSequenceLength++;
                        currentPosition = targetPosition;
                    }
                    if (bestSequenceLength < currentSequenceLength)
                    {
                        bestSequenceLength = currentSequenceLength;
                    }
                }
            }
            Console.WriteLine(bestSequenceLength);
        }
    }
}
