using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program

    {   
        static int highestSum(int[] nums)
        {
            int highest = 0;            

            // find highest value in array
            foreach (var item in nums)
            {
                if (item > highest)
                {
                    highest = item;
                }
            }

            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    int sum = nums[i];
            //    for (int j = 0; j < nums.Length; j++)
            //    {
            //        if (i < j)
            //        {
            //            sum += nums[j];
            //            if (sum > highest)
            //            {
            //                highest = sum;
            //            }
            //        }
            //    }
            //}

            return highest;
        }

        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, -8, 3, -2, 4, -10 };

            Console.WriteLine(highestSum(nums));
            Console.Read();
        }
    }
}
