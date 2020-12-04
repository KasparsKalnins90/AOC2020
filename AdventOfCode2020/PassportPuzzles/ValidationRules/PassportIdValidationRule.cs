using System.Text.RegularExpressions;

namespace AdventOfCode2020.PassportPuzzles.ValidationRules
{
    public class PassportIdValidationRule : IValidationRule
    {
        public bool IsValid(string passport)
        {
            var regex = new Regex(".?pid:[0-9]{9}\\b");
            return regex.IsMatch(passport);
        }
    }
}
