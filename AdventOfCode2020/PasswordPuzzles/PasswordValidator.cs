using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.PasswordPuzzles
{
    public static class PasswordValidator
    {
        private static readonly string PasswordInfoPath =
            $"{Directory.GetCurrentDirectory()}\\PuzzleInputs\\PasswordPuzzleInput.txt";


        private static readonly List<string> PuzzleInput =
            File.ReadAllLines(PasswordInfoPath)
                .ToList();
        public static int GetValidPasswordCount()
        {
            var validPasswordCount = 0;
            foreach (var puzzleLine in PuzzleInput)
            {
                if (IsPasswordValid(puzzleLine))
                {
                    validPasswordCount++;
                }
            }

            return validPasswordCount;
        }
        public static int GetActualValidPasswordCount()
        {
            var validPasswordCount = 0;
            foreach (var puzzleLine in PuzzleInput)
            {
                if (IsPasswordReallyValid(puzzleLine))
                {
                    validPasswordCount++;
                }
            }

            return validPasswordCount;
        }
        public static bool IsPasswordValid(string passwordInfoLine)
        {

            var passwordInfo = new PasswordInfo(passwordInfoLine);
            var letterCount = 0;
            foreach (var letter in passwordInfo.StoredPassword)
            {
                if (letter == passwordInfo.RepeatingLetter)
                {
                    letterCount++;
                }
            }
            var result = letterCount <= passwordInfo.RangeTo && letterCount >= passwordInfo.RangeFrom;
            return result;
        }

        public static bool IsPasswordReallyValid(string passwordInfoLine)
        {
            var passwordInfo = new PasswordInfo(passwordInfoLine);
            var isNeededLetterAtFirstPosition =  
                passwordInfo.StoredPassword[passwordInfo.RangeFrom-1] == passwordInfo.RepeatingLetter;
            var isNeededLetterAtSecondPosition =
                passwordInfo.StoredPassword[passwordInfo.RangeTo-1] == passwordInfo.RepeatingLetter;

            return (isNeededLetterAtFirstPosition && !isNeededLetterAtSecondPosition)
                   || (isNeededLetterAtSecondPosition && !isNeededLetterAtFirstPosition);
        }
    }
}
