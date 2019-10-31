using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> firstPlayerCards = new Queue<string>
                (Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            Queue<string> secondPlayerCards = new Queue<string>
                (Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            List<string> firstPlayerBattleField = new List<string>();

            List<string> secondPlayerBattleField = new List<string>();

            List<string> playedCards = new List<string>();

            int counterOfTurns = 0;
            while (true)
            {
                counterOfTurns++;
                playedCards.Clear();
                firstPlayerBattleField.Clear();
                secondPlayerBattleField.Clear();
                if (counterOfTurns == 1_00_000)
                {
                    if (firstPlayerCards.Count > secondPlayerCards.Count)
                    {
                        Console.WriteLine($"First player wins after 1000000 turns");
                    }
                    else if (firstPlayerCards.Count < secondPlayerCards.Count)
                    {
                        Console.WriteLine($"Second player wins after 1000000 turns");
                    }
                    else
                    {
                        Console.WriteLine($"Draw after 1000000 turns");
                    }
                    Environment.Exit(0);
                }
                if (firstPlayerCards.Count == 0)
                {
                    Console.WriteLine($"Second player wins after {counterOfTurns-1} turns");
                    Environment.Exit(0);
                }
                if (secondPlayerCards.Count == 0)
                {
                    Console.WriteLine($"First player wins after {counterOfTurns-1} turns");
                    Environment.Exit(0);
                }
                string firstPlayerCard = firstPlayerCards.Dequeue(); 
                string secondPlayerCard = secondPlayerCards.Dequeue();
                if (GetNumberFromCard(firstPlayerCard) != GetNumberFromCard(secondPlayerCard))
                {
                    if (GetNumberFromCard(firstPlayerCard) > GetNumberFromCard(secondPlayerCard))
                    {
                        firstPlayerCards.Enqueue(firstPlayerCard);
                        firstPlayerCards.Enqueue(secondPlayerCard);
                    }
                    else
                    {
                        secondPlayerCards.Enqueue(secondPlayerCard);
                        secondPlayerCards.Enqueue(firstPlayerCard);
                    }
                    continue;
                }
                playedCards.Add(firstPlayerCard);
                playedCards.Add(secondPlayerCard);
                while (true)
                {
                    firstPlayerBattleField.Clear();
                    secondPlayerBattleField.Clear();
                    if (firstPlayerCards.Count < 3 && secondPlayerCards.Count >= 3)
                    {
                        Console.WriteLine($"Second player wins after {counterOfTurns} turns");
                        Environment.Exit(0);
                    }
                    if (firstPlayerCards.Count >= 3 && secondPlayerCards.Count < 3)
                    {
                        Console.WriteLine($"First player wins after {counterOfTurns} turns");
                        Environment.Exit(0);
                    }
                    bool areLastCards = true;
                    if (firstPlayerCards.Count <= 3 && secondPlayerCards.Count <= 3)
                    {
                        if (firstPlayerCards.Count > secondPlayerCards.Count)
                        {
                            Console.WriteLine($"First player wins after {counterOfTurns} turns");
                            Environment.Exit(0);
                        }
                        if (secondPlayerCards.Count > firstPlayerCards.Count)
                        {
                            Console.WriteLine($"Second player wins after {counterOfTurns} turns");
                            Environment.Exit(0);
                        }
                        while (firstPlayerCards.Count!=0)
                        {
                            firstPlayerBattleField.Add(firstPlayerCards.Dequeue());
                        }
                        while (secondPlayerCards.Count != 0)
                        {
                            secondPlayerBattleField.Add(secondPlayerCards.Dequeue());
                        }
                        areLastCards = false;
                    }
                    else
                    {
                        firstPlayerBattleField.Add(firstPlayerCards.Dequeue());
                        firstPlayerBattleField.Add(firstPlayerCards.Dequeue());
                        firstPlayerBattleField.Add(firstPlayerCards.Dequeue());
                        secondPlayerBattleField.Add(secondPlayerCards.Dequeue());
                        secondPlayerBattleField.Add(secondPlayerCards.Dequeue());
                        secondPlayerBattleField.Add(secondPlayerCards.Dequeue());
                    }
                    int firstPlayerSum = 0;
                    int secondPlayerSum = 0;
                    foreach (var item in firstPlayerBattleField)
                    {
                        firstPlayerSum += (int)GetLetterFromCard(item) - 'a' + 1;
                    }
                    foreach (var item in secondPlayerBattleField)
                    {
                        secondPlayerSum += (int)GetLetterFromCard(item) - 'a' + 1;
                    }
                    playedCards.AddRange(firstPlayerBattleField);
                    playedCards.AddRange(secondPlayerBattleField);
                    if (firstPlayerSum > secondPlayerSum)
                    {
                        playedCards = playedCards.OrderByDescending(x => GetNumberFromCard(x)).ThenByDescending(x => GetLetterFromCard(x)).ToList();
                        foreach (var card in playedCards)
                        {
                            firstPlayerCards.Enqueue(card);
                        }
                        break;
                    }
                    if(secondPlayerSum > firstPlayerSum)
                    {
                        playedCards = playedCards.OrderByDescending(x => GetNumberFromCard(x)).ThenByDescending(x => GetLetterFromCard(x)).ToList();
                        foreach (var card in playedCards)
                        {
                            secondPlayerCards.Enqueue(card);
                        }
                        break;
                    }
                    if (areLastCards == false)
                    {
                        Console.WriteLine($"Draw after {counterOfTurns} turns");
                        Environment.Exit(0);
                    }
                }
            }
        }
        static int GetNumberFromCard(string card)
        {
            string num = card.Substring(0,card.Length - 1);
            return int.Parse(num);
        }
        static char GetLetterFromCard(string card)
        {
            return card[card.Length - 1]; 
        }
    }
}
