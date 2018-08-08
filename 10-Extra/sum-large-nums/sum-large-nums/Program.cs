using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_large_nums
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given an array of integers, write a method to sum the elements in the array, 
            // knowing that some of the elements may be very large integers.
            BigInteger value = BigInteger.Pow(3, 100000);

            //decimal value1 = 10000000000000000000000000000M; // almost largest decimal value
            BigInteger[] numArray = new BigInteger[] { value, value, value, value, value, value, value,
                                                       value, value, value, value, value, value * 50 };
            Console.Write(sumArray(numArray));            
            Console.Read();            
        }

        // Using BigInteger class
        static BigInteger sumArray(BigInteger[] array)
        {
            BigInteger bigNumbers = 0;            
            for (int i = 0; i < array.Length; i++)
            {
                bigNumbers += array[i];
            }
            return bigNumbers;
        }

        // TODO: Using string conversion and concatenation
        
    }
}
