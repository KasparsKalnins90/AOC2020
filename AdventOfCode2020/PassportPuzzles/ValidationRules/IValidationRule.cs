namespace AdventOfCode2020.PassportPuzzles.ValidationRules
{
    public interface IValidationRule
    {
        public bool IsValid(string passport);
    }
}
