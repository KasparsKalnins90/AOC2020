using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.PasswordPuzzles
{
    public static class PasswordValidator
    {
        private static readonly string PasswordInfoPath =
            $"{Directory.GetCurrentDirectory()}\\PuzzleInputs\\PasswordPuzzleInput.txt";


        private static readonly IEnumerable<string> PuzzleInput =
            File.ReadAllLines(PasswordInfoPath);

        private static readonly IEnumerable<PasswordInfo> PasswordInfoCollection =
            PuzzleInput.Select(line => new PasswordInfo(line));
        
        public static int GetValidPasswordCount()
        {
            return PasswordInfoCollection.Count(IsPasswordValid);
        }
        public static int GetActualValidPasswordCount()
        {
            return PasswordInfoCollection.Count(IsPasswordReallyValid);
        }
        public static bool IsPasswordValid(PasswordInfo passwordInfo)
        {
            var letterCount =
                passwordInfo
                    .StoredPassword
                    .Count(letter => letter == passwordInfo.RepeatingLetter);

            return letterCount <= passwordInfo.RangeTo && letterCount >= passwordInfo.RangeFrom;
        }

        public static bool IsPasswordReallyValid(PasswordInfo passwordInfo)
        {
            var isNeededLetterAtFirstPosition =
                passwordInfo.StoredPassword[passwordInfo.RangeFrom - 1] == passwordInfo.RepeatingLetter;
            var isNeededLetterAtSecondPosition =
                passwordInfo.StoredPassword[passwordInfo.RangeTo - 1] == passwordInfo.RepeatingLetter;

            return (isNeededLetterAtFirstPosition && !isNeededLetterAtSecondPosition)
                   || (isNeededLetterAtSecondPosition && !isNeededLetterAtFirstPosition);
        }
    }
}
