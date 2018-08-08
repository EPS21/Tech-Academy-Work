using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace total_odd_nums
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given an array of integers, write a method to total the odd numbers.
            int[] numArray = new int[] { 0, -1, -80, 100, 101, 57 };
            Console.Write(totalOddNums(numArray));
            Console.Read();
        }

        static int totalOddNums(int[] array)
        {
            int oddNums = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                    oddNums += array[i];
            }
            return oddNums;
        }
    }
}
