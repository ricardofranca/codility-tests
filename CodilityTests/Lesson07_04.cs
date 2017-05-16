using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTests
{
    public class Lesson07_04
    {
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 07.4");

            AsserAlgorithm(new int[] { 8,8,5,7,9,8,7,4,8 }, 7);

            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] H, int expectedResult)
        {
            var result = solution(H);

            if (result != expectedResult)
                //if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        public static int solution(int[] H)
        {
            var count = 0;
            var queue = new Queue<int>(H.OrderByDescending(x => x));
            var N = H.Length;

            for (int i = 0; i < queue.Count;)
            {
                var currentColumnSize = queue.Dequeue();

                if (currentColumnSize >= N)
                {
                    count++;
                    continue;
                }

                //minor first
                queue = new Queue<int>(queue.Reverse());

                for (int j = 0; j < queue.Count; j++)
                {
                    currentColumnSize += queue.Dequeue();

                    if (currentColumnSize >= N)
                    {
                        count += j + 1;
                        break;
                    }
                }

                //setting back to greather first
                queue = new Queue<int>(queue.Reverse());
            }
            
            //var  H.OrderByDescending(x => x).ToList()

            return count;
        }

    }
}
