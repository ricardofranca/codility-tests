using System;
using System.Linq;

namespace CodilityTests
{
    public static class Lesson04_04
    {
        /// <summary>
        /// MEDIUM
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 04.4");

            AsserAlgorithm(new int[] { 3, 4, 4, 6, 1, 4, 4 }, 5, new int[] { 3, 2, 2, 4, 2 });

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int N, int[] expectedResult)
        {
            var result = solution(N, A);

            //if (result != expectedResult)
            if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 47 minutes
        /// 66% (100% correctness + 40% performance)
        /// </summary>
        public static int[] solution(int N, int[] A)
        {
            var array = new int[N];

            //SetArrayTo(0, array);
            
            for (int i = 0; i < A.Length; i++)
            {
                var x = A[i];

                if (x <= N)
                {
                    //increase counter
                    array[x - 1] += 1;
                }
                else if (x == N + 1)
                {
                    //max counters
                    var max = array.Max();
                    SetArrayTo(max, array);
                }

                //Console.WriteLine(string.Join(",", array));
            }

            return array;
        }

        /// <summary>
        /// 3 minutes
        /// 66% (100% + 40%)
        /// </summary>
        public static int[] solution2(int N, int[] A)
        {
            var array = new int[N];

            for (int i = 0; i < A.Length; i++)
            {
                var x = A[i];

                if (x < 1)
                    continue;
                if (x <= N)
                {
                    //increase counter
                    array[x - 1] += 1;
                }
                else if (x == N + 1)
                {
                    //max counters
                    var max = array.Max();
                    SetArrayTo(max, array);
                }

                //Console.WriteLine(string.Join(",", array));
            }

            return array;
        }

        private static void SetArrayTo(int value, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = value;
        }
    }
}
