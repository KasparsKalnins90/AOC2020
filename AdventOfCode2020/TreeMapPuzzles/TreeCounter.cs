using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.TreeMapPuzzles
{
    public static class TreeCounter
    {
        private static readonly string ExpenseReportPath =
            $"{Directory.GetCurrentDirectory()}\\PuzzleInputs\\TreeMap.txt";


        private static readonly List<string> PuzzleInput =
            File.ReadAllLines(ExpenseReportPath)
                .ToList();

        private static List<string> FullTreeMap { get; set; }

        private static void GetFullTreeMap()
        {
            FullTreeMap = PuzzleInput;
            while (FullTreeMap[1].Length  < PuzzleInput.Count * 3)
            {
               FullTreeMap = FullTreeMap.Select(line => line + line).ToList();
            }
        }

        public static void GetTreeCount()
        {
            GetFullTreeMap();
            var treeCount = 0;
            var locationOnY = 1;
            var locationOnX = 3;
            while (locationOnY < FullTreeMap.Count)
            {
                if (IsTree(FullTreeMap[locationOnY][locationOnX]))
                {
                    treeCount++;
                }
                locationOnX += 3;
                locationOnY += 1;
            }

            Console.WriteLine($"total tree count is {treeCount}");
        }

        private static bool IsTree(char marker)
        {
            return marker == '#';
        }
    }
}
