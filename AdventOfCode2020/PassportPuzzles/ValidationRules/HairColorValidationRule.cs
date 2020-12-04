using System.Text.RegularExpressions;

namespace AdventOfCode2020.PassportPuzzles.ValidationRules
{
    public class HairColorValidationRule: IValidationRule
    {
        public bool IsValid(string passport)
        {
            var regex = new Regex(".?hcl:#[0-9|a-f]{6}\\b");
            return regex.IsMatch(passport);
        }
    }
}
