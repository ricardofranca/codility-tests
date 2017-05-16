using System;
using System.Linq;

namespace CodilityTests
{
    /// <summary>
    /// EASY
    /// </summary>
    public class Lesson04
    {
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 04.1");

            AsserAlgorithm(new int[] { 4,1,3,2 }, 1);
            AsserAlgorithm(new int[] { 4,1,3 }, 0);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int expectedResult)
        {
            var result = solution(A);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 8 minutes
        /// 100%
        /// </summary>
        public static int solution(int[] A)
        {
            var anyItemWithMoreThanOnce = A.ToList().GroupBy(x => x).Any(x => x.Count() > 1);

            if (anyItemWithMoreThanOnce)
                return 0;

            var max = A.Max(x => x);

            if (A.Length < max)
                return 0;

            return 1;
        }


    }
}
