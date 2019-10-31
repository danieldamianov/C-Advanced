using System;
using System.Collections.Generic;

namespace Problem_1___Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> masterList = new List<string>();
            List<string> knightList = new List<string>();
            List<string> padawainList = new List<string>();
            List<string> othersList = new List<string>();
            bool existsYoda = false;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                foreach (var jedi in Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries))
                {
                    switch (jedi[0])
                    {
                        case 'y':
                            existsYoda = true;
                            break;
                        case 'm':
                            masterList.Add(jedi);
                            break;
                        case 'k':
                            knightList.Add(jedi);
                            break;
                        case 'p':
                            padawainList.Add(jedi);
                            break;
                        default:
                            othersList.Add(jedi);
                            break;
                    }
                }
            }
            if (existsYoda)
            {
                Console.WriteLine($"{string.Join(" ",masterList)} {string.Join(" ",knightList)} {string.Join(" ",othersList)} {string.Join(" ",padawainList)}");
            }
            else
            {
                Console.WriteLine($"{string.Join(" ", othersList)} {string.Join(" ", masterList)} {string.Join(" ", knightList)} {string.Join(" ", padawainList)}");
            }
        }
    }
}
