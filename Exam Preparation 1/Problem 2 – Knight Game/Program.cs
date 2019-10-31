using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Knight_Game
{
    class Field
    {
        public int row { get; set; }
        public int column { get; set; }
        public Field(int r, int c)
        {
            this.row = r;
            this.column = c;
        }
    }
    class Knight
    {
        public int NumberOfKnightsInterlocing { get; set; }
        public int row { get; set; }
        public int column { get; set; }
        public Knight()
        {

        }
        public Knight(int r,int c,int n)
        {
            this.row = r;
            this.column = c;
            this.NumberOfKnightsInterlocing = n;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = line[j];
                }
            }
            int counter = 0;
            while (true)
            {
                List<Knight> knightsOnBoard = new List<Knight>();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (board[i,j] == 'K')
                        {
                            knightsOnBoard.Add(new Knight(i, j,0));
                        }
                    }
                }
                foreach (Knight knight in knightsOnBoard)
                {
                    List<Field> attackingFields = GetAttackingFields(knight, size);
                    foreach (Field field in attackingFields)
                    {
                        if (board[field.row,field.column] == 'K')
                        {
                            knight.NumberOfKnightsInterlocing++;
                        }
                    }
                }
                Knight NapadatelenKnight = new Knight();
                int maxAttacks = -1;
                foreach (var knight in knightsOnBoard)
                {
                    if (knight.NumberOfKnightsInterlocing > maxAttacks)
                    {
                        maxAttacks = knight.NumberOfKnightsInterlocing;
                        NapadatelenKnight.row = knight.row;
                        NapadatelenKnight.column = knight.column;
                        NapadatelenKnight.NumberOfKnightsInterlocing = maxAttacks;
                    }
                }
                if (maxAttacks == 0)
                {
                    Console.WriteLine(counter);
                    Environment.Exit(0);
                }
                counter++;
                board[NapadatelenKnight.row, NapadatelenKnight.column] = '0';
            }
        }
        static bool AreInside(int row, int col, int size)
        {
            if (row < 0 || row >= size)
            {
                return false;
            }
            if (col < 0 || col >= size)
            {
                return false;
            }
            return true;
        }
        static List<Field> GetAttackingFields(Knight knight,int size)
        {
            List<Field> list = new List<Field>()
            {
                new Field(knight.row - 2 , knight.column + 1),
                new Field(knight.row - 2 , knight.column - 1),
                new Field(knight.row + 2 , knight.column + 1),
                new Field(knight.row + 2 , knight.column - 1),
                new Field(knight.row + 1 , knight.column - 2),
                new Field(knight.row - 1 , knight.column - 2),
                new Field(knight.row + 1 , knight.column + 2),
                new Field(knight.row - 1 , knight.column + 2)
            };
            List<Field> returnList = new List<Field>();
            foreach (Field field in list)
            {
                if (AreInside(field.row,field.column,size))
                {
                    returnList.Add(field);
                }
            }
            return returnList;
        }
    }
}
