using System;
using System.Linq;

namespace CodilityTests
{
    /// <summary>
    /// EASY
    /// </summary>
    public class Lesson03_03
    {
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 03.3");

            AsserAlgorithm(new int[] { 3, 1, 2, 4, 3 }, 1);

            AsserAlgorithm(new int[] { 1, 2, 1 }, 2);

            AsserAlgorithm(new int[] { 5, 4, 3, 2, 1, 2, 3, 4, 5 }, 1);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int expectedResult)
        {
            var result = solution2(A);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 19 minutes
        /// 50% (100% correctness + 0% performance)
        /// </summary>
        public static int solution(int[] A)
        {
            var minValue = int.MaxValue;

            for (int i = 1; i < A.Length; i++)
            {
                var leftPart = A.ToList().GetRange(0, i).Sum(x => x);
                var rigthPart = A.ToList().GetRange(i, A.Length - i).Sum(x => x);


                var difference = leftPart > rigthPart
                    ? leftPart - rigthPart
                    : rigthPart - leftPart;

                if (difference < minValue)
                    minValue = difference;

            }

            return minValue;
        }

        /// <summary>
        /// incomplete
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int solution2(int[] A)
        {
            var middleOfArray = A.Length / 2;

            var leftPart = A.ToList().GetRange(0, middleOfArray).Sum(x => x);
            var rigthPart = A.ToList().GetRange(middleOfArray, A.Length - middleOfArray).Sum(x => x);
            var mainDifference = GetDifference(leftPart, rigthPart);
            var minValue = mainDifference;

            var leftVariable = 0;
            var rightVariable = 0;

            for (var i = 1; i < middleOfArray; i++)
            {
                leftVariable += A[middleOfArray - 1];
                rightVariable += A[middleOfArray + 1];

                var currentDifference = GetDifference(leftVariable, rightVariable);

                var difference = GetDifference(mainDifference, currentDifference);
                if (difference < minValue)
                    minValue = difference;

            }

            return minValue;
        }

        public static int GetDifference(int a, int b)
        {
            return a > b
                ? a - b
                : b - a;
        }
    }
}
