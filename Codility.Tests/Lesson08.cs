using System;
using System.Linq;
using NUnit.Framework;

namespace Codility.Tests
{
    [TestFixture]
    public class Lesson08
    {
        [Test]
        [TestCase(new[] { 3, 4, 3, 2, 3, -1, 3, 3 }, ExpectedResult = 0)]
        [TestCase(new[] { 1, 2 }, ExpectedResult = -1)]
        [TestCase(new[] { 1, 1, 2 }, ExpectedResult = 0)]
        [TestCase(new[] { 2, 1, 1 }, ExpectedResult = 1)]
        public int Item_08_01(int[] A)
        {
            if (A == null || A.Length == 0)
                return -1;

            var grouped = A.GroupBy(x => x).OrderByDescending(x => x.Count());

            var maxQuantity = grouped.First().Count();
            var half = A.Length / 2;

            var haveDominator = (maxQuantity > half);

            if (!haveDominator)
                return -1;

            var domitator = grouped.First().Key;

            var firstIndex = Array.IndexOf(A, domitator);

            return firstIndex;
        }
    }
}
