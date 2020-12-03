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

        private static readonly List<SlopeInfo> SlopesToCheck = new List<SlopeInfo>
        {
            new SlopeInfo {Down = 1, Right = 1},
            new SlopeInfo {Right = 3, Down = 1},
            new SlopeInfo {Right = 5, Down = 1},
            new SlopeInfo {Right = 7, Down = 1},
            new SlopeInfo {Right = 1, Down = 2},
        };

        private static List<string> FullTreeMap { get; set; }

        private static void GetFullTreeMap()
        {
            FullTreeMap = PuzzleInput;
            while (FullTreeMap[1].Length  < PuzzleInput.Count * 7)
            {
               FullTreeMap = FullTreeMap.Select(line => line + line).ToList();
            }
        }

        public static void GetTreeCountFromAllSlopes()
        {
            GetFullTreeMap();
            var totalTreeCount = 
                SlopesToCheck
                    .Aggregate<SlopeInfo, long>(1, (current, slope) => current * GetTreeCount(slope.Right, slope.Down));

            Console.WriteLine($"After checking all slopes, the total tree count is {totalTreeCount}");

        }
        private static int GetTreeCount(int right, int down){
            var treeCount = 0;
            var locationOnY = down;
            var locationOnX = right;
            while (locationOnY < FullTreeMap.Count)
            {
                if (IsTree(FullTreeMap[locationOnY][locationOnX]))
                {
                    treeCount++;
                }
                locationOnX += right;
                locationOnY += down;
            }

            Console.WriteLine($"total tree count is {treeCount}");
            return treeCount;
        }

        private static bool IsTree(char marker)
        {
            return marker == '#';
        }
    }

    public class SlopeInfo
    {
        public int Right { get; set; }
        public int Down { get; set; }
    }
}
