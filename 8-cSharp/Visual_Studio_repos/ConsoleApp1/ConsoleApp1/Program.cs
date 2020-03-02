using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 8 };
            // [1,2,3,4,8]


            Console.Write(SingleNonDuplicate(nums));
            Console.ReadLine();
        }

        public static int SingleNonDuplicate(int[] nums)
        {
            int counter;
            var dist = nums.Distinct();
            int result = 0;

            foreach (var numDist in dist)
            {
                counter = 0;

                foreach (var num in nums)
                {
                    if (num == numDist)
                    {
                        counter++;
                    }
                }

                if (counter == 1)
                {
                    result = numDist;
                    break;
                }

            }

            return result;

        }
    }
}
