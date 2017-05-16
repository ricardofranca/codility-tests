using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTests
{
    /// <summary>
    /// EASY
    /// </summary>
    public static class Lesson03
    {
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 03.1");

            AsserAlgorithm(new int[] { 2, 3, 1, 5 }, 4);
            AsserAlgorithm(new int[] { 2, 3, 1, 5, 6 }, 4);
            AsserAlgorithm(new int[] { 6, 1, 2, 4, 3 }, 5);

            AsserAlgorithm(new int[] { 6, 5, 2, 4, 3 }, 1);
            AsserAlgorithm(new int[] { 4, 5, 2, 1, 3 }, 6);



            AsserAlgorithm(new int[] { 2 }, 1);

            AsserAlgorithm(new int[] { }, 1);

            AsserAlgorithm(new int[] { 1, 2 }, 3);


            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] numbers, int expectedResult)
        {
            var result = solution3(numbers);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 21 minutes
        /// 20%
        /// </summary>
        public static int solution(int[] A)
        {
            for (int i = 1; i < A.Length + 1; i++)
            {
                if (!A.Contains(i))
                    return i;
            }

            return 0;
        }

        /// <summary>
        /// 6 minutes
        /// 60% (100% correctness + 20% performance)
        /// </summary>
        public static int solution2(int[] A)
        {
            var checkUntil = A.Length + 1; //the for starts with 1 and the array is N +1
            for (int i = 1; i <= checkUntil; i++)
            {
                if (!A.Contains(i))
                    return i;
            }

            return 0;
        }


        /// <summary>
        /// 21 min
        /// 100% (100% correctness + 100% performance)
        /// </summary>
        public static int solution3(int[] A)
        {
            if (A.Length == 0) return 1;

            var sortedList = A.OrderBy(x => x).ToList();

            return GetMissingNumber(sortedList, 1);
        }

        private static int GetMissingNumber(List<int> sortedList, int startIndex)
        {
            var middleNumber = sortedList.Count / 2;

            if (sortedList.Count == 1)
            {
                if (sortedList[0] == 2 && startIndex == 1) return 1;

                return sortedList[0] + 1;
            }
            if (sortedList[middleNumber] != startIndex + middleNumber)
            {
                //leftPart
                return GetMissingNumber(sortedList.GetRange(0, middleNumber), startIndex);
            }

            //right part of the array
            return GetMissingNumber(sortedList.GetRange(middleNumber, sortedList.Count - middleNumber), startIndex + middleNumber);
        }
    }
}
