using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class PuzzleInputReader
    {
        public string PuzzleInputFilePath { get;  }
        public IEnumerable<string> PuzzleInfo { get; }

        public PuzzleInputReader(string filename)
        {
            PuzzleInputFilePath = $"{Directory.GetCurrentDirectory()}\\PuzzleInputs\\{filename}.txt";
            PuzzleInfo = File.ReadAllLines(PuzzleInputFilePath);
        }
    }
}
