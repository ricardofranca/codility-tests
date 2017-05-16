using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTests
{
    public class Lessson05_02
    {
        public static void Execute()
        {
            Console.WriteLine("Starting lesson 05.02");

            Assert(new int[] { 0, 1, 0, 1, 1 }, 5);
            Assert(new int[] { 1 }, 0);
            Assert(new int[] { 0 }, 0);
            Assert(new int[] { 1, 0 }, 0);
            Assert(new int[] { 0, 1 }, 1);

        }

        private static void Assert(int[] A, int expectedResult)
        {
            var result = solution02(A);

            if (result != expectedResult)
                //if (string.Join("", result) != string.Join("", expectedResult))
                throw new Exception($"Should return {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 60% (100% + 20%) - time complexity: O(N**2)
        /// </summary>
        public static int solution(int[] A)
        {
            var maxAvailable = 1000000000;
            var count = 0;

            for (int p = 0; p < A.Length; p++)
            {
                if (A[p] == 1)
                    continue;

                for (int q = p+1; q < A.Length; q++)
                {
                    if (A[q] == 0)
                        continue;

                    count++;

                    if (count > maxAvailable)
                        return -1;
                }
            }

            return count;
        }

        /// <summary>
        /// 100% (100% + 100%)
        /// </summary>
        public static int solution02(int[] A)
        {
            var maxAvailable = 1000000000;
            var count = 0;

            var countEast = 0; //when the direction is 0

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                    countEast++;
                else
                {
                    if (count == 0)
                        count = countEast;
                    else
                        count += countEast;
                }

                if (count > maxAvailable)
                    return -1;
            }

            return count;
        }
    }
}
