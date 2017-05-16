using System;
using System.Linq;

namespace CodilityTests
{
    public class Lesson06_01
    {
        /// <summary>
        /// EASY
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 06.1");

            AsserAlgorithm(new int[] { 2, 1, 1, 2, 3, 1 }, 3);


            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int expectedResult)
        {
            var result = solution(A);

            if (result != expectedResult)
                //if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 100% (100% + 100%)
        /// </summary>
        public static int solution(int[] A)
        {
            return A.Distinct().Count();
        }
    }
}
