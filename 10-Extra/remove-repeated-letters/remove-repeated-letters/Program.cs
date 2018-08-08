using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remove_repeated_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given a string, remove any repeated letters.
            // Consider keeping numbers or other characters? compare to list of letters
            string exampleString = "111222333AAbbaacczzeeeeeYYY!@#$$$$";

            Console.Write("Input a string (repeated letters will be removed): ");
            string inputString = Console.ReadLine();
            Console.WriteLine(removeRepeatedLetters(inputString)); // should get "111222333AbaczeY!@#$$$$"
            Console.Read();
        }

        static string removeRepeatedLetters(string str)
        {
            Hashtable ht = new Hashtable();            
            StringBuilder sb = new StringBuilder();   
            var alphaArray = new char[] { 'a', 'e', 'i', 'o', 'u', 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'x', 'z', 'w', 'y',
                                          'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'  };            
                        
            // iterate through each character in string
            for (int i = 0; i < str.Length; i++)
            {                
                char key = str[i];                
                if (!ht.Contains(key) && alphaArray.Contains(key))
                {
                    // increase the value of the key                    
                    //int old = (int)ht[key];
                    //ht[key] = old + 1;    
                                        
                    sb.Append(key);
                    ht.Add(key, 1);
                }
                else if (!ht.Contains(key) && !alphaArray.Contains(key))
                {
                    sb.Append(key);
                }
            }
            return sb.ToString();        
        }
    }
}
