using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTests
{
    public static class Lesson04_03
    {
        /// <summary>
        /// EASY
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 04.3");

            AsserAlgorithm(new int[] { 1, 3, 6, 4, 1, 2 }, 5);
            AsserAlgorithm(new int[] { 2 }, 1);
            AsserAlgorithm(new int[] { 2, 3 }, 1);
            AsserAlgorithm(new int[] { 1, 3, 4 }, 2);
            AsserAlgorithm(new int[] { 1 }, 2);



            AsserAlgorithm(MountArray(-100, -1), 1);


            Console.WriteLine("Everything OK");
        }

        public static int[] MountArray(int from, int to)
        {
            var list = new List<int>();
            for (int i = from; i <= to; i++)
                list.Add(i);

            return list.ToArray();
        }

        public static void AsserAlgorithm(int[] A, int expectedResult)
        {
            var result = solution3(A);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 6 minutes
        /// 33% (40 correctness + 25% performance)
        /// </summary>
        public static int solution(int[] A)
        {
            var list = A.Distinct().ToList();
            var max = list.Max();

            var allTheNumbers = new List<int>();
            for (var i = 1; i < max; i++)
                allTheNumbers.Add(i);

            var missingNumbers = allTheNumbers.Except(list);

            return missingNumbers.First();
        }

        /// <summary>
        /// 4 minutes
        /// 33% (60% correctness + 0% performance)
        /// </summary>
        public static int solution2(int[] A)
        {
            var max = A.Max();

            for (var i = 1; i < max; i++)
            {
                if (!A.Contains(i))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// 9 minutes
        /// 66% (100% correctness + 25% performance)
        /// </summary>
        public static int solution3(int[] A)
        {
            for (var i = 1; i < int.MaxValue; i++)
            {
                if (!A.Contains(i))
                    return i;
            }

            throw new Exception("impossible");
        }

        /// <summary>
        /// 100 %
        /// </summary>
        public static int solution4(int[] A)
        {
            var sortedList = new SortedList(A.Distinct().ToDictionary(x => x));

            for (var i = 1; i < int.MaxValue; i++)
            {
                if (!sortedList.Contains(i))
                    return i;
            }

            throw new Exception("impossible");
        }
    }
}
