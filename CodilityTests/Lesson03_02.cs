using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTests
{
    public static class Lesson03_02
    {
        /// <summary>
        /// EASY
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 03.2");

            AsserAlgorithm(10,85,30,3);

            AsserAlgorithm(10,10,5,0);

            AsserAlgorithm(5,10,1,5);


            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int X, int Y, int D, int expectedResult)
        {
            var result = solution(X,Y,D);

            if (result != expectedResult)
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        /// <summary>
        /// 100%
        /// </summary>
        public static int solution(int X, int Y, int D)
        {
            if (X == Y) return 0;


            var temp = Y - X;

            //resto
            var mod = temp % D;

            var divided = temp / D;

            if (mod == 0)
                return divided;
            else
                return divided + 1;
        }

    }
}
