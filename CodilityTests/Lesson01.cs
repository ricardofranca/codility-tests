using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTests
{
    public static class Lesson01
    {
        /// <summary>
        /// Result = 100% (41 minutes)
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 01");

            AsserAlgorithm(9, 2);
            AsserAlgorithm(15, 0);
            AsserAlgorithm(20, 1);
            AsserAlgorithm(529, 4);
            AsserAlgorithm(1041, 5);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int number, int expectedResult)
        {
            var result = solution(number);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }


        public static int solution(int number)
        {
            var longestBinaryGap = 0;

            var binary = Convert.ToString(number, 2);
            
            var currentCheck = 0;

            for (int j = 0; j < binary.Length; j++)
            {
                if (binary[j] == '1')
                {
                    longestBinaryGap = currentCheck > longestBinaryGap ? currentCheck : longestBinaryGap;
                    currentCheck = 0;
                }
                else
                {
                    currentCheck++;
                }
            }

            return longestBinaryGap;
        }
    }
}
