using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTests
{
    public class Lesson06_03
    {
        /// <summary>
        /// EASY
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 06.3");

            AsserAlgorithm(new int[] { -3, 1, 2, -2, 5, 6 }, 60);
            AsserAlgorithm(new int[] { 1, }, 1);
            AsserAlgorithm(new int[] { -5, 5, -5 }, 125);


            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int expectedResult)
        {
            var result = solution3(A);

            if (result != expectedResult)
                //if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 9 minutes
        /// 44% (100% + 0% - O(N**3))
        /// </summary>
        public static int solution(int[] A)
        {
            var maximal = Int32.MinValue;

            if (A.Length == 0)
                return 0;

            if (A.Length == 1)
                return A[0];

            if (A.Length == 2)
                return A[1] * A[2];

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i + 1; j < A.Length; j++)
                {
                    for (int k = j + 1; k < A.Length; k++)
                    {
                        var currentTriplet = A[i] * A[j] * A[k];
                        if (currentTriplet > maximal)
                            maximal = currentTriplet;

                    }
                }
            }

            return maximal;
        }

        /// <summary>
        /// 3 minutes
        /// 44% (50% + 40%)
        /// OBS: could be two negatives numbers be a positive one
        /// </summary>
        public static int solution2(int[] A)
        {
            if (A.Length == 0)
                return 0;

            if (A.Length == 1)
                return A[0];

            if (A.Length == 2)
                return A[1] * A[2];

            var sortedList = A.OrderByDescending(x => x).Take(3).ToList();
            var amount = 1;

            foreach (var item in sortedList)
            {
                amount *= item;
            }

            return amount;
        }

        /// <summary>
        /// 77% (100% + 60%)
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int solution3(int[] A)
        {
            if (A.Length == 0)
                return 0;

            if (A.Length == 1)
                return A[0];

            if (A.Length == 2)
                return A[1] * A[2];

            var sortedList = A.OrderByDescending(x => x).ToList();
            
            var firstThree = sortedList.Take(3).ToList();
            var lastTwo = sortedList.Where(x => x < 0).OrderByDescending(x => x).Take(2).ToList();

            //with multiply by 1 the number is going to be negative!
            if (lastTwo.Count() == 1)
                return CalculateProduct(firstThree);

            var combination23 = CalculateProduct(firstThree.Skip(1).Take(2));

            var lastTwoAmount = CalculateProduct(lastTwo);

            if (lastTwoAmount > combination23)
                return lastTwoAmount * firstThree[0];

            return CalculateProduct(firstThree);
        }

        private static int CalculateProduct(IEnumerable<int> firstThree)
        {
            var amount = 1;

            foreach (var item in firstThree)
            {
                amount *= item;
            }
            return amount;
        }
    }
}
