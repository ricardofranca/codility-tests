using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTests
{
    /// <summary>
    /// EASY
    /// </summary>
    public static class Lesson04_02
    {
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 04.2");

            AsserAlgorithm(new int[] { 1, 3, 1, 4, 2, 3, 5, 4 }, 5, 6);
            AsserAlgorithm(new int[] { 2, 2,2,2,2 }, 2, -1);
            AsserAlgorithm(new int[] { 1 }, 1, 0);
            AsserAlgorithm(new int[] { 1, 2, 3, 5, 3, 1 }, 5, -1);
            AsserAlgorithm(new int[] { 1, 3, 1, 3, 2, 1, 3 }, 3, 4);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int X, int expectedResult)
        {
            var result = solution4(X, A);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 12 minutes
        /// 18% (33% correctness + 0% performance not runned)
        /// </summary>
        public static int solution(int X, int[] A)
        {
            return A.ToList().IndexOf(X);
        }

        /// <summary>
        /// 0% (0% + 0%)
        /// </summary>
        public static int solution2(int X, int[] A)
        {
            var list = A.ToList();

            var allIndexes = list.Select((c, i) => new { number = c, index = i }).Where(x => x.number == X).Select(x => x.index).ToList();


            for (int i = 0; i < allIndexes.Count; i++)
            {
                var currentList = list.GetRange(0, allIndexes[i]);
                var missingAnyNumber = false;

                for (int j = 1; j < X-1; j++)
                {
                    var indexOfJ = currentList.IndexOf(j);
                    if (indexOfJ < 0)
                    {
                        missingAnyNumber = true;
                        break;
                    }
                }

                if (!missingAnyNumber && X-1 > 1)
                    return allIndexes[i];
            }

            return -1;
        }

        /// <summary>
        /// 18% (33% + 0%)
        /// </summary>
        public static int solution3(int X, int[] A)
        {
            if (A.Length == 1)
                return A[0] == 1 ? 0 : -1;

            var list = A.ToList();

            var allIndexes = list.Select((c, i) => new { number = c, index = i }).Where(x => x.number == X).Select(x => x.index).ToList();

            for (int i = 0; i < allIndexes.Count; i++)
            {
                var currentList = list.GetRange(0, allIndexes[i]);
                var missingAnyNumber = false;

                for (int j = 1; j < X; j++)
                {
                    var indexOfJ = currentList.IndexOf(j);
                    if (indexOfJ < 0)
                    {
                        missingAnyNumber = true;
                        break;
                    }
                }

                if (!missingAnyNumber && X - 1 > 1)
                    return allIndexes[i];
            }

            return -1;
        }

        /// <summary>
        /// 72% (100% correctness + 40% performance)
        /// </summary>
        public static int solution4(int X, int[] A)
        {
            if (A.Length == 1)
                return A[0] == 1 ? 0 : -1;

            var tuples = new Dictionary<int, bool>();

            for (int i = 1; i < X; i++)
                tuples.Add(i, false);

            var list = A.ToList();

            var firstIndex = list.IndexOf(X);

            if (firstIndex < 0)
                return -1;

            var listForFirstIndex = list.GetRange(0, firstIndex).Distinct().ToList();

            var updateList = tuples.Where(x => listForFirstIndex.Contains(x.Key)).ToList();

            foreach (var keyValuePair in updateList)
            {
                tuples[keyValuePair.Key] = true;
            }

            if (tuples.All(x => x.Value))
                return firstIndex;

            for (int i = firstIndex+1; i < A.Length; i++)
            {
                tuples[A[i]] = true;

                if (tuples.All(x => x.Value))
                    return i;
            }

            return -1;
        }


    }
}
