using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.PassportPuzzles.ValidationRules;

namespace AdventOfCode2020.PassportPuzzles
{
    public static class PassportValidator
    {
        private static readonly string PassportInfoPath =
            $"{Directory.GetCurrentDirectory()}\\PuzzleInputs\\PassportInfo.txt";


        private static readonly List<string> Passports =
            File.ReadAllText(PassportInfoPath).Split("\r\n\r\n").ToList();

        private static List<IValidationRule> ValidationRules = new List<IValidationRule>
        {
            new BirthYearValidationRule(),
            new ExpirationYearValidationRule(),
            new EyeColorValidationRule(),
            new HairColorValidationRule(),
            new HeightValidationRule(),
            new IssueYearValidationRule(),
            new PassportIdValidationRule()
            
        };


        public static int GetValidPasswordCount()
        {
            var validPassportCount =
                Passports
                    .Count(password => password.IsValidPassport());
            Console.WriteLine($"there are {validPassportCount} valid passports");
            return validPassportCount;
        }


        public static bool IsValidPassport(this string password)
        {
            return ValidationRules.All(rule => rule.IsValid(password));
        }
        public static int GetValidPassportCountForStarOne()
        {
            var validPassports = 
                Passports
                    .Count(password => password.IsValidPassportForStarOne());
            
            Console.WriteLine($"there are {validPassports} valid passports");
            return validPassports;
        }



        private static bool IsValidPassportForStarOne(this string password)
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
