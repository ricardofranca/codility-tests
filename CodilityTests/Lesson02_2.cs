using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTests
{
    public static class Lesson02_2
    {
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 02.2");

            AsserAlgorithm(new int[] {  }, 3, new int[] { 9, 7, 6, 3, 8 });
            

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] numbers, int rotateNumber, int[] expectedResult)
        {
            var result = solution(numbers, rotateNumber);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 87% (87 %correctness + index out of range)
        /// </summary>
        public static int[] solution(int[] A, int K)
        {
            var result = new List<int>(A);

            for (int i = 0; i < K; i++)
            {
                result.Insert(0, result.Last());
                result.RemoveAt(result.Count -1);
            }

            return result.ToArray();
        }

        /// <summary>
        /// 100% (100% Correctness + there's no performance test)
        /// </summary>
        public static int[] solution2(int[] A, int K)
        {
            if (A.Length <= 1)
                return A;

            var result = new List<int>(A);

            for (int i = 0; i < K; i++)
            {
                result.Insert(0, result.Last());
                result.RemoveAt(result.Count - 1);
            }

            return result.ToArray();
        }
    }
}
