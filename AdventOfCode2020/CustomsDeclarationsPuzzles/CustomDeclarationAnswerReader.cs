using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.CustomsDeclarationsPuzzles
{
    public class CustomDeclarationAnswerReader
    {
        private readonly List<string> _puzzleInput =
            new PuzzleInputReader("CustomsDeclarations")
                .PuzzleInputAsString
                .Split("\n\r")
                .ToList();

        public void GetAllYesAnswersForStarOne()
        {
            var allYesAnswers =
                _puzzleInput
                    .Select(answer =>
                        answer
                            .Replace("\r", string.Empty)
                            .Replace("\n", string.Empty)
                            .Distinct()
                            .Count())
                    .Sum();

            Console.WriteLine($"There are {allYesAnswers} yes answers");
        }

        public void GetAllYesAnswersForStarTwo()
        {
            var allGroups =
                _puzzleInput
                    .Select(answer => 
                        answer
                            .Replace("\r", string.Empty)
                            .Split("\n")
                            .Where(item => item != string.Empty)
                            .ToList())
                    .ToList();

            var amountOfActualYesAnswers = allGroups.Select(group =>
            {
                var amountOfMatchingAnswers = 0;
                foreach (var answer in group[0])
                {
                    if (group.All(line => line.Contains(answer)))
                    {
                        amountOfMatchingAnswers++;
                    };
                }

                return amountOfMatchingAnswers;
            }).Sum();

            Console.WriteLine($"Actual amount of Yes answers is {amountOfActualYesAnswers}");
        }
    }
}
