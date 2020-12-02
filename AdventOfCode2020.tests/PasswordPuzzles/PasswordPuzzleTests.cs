using AdventOfCode2020.PasswordPuzzles;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2020.tests.PasswordPuzzles
{
    public class PasswordPuzzleTests
    {
        [TestCaseSource(typeof(PasswordInfoTestCaseData))]

        public void ShouldCreatePuzzleInfoProperly(
                (string puzzleInput,
                int ExpectedRangeFrom,
                int ExpectedRangeTo,
                char ExpectedRepeatingLetter,
                string ExpectedStoredPassword) testCaseTuple)
        {
            var puzzleInfo = new PasswordInfo(testCaseTuple.puzzleInput);

            puzzleInfo
                .RepeatingLetter
                .Should()
                .Be(testCaseTuple.ExpectedRepeatingLetter);
            puzzleInfo
                .StoredPassword
                .Should()
                .Be(testCaseTuple.ExpectedStoredPassword);
            puzzleInfo
                .RangeFrom
                .Should()
                .Be(testCaseTuple.ExpectedRangeFrom);
            puzzleInfo
                .RangeTo
                .Should()
                .Be(testCaseTuple.ExpectedRangeTo);
        }

        [TestCase("1-3 a: abcde", ExpectedResult = true)]
        [TestCase("1-3 b: cdefg", ExpectedResult = false)]
        [TestCase("2-9 c: ccccccccc", ExpectedResult = true)]

        public bool IsPasswordValid_ShouldReturnTrueIfPasswordValid(string puzzleInputLine)
        {
            return PasswordValidator.IsPasswordValid(puzzleInputLine);
        }

        [TestCase("1-3 a: abcde", ExpectedResult = true)]
        [TestCase("1-3 b: cdefg", ExpectedResult = false)]
        [TestCase("2-9 c: ccccccccc", ExpectedResult = false)]
        public bool IsPasswordReallyValid_ShouldReturnTrueIfPasswordReallyValid(string puzzleInputLine)
        {
            return PasswordValidator.IsPasswordReallyValid(puzzleInputLine);
        }
    }

}
