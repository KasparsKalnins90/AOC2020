using System.Text.RegularExpressions;

namespace AdventOfCode2020.PassportPuzzles.ValidationRules
{
    public class HeightValidationRule : IValidationRule
    {
        public bool IsValid(string passport)
        {
            var regex = new Regex(".?hgt:([0-9]{2,3})(\\D{2})\\b");
            if (!regex.IsMatch(passport))
            {
                return false;
            }

            var regexMatchGroups = regex.Match(passport).Groups;

            var height = int.Parse(regexMatchGroups[1].Value);

            var measuringUnits = regexMatchGroups[2].Value;

            return measuringUnits switch
            {
                "cm" => height >= 150 && height <= 193,
                "in" => height >= 59 && height <= 76,
                _ => false
            };
        }
    }
}
