using System;
using System.IO;
using AdventOfCode2020.PasswordPuzzles;

namespace AdventOfCode2020
{
    public  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"There are {PasswordValidator.GetValidPasswordCount()} valid passwords");
        }
    }
}
