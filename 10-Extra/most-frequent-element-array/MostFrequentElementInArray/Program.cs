using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentElementInArray
{
    class Program
    {
        // making a hash table way
        static int mostFrequent(int[] arr, int n)
        {
            // insert all elements in a dictionary (like hashtable)           

            Dictionary<int, int> hp = new Dictionary<int, int>();                        
            
            for (int i = 0; i < arr.Length; i++)
            {
                int key = arr[i];
                if (hp.ContainsKey(key))
                {
                    //int freq = hp[key];
                    //freq++;
                    //hp[key] = freq;
                    hp[key]++;
                    //Console.WriteLine(key);
                    //Console.WriteLine(hp[key]);
                }
                else
                    hp.Add(key, 1);                    
            }

            // find maximum value

            int min_count = 0, result = 0;
            foreach (var item in hp)
            {
                if (min_count < item.Value)
                {
                    result = item.Key;
                    min_count = item.Value;
                }
            }

            return result;
        }

        static void Main()
        {
            int[] arr = new int[] { 10, 20, 30, 10 };
            int n = arr.Length;

            Console.Write(mostFrequent(arr, n));
            Console.Read();
            
        }
    }
}
