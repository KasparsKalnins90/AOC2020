using System.Text.RegularExpressions;

namespace AdventOfCode2020.PassportPuzzles.ValidationRules
{
    public class BirthYearValidationRule : IValidationRule
    {
        public bool IsValid(string passport)
        {
            var regex = new Regex(".?byr:([0-9]{4})\\b");
            if (!regex.IsMatch(passport))
            {
                return false;
            }
            var year = int.Parse(regex.Match(passport).Groups[1].Value);

            return year >= 1920 && year <= 2002;
        }
    }
}
