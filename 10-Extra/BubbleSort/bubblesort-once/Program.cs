using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // insert 5 random elements in the array
            Random r = new Random();
            int[] arr = new int[5] { r.Next(1,101), r.Next(1, 101), r.Next(1, 101), r.Next(1, 101), r.Next(1, 101) };

            Console.Write("Unsorted array: " + printArr(arr) + "\n");               
            Console.Write("Bubble-Sorted all the way array: " + printArr(BubbleSort(arr)) + "\n");
            Console.Read();
        }

        public static int[] BubbleSort(int[] arr)
        {
            //int n = arr.Length;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++) // -i because the largest element will be bubbled at the end so we don't have to compare.
                {                    
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }        

        public static string printArr(int[] input)
        {
            StringBuilder sb = new StringBuilder();
            int n = input.Length;
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i] + " ");
            }
            return sb.ToString();
        }
    }
}
