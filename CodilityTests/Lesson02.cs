using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTests
{
    internal static class Lesson02
    {
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 02");

            AsserAlgorithm(new int[] {9, 3, 9, 3, 9, 7, 9}, 7);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] array, int expectedResult)
        {
            var result = solution3(array);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }


        /// <summary>
        /// 77% (100% correct + 50% of performance)
        /// </summary>
        public static int solution(int[] A)
        {
            var arrayB = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                var indexOf = arrayB.IndexOf(A[i]);
                if (indexOf < 0)
                {
                    arrayB.Add(A[i]);
                }
                else
                {
                    arrayB.RemoveAt(indexOf);
                }
            }

            return arrayB[0];
        }

        /// <summary>
        /// 66% (100% correct + 25% of performance)
        /// </summary>
        public static int solution2(int[] A)
        {
            var arrayB = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (!arrayB.Contains(A[i]))
                    arrayB.Add(A[i]);
                else
                    arrayB.Remove(A[i]);
            }

            return arrayB[0];
        }

        /// <summary>
        /// 100%
        /// </summary>
        public static int solution3(int[] A)
        {
            return A.GroupBy(x => x).First(x => x.Count() % 2 != 0).Key;
        }
    }
}