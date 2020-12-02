using System.Collections;
using NUnit.Framework;

namespace AdventOfCode2020.tests.PasswordPuzzles
{
    public class PasswordInfoTestCaseData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData
            (
                 ("1-3 a: abcde", 1, 3, 'a', "abcde")
            );
            yield return new TestCaseData
            (
                ("1-3 b: cdefg", 1, 3, 'b', "cdefg")
            );
            yield return new TestCaseData
            (
                ("2-9 c: ccccccccc", 2, 9, 'c', "ccccccccc")
            );
        }
    }
}
