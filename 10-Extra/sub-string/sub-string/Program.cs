using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sub_string
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<int> collection = AllIndexesOf("and the the cat is on the mat", "the");

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }            

            //String str = "the cat is on mat";
            //int firstIndex = str.IndexOf("the");
            //int lastIndex = str.LastIndexOf("the");

            //Console.WriteLine($"Found first index at {firstIndex}");
            //Console.WriteLine($"Found last index at {lastIndex}");

            Console.Read();
        }

        
        public static List<int> subString(string str, string sub)
        {
            // if the inputted substring is null or empty
            if (String.IsNullOrEmpty(sub))
                throw new ArgumentException("the string to find cannot be empty", "sub");

            List<int> indexes = new List<int>();
                                    
            // loop through original input string characters
            for (int index = 0; ; index++)
            {
                index = str.IndexOf("sub", index);
            }

            return indexes;   
        }
        

        public static List<int> AllIndexesOf(string str, string sub)
        {

            if (String.IsNullOrEmpty(sub) || string.IsNullOrEmpty(str))
                throw new ArgumentException("the string must have a value", "value");

            List<int> indexes = new List<int>();            

            for (int index = 0; index < str.Length; index += sub.Length)
            {
                // this will set the index to the next point of the substring value by using IndexOf method
                index = str.IndexOf(sub, index);              
                
                if (index != -1)
                    indexes.Add(index);
                if (index == -1)
                    return indexes;                
            }
            return indexes;
        }

    }
}
