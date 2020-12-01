using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public static class ExpenseReportCalculator
    {
        private static readonly string ExpenseReportPath =
            $"{Directory.GetCurrentDirectory()}\\PuzzleInputs\\expenseReport.txt";


        private static readonly List<int> PuzzleInput = 
            File.ReadAllLines(ExpenseReportPath)
                .Select(int.Parse)
                .ToList();
        public static void Get2020FromTwoNumbers()
        {
            foreach (var number in PuzzleInput)
            {
                if (PuzzleInput.Any(otherNumber => (number + otherNumber) == 2020))
                {
                    Console.WriteLine($"{number},{2020-number} and their multiplication is {number *(2020-number)}");
                    break;
                }
            }
        }

        public static void Get2020FromThreeNumbers()
        {
            //there must be a better readable way than a nested for loop :)
            for (int i = 0; i < PuzzleInput.Count; i++)
            {
                for (int j = 0; j < PuzzleInput.Count-1; j++)
                {
                    for (int k = 0; k < PuzzleInput.Count-2; k++)
                    {
                        if (PuzzleInput[i] + PuzzleInput[j] + PuzzleInput[k] == 2020)
                        {
                            Console.WriteLine($"{PuzzleInput[i]}, {PuzzleInput[j]}, {PuzzleInput[k]}, and their multiplication: {PuzzleInput[i] * PuzzleInput[j] * PuzzleInput[k]}");
                            return;
                        }
                    }
                }
            }
        }
    }
}
