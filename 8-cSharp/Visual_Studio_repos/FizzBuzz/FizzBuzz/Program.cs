using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    { 
        static void Main(string[] args)
        {
            //string[] arr = new string[100];
            List<string> myCollection = new List<string>();
            
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    myCollection.Add("fizzbuzz (" + i + ")");
                    //Console.WriteLine(myCollection[i]);
                }
                else if (i % 3 == 0)
                {
                    myCollection.Add("fizz (" + i + ")");
                    //Console.WriteLine(myCollection[i]);
                }
                else if (i % 5 == 0)
                {
                    myCollection.Add("buzz (" + i + ")");
                    //Console.WriteLine(myCollection[i]);
                }                
                else
                {
                    myCollection.Add(i.ToString());
                    //Console.WriteLine(myCollection[i]);
                }                        
            }

            foreach (var item in myCollection)
            {
                Console.WriteLine(item);
            }
            
            Console.Read(); // for having console not go away immediately
        }
    }
}
