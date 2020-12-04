using System.Text.RegularExpressions;

namespace AdventOfCode2020.PassportPuzzles.ValidationRules
{
    public class IssueYearValidationRule: IValidationRule
    {
        public bool IsValid(string passport)
        {
            var regex= new Regex(".?iyr:([0-9]{4})\\b");
            if (!regex.IsMatch(passport))
            {
                return false;
            }
            var year = int.Parse(regex.Match(passport).Groups[1].Value);

            return year >= 2010 && year <= 2020;
        }
    }
}
