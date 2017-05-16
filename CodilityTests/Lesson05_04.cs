using System;

namespace CodilityTests
{
    public class Lesson05_04
    {
        /// <summary>
        /// MEDIUM
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 05.3");

            AsserAlgorithm(new int[] { 4, 2, 2, 5, 1, 5, 8 }, 1);
            AsserAlgorithm(new int[] { 1 }, 0);
            AsserAlgorithm(new int[] { 1, 1 }, 0);
            AsserAlgorithm(new int[] { 1, 1, 1 }, 0);


            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int expectedResult)
        {
            var result = solution(A);

            if (result != expectedResult)
                //if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        #region MyRegion
        //public static int solution(int[] A)
        //{
        //    int amount = A[0];
        //    double bestAverage = double.MaxValue;
        //    int bestAverageIndex = 0;

        //    for (int i = 1; i < A.Length; i++)
        //    {
        //        amount += A[i];

        //        var currentAverage = amount / (i+1);
        //        if (currentAverage < bestAverage)
        //            bestAverageIndex = i;

        //        var newamount = A[i];

        //        for (int j = i+1; j < A.Length; j++)
        //        {

        //        }
        //    }

        //    return bestAverageIndex;
        //}


        //public static int temp(int[] A)
        //{
        //    for (int i = 0; i < A.Length; i++)
        //    {
        //        for (int j = 0; j < A.Length; j++)
        //        {
        //            Console.WriteLine();
        //        }
        //    }
        //}
        #endregion

        /// <summary>
        /// 17 minutes
        /// 60% (100% + 20% - O(N ** 2))
        /// </summary>
        public static int solution(int[] A)
        {
            var bestAverage = double.MaxValue;
            var startSlice = 0;

            for (int i = 0; i < A.Length; i++)
            {
                var amount = A[i];
                
                for (int j = i+1; j < A.Length; j++)
                {
                    amount += A[j];
                    var j_average = amount / ((j - i + 1) *1.0);

                    if (j_average < bestAverage)
                    {
                        bestAverage = j_average;
                        startSlice = i;
                    }
                }
            }

            return startSlice;
        }
    }
}
