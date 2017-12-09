using NUnit.Framework;

namespace Codility.Tests
{
    [TestFixture]
    public class Lesson09
    {
        [Test]
        [TestCase(new[] { 23171, 21011, 21123, 21366, 21013, 21367 }, ExpectedResult = 356)]
        public int Item_09_01(int[] A)
        {
            if (A == null || A.Length < 2)
                return 0;

            var maxProfit = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[j] > A[i])
                    {
                        var currentProfit = A[j] - A[i];
                        if (currentProfit > maxProfit)
                            maxProfit = currentProfit;
                    }
                }
            }

            if (maxProfit > 0)
                return maxProfit;
            return 0;
        }

        [Test]
        [TestCase("", ExpectedResult = 0)]
        public int Item_09_02(string input)
        {
            Assert.Fail();
            return 0;
        }
    }
}
