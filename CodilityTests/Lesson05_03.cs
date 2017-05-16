using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTests
{
    public class Lesson05_03
    {
        /// <summary>
        /// MEDIUM
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 05.3");

            AsserAlgorithm("CAGCCTA", new[] { 2, 5, 0 }, new[] { 4, 5, 6 }, new[] { 2, 4, 1 });
            AsserAlgorithm("A", new[] { 0 }, new[] { 0 }, new[] { 1 });
            AsserAlgorithm("T", new[] { 0 }, new[] { 0 }, new[] { 4 });
            AsserAlgorithm("AAAAA", new[] { 0, 1, 0 }, new[] { 0, 1, 4 }, new[] { 1, 1, 1 });
            AsserAlgorithm("CCCCC", new[] { 0, 1, 0 }, new[] { 0, 1, 4 }, new[] { 2, 2, 2 });
            AsserAlgorithm("GGGGG", new[] { 0, 1, 0 }, new[] { 0, 1, 4 }, new[] { 3, 3, 3 });
            AsserAlgorithm("TTTTT", new[] { 0, 1, 0 }, new[] { 0, 1, 4 }, new[] { 4, 4, 4 });

            AsserAlgorithm("ACGT", new[] { 0, 1, 2, 3 }, new[] { 0, 1, 2, 3 }, new[] { 1, 2, 3, 4 });
            AsserAlgorithm("ACGT", new[] { 0, 1, 2, 3 }, new[] { 0, 1, 2, 3 }, new[] { 1, 2, 3, 4 });


            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(string S, int[] P, int[] Q, int[] expectedResult)
        {
            var result = solution3(S, P, Q);

            //if (result != expectedResult)
            if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 28 min
        /// 62% (100% correctness + 0% performance)
        /// </summary>
        public static int[] solution(string S, int[] P, int[] Q)
        {
            var output = new int[P.Length];

            for (int i = 0; i < P.Length; i++)
            {
                var p = P[i];
                var q = Q[i];

                var subStr = S.Substring(p, q - p + 1);

                output[i] = GetNucleotidesValue(subStr);
            }

            return output;
        }

        /// <summary>
        /// 7 minutes
        /// 62% (100% correctness + 0% performance - O(N * M))
        /// </summary>
        public static int[] solution2(string S, int[] P, int[] Q)
        {
            var output = new int[P.Length];

            var arrayAsInt = new List<int>();

            foreach (char c in S)
                arrayAsInt.Add(GetNucleotidesValue(c));

            for (int i = 0; i < P.Length; i++)
            {
                var p = P[i];
                var q = Q[i];

                output[i] = arrayAsInt.GetRange(p, q-p+1).Min();
            }

            return output;
        }


        /// <summary>
        /// 4 minutes (much more than that :D)
        /// 87% (100% correctness + 66% performance - O(N + M))
        /// </summary>
        public static int[] solution3(string S, int[] P, int[] Q)
        {
            var output = new int[P.Length];
            var cacheList = new List<Cache>();

            for (int i = 0; i < P.Length; i++)
            {
                var p = P[i];
                var q = Q[i];

                if (cacheList.Any(x => x.p >= p  && q <= x.q))
                {
                    output[i] = cacheList.Where(x => x.p >= p && q <= x.q).Min(x => x.minValue);
                    continue;
                }
                

                var subStr = S.Substring(p, q - p + 1);

                var value = GetNucleotidesValue(subStr);
                output[i] = value;
                cacheList.Add(new Cache() { minValue = value, p = p, q = q});
            }

            return output;
        }

        private static int GetNucleotidesValue(string s)
        {
            if (s.Contains('A'))
                return 1;

            if (s.Contains('C'))
                return 2;

            if (s.Contains('G'))
                return 3;

            return 4;//'T'
        }

        private static int GetNucleotidesValue(char c)
        {
            if (c =='A')
                return 1;

            if (c == 'C')
                return 2;

            if (c == 'G')
                return 3;

            return 4;//'T'
        }
    }

    public class Cache
    {
        public int p { get; set; }
        public int q { get; set; }
        public int minValue { get; set; }
    }
}
