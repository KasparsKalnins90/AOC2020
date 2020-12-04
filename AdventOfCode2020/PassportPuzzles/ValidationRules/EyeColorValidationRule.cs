using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.PassportPuzzles.ValidationRules
{
    public class EyeColorValidationRule :IValidationRule
    {
        public bool IsValid(string passport)
        {
            var regex = new Regex(".?ecl:([a-z]{3})\\b");
            var validEyeColors = new List<string>
            {
                "amb",
                "blu",
                "brn",
                "gry",
                "grn",
                "hzl",
                "oth"
            };
            return 
                validEyeColors
                    .Any(color => color == regex.Match(passport).Groups[1].Value);
        }
    }
}
