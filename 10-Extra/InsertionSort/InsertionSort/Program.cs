using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[4] { 5, 3, 6, 2 };
            Console.WriteLine("Original Array: " + printArr(arr));
            Console.WriteLine("Sorted Array: " + printArr(insertionSort(arr)));
            Console.ReadKey();
            
        }

        static int[] insertionSort(int[] arr)
        {
            int temp;
            for (int i = 1; i < arr.Length - 1; i++) // start at arr[1], because leftmost has nothing on left
            {
                if (arr[i - 1] > arr[i])
                {
                    // swap
                    temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                }                
            }            

            return arr;
        }
        


        static string printArr(int[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var num in array)
            {
                sb.Append($"{num} ");
            }
            return sb.ToString();
        }
    }
}
