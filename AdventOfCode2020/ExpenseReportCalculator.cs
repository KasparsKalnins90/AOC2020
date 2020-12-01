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
        public static void Get2020()
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
    }
}
