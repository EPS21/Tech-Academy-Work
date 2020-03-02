using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] arr = new int[5] { r.Next(1, 101), r.Next(1, 101), r.Next(1, 101), r.Next(1, 101), r.Next(1, 101) };
            //int[] arr = new int[4] { 5, 3, 6, 2 };

            Console.WriteLine($"Original array: {printArr(arr)}");   
            //Console.WriteLine($"Lowest item in array: {getLowest(arr)}");
            Console.WriteLine($"Sorted Array: {printArr(selectionSort(arr))}");
            Console.ReadKey();
            
        }


        static int[] selectionSort(int[] arr)
        {
            int temp;
            int lowest; // lowest is index of lowest item
            for (int i = 0; i < arr.Length; i++)
            {
                lowest = i; // assume first item in outer loop is lowest, lowest is like counter
                for (int j = i + 1; j < arr.Length - 1; j++) // arr.Length - 1 because we will already have sorted array at last one
                {
                    if(arr[j] < arr[lowest])
                    {
                        lowest = j; // lowest index is now j
                    }
                }

                // after inner loop runs, set arr[i] to lowest
                temp = arr[lowest];
                arr[lowest] = arr[i];
                arr[i] = temp;
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
