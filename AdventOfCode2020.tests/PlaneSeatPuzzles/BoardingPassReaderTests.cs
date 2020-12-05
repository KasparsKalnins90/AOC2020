using AdventOfCode2020.PlaneSeatPuzzles;
using NUnit.Framework;

namespace AdventOfCode2020.tests.PlaneSeatPuzzles
{
    public class BoardingPassReaderTests
    {
        [TestCase("BFFFBBFRRR", ExpectedResult = 567)]
        public int GetSeatId_ShouldGetSeatId(string boardingPassInfo)
        {
            return BoardingPassReader.GetSeatId(boardingPassInfo);
        }
    }
}
