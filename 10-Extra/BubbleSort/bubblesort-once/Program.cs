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
            int[] arr = new int[] { 5, 3, 2, 6 };

            Console.Write("Unsorted array: " + printArr(arr) + "\n");   
            Console.Write("Bubble-Sorted once array: " + printArr(BubbleSortOnce(arr)) + "\n");
            Console.Write("Bubble-Sorted all the way array: " + printArr(BubbleSort(arr)) + "\n");
            Console.Read();
        }

        public static int[] BubbleSort(int[] arr)
        {
            bool swapped;
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[i] > arr[i + 1]) // if first item is greater than second, want swap
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were swapped by the inner loop, break
                if (swapped == false)
                    break;
            }
            return arr;
        }

        public static int[] BubbleSortOnce(int[] arr)
        {                        
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1]) // if first item is greater than second, want swap
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
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
