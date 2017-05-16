using System;

namespace CodilityTests
{
    public static class Lesson07_05
    {

        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 07.4");

            AsserAlgorithm(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 }, 2);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int[] B, int expectedResult)
        {
            var result = solution(A, B);

            if (result != expectedResult)
                //if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        public static int solution(int[] A, int[] B)
        {
            int a = A[0];   
            int b = B[0];
            int survive = 0;
            int length = A.Length;

            for (int i = 1; i < length; i++)
            {  
                if (b == B[i])
                {
                    survive += 1;
                    a = A[i];
                    b = B[i];
                }
                else
                {
                    if (A[i] > a)
                    {
                        a = A[i];
                        b = B[i];
                    }
                }
            }

            return survive;
        }
        
    }
}

