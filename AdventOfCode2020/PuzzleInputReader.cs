using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class PuzzleInputReader
    {
        public string PuzzleInputFilePath { get;  }
        public IEnumerable<string> PuzzleInputAsEnumerable => File.ReadAllLines(PuzzleInputFilePath);
        public string PuzzleInputAsString => File.ReadAllText(PuzzleInputFilePath);

        public PuzzleInputReader(string filename)
        {
            PuzzleInputFilePath = $"{Directory.GetCurrentDirectory()}\\PuzzleInputs\\{filename}.txt";
        }
    }
}
