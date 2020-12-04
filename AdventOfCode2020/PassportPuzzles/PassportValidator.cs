using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;

namespace AdventOfCode2020.PassportPuzzles
{
    public static class PassportValidator
    {
        private static readonly string PassportInfoPath =
            $"{Directory.GetCurrentDirectory()}\\PuzzleInputs\\PassportInfo.txt";


        private static readonly List<string> Passports =
            File.ReadAllText(PassportInfoPath).Split("\r\n\r\n").ToList();

        public static int GetValidPassportCount()
        {
            var validPassports = 
                Passports
                    .Count(password => password.IsValidPassport());
            
            Console.WriteLine($"there are {validPassports} valid passports");
            return validPassports;
        }

        private static bool IsValidPassport(this string password)
        {
            return password.Contains("byr")
                   && password.Contains("iyr")
                   && password.Contains("eyr")
                   && password.Contains("hgt")
                   && password.Contains("hcl")
                   && password.Contains("ecl")
                   && password.Contains("pid");
        }
    }
}
