using System;
using System.Collections.Generic;

namespace CodilityTests
{
    public class Lesson07_02
    {
        /// <summary>
        /// EASY
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 07.4");

            AsserAlgorithm(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 }, 2);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int[] B, int expectedResult)
        {
            var result = solution2(A, B);

            if (result != expectedResult)
                //if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 27 minutes
        /// 25% (25% correctness + 25% performance)
        /// </summary>
        public static int solution(int[] A, int[] B)
        {
            var sizes = new List<int>(A);
            var directions = new List<int>(B);

            var i = 1;

            while (i < directions.Count)
            {
                var currentDirection = directions[i - 1];
                var nextDirection = directions[i];

                if (currentDirection == nextDirection)
                {
                    i++;
                    continue;
                }

                if (sizes[i] > sizes[i + 1])
                {
                    sizes.RemoveAt(i + 1);
                    directions.RemoveAt(i + 1);
                }
                else
                {
                    sizes.RemoveAt(i);
                    directions.RemoveAt(i);
                }
            }


            return directions.Count;
        }

        public static int solution2(int[] A, int[] B)
        {
            var sizes = new List<int>(A);
            var directions = new List<int>(B);

            var i = 1;

            while (i < directions.Count)
            {
                var currentDirection = directions[i - 1];
                var nextDirection = directions[i];

                if (currentDirection == nextDirection)
                {
                    i++;
                    continue;
                }

                if (sizes[i] > sizes[i - 1])
                {
                    sizes.RemoveAt(i - 1);
                    directions.RemoveAt(i - 1);
                }
                else
                {
                    sizes.RemoveAt(i);
                    directions.RemoveAt(i);
                }
            }


            return directions.Count;
        }

    }
}
