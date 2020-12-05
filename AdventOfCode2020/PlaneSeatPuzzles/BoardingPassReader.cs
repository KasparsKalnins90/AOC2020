using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.PlaneSeatPuzzles
{
    public static class BoardingPassReader
    {
        public static void GetHighestSeatId()
        {
            var puzzleInput = new PuzzleInputReader("BoardingPasses").PuzzleInfo;
            var seatIds = puzzleInput.Select(GetSeatId).ToList();
            
            Console.WriteLine($"the largest seat Id is {seatIds.Max()}");
            Console.WriteLine($"My seat number is {GetMySeatNumber(seatIds)}");
        }

        public static int GetMySeatNumber(IEnumerable<int> takenSeats)
        {
            var sortedSeatIds = takenSeats.OrderBy(x => x).ToList();
            var lowestSeatNumber = sortedSeatIds.Min();
            var highestSeatNumber = sortedSeatIds.Max();
            for (var i = lowestSeatNumber; i < highestSeatNumber; i++)
            {
                if (sortedSeatIds[i-lowestSeatNumber] != i)
                {
                    return i;
                }
            }

            return -1;
        }
        public static int GetSeatId(string boardingPassInfo)
        {
            var row = GetRow(boardingPassInfo.Substring(0, 7));
            var column = GetColumn(boardingPassInfo.Substring(7));
            return (row * 8) + column;
        }

        public static int GetColumn(string columnInfo)
        {
            var currentHalf = GetListOfIntegersCountingUpTo(8);
            foreach (var letter in columnInfo)
            {
                if (letter == 'R')
                {
                    currentHalf = GetUpperHalf(currentHalf);
                }
                else
                {
                    currentHalf = GetLowerHalf(currentHalf);
                }
            }

            return currentHalf[0];
        }
        public static int GetRow(string rowInfo)
        {
            var currentHalf = GetListOfIntegersCountingUpTo(128);

            foreach (var letter in rowInfo)
            {
                if (letter == 'B')
                {
                    currentHalf = GetUpperHalf(currentHalf);
                }
                else
                {
                    currentHalf = GetLowerHalf(currentHalf);
                }
            }

            return currentHalf[0];
        }

        public static List<int> GetUpperHalf(List<int> rows)
        {
            var upperHalf = rows.GetRange(rows.Count / 2, rows.Count /2);
            return upperHalf;
        }

        public static List<int> GetLowerHalf(List<int> rows)
        {
            var lowerHalf = rows.GetRange(0, rows.Count / 2);
            return lowerHalf;
        }

        public static List<int> GetListOfIntegersCountingUpTo(int numberOfIntegers)
        {
            var allRows = new List<int>();
            for (int i = 0; i < numberOfIntegers; i++)
            {
                allRows.Add(i);
            }

            return allRows;
        }
    }
}
