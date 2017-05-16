using System;

namespace CodilityTests
{
    public class Lesson05_01
    {
        /// <summary>
        /// EASY
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 05.1");

            AsserAlgorithm(6, 11, 2, 3);
            AsserAlgorithm(6, 6, 2, 1);
            AsserAlgorithm(2, 10, 0, 0);
            AsserAlgorithm(0, 10, 2, 5);

            AsserAlgorithm(0, 0, 11, 0);
            AsserAlgorithm(0, 1, 11, 0);
            AsserAlgorithm(1, 0, 11, 0);
            AsserAlgorithm(1, 1, 11, 0);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int A, int B, int K, int expectedResult)
        {
            var result = solution2(A, B, K);

            if (result != expectedResult)
            //if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 25% (50% correctness + 0% performance)
        /// </summary>
        public static int solution(int A, int B, int K)
        {
            if (K == 0) return 0;
            if (A == 0) A = 1;
            if (B == 0) B = 1;

            var count = 0;
            for (; A <= B; A++)
            {
                if (A % K == 0)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// answer on the comments
        /// 100%
        /// </summary>
        public static int solution2(int A, int B, int K)
        {
            if (K == 0) return 0;
            if (A == 0) A = 1;
            if (B == 0) B = 1;

            return (B / K) - (A / K) + (A % K == 0 ? 1 : 0);
        }

    }
}
