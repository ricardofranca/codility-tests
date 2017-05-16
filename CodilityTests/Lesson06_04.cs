using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityTests
{
    public class Lesson06_04
    {
        /// <summary>
        /// MEDIUM
        /// </summary>
        public static void Execute()
        {
            Console.WriteLine("Starting Lesson 06.4");

            AsserAlgorithm(new int[] { 1, 5, 2, 1, 4, 0 }, 11);


            Console.WriteLine("Everything OK");
        }

        public static void AsserAlgorithm(int[] A, int expectedResult)
        {
            var result = solution(A);

            if (result != expectedResult)
                //if (string.Join(",", result) != string.Join(",", expectedResult))
                throw new Exception($"Should be {expectedResult} instead of {result}");
        }

        public static int solution(int[] A)
        {
            var disks = new List<Disk>();
            var intercepts = 0;

            for (int i = 0; i < A.Length; i++)
            {
                disks.Add(new Disk
                {
                    n = i,
                    x1 = i - A[i],
                    x2 = i + A[i]
                });
            }

            //foreach (var d in disks)
            //{
            //    Console.WriteLine(d);
            //}

            for (int i = 0; i < disks.Count; i++)
            {
                /*
                    left side
                    right side
                    inside 
                 */

                var currentDisk = disks[i];

                var doesWhatEver = disks.GetRange(i + 1, disks.Count - i - 1)
                    .Where(x => x.n != i && (x.x1 >= currentDisk.x1 || x.x2 <= currentDisk.x2) && (x.x1 == currentDisk.x1 & x.x2 == currentDisk.x2));

                //var onlyLeftPart = disks.GetRange(i + 1, disks.Count - i - 1)
                //    .Where(x => x.n != i && x.x1 >= currentDisk.x1).Select(x => x.n);

                //var onlyRightPart = disks.GetRange(i + 1, disks.Count - i - 1)
                //    .Where(x => x.n != i && x.x2 <= currentDisk.x2).Select(x => x.n);


                
                //intercepts += onlyLeftPart Count() + onlyRightPart.Count();

                intercepts += doesWhatEver.Count();

                if (intercepts > 10000000)
                    return -1;
            }

            return intercepts;
        }
    }

    public class Disk
    {
        public int x1;
        public int x2;
        public int n;


        public override string ToString()
        {
            return $"[{n}] - {x1} {x2}";
        }
    }
}
