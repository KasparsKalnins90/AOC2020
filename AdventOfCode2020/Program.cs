using System;
using AdventOfCode2020.PasswordPuzzles;

namespace AdventOfCode2020
{
    public  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"There are {PasswordValidator.GetActualValidPasswordCount()} valid passwords");
        }
    }
}
