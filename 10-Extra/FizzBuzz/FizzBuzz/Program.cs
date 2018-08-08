using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FizzBuzz
{
    class Program
    { 
        static void Main(string[] args)
        {
            // doing string concatenation
            //doFizzBuzzSb(3, 5, 100);

            // doing adding to a list
            doFizzBuzzList(3, 5, 100);

            Console.Read(); // for having console not go away immediately
        }

        private static void doFizzBuzzList(int v1, int v2, int v3)
        {
            List<string> myCollection = new List<string>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 1; i <= v3; i++)
            {
                if (i % v1 == 0 && i % v2 == 0)
                {
                    myCollection.Add("fizzbuzz (" + i + ")");
                    //Console.WriteLine(myCollection[i]);
                }
                else if (i % v1 == 0)
                {
                    myCollection.Add("fizz (" + i + ")");
                    //Console.WriteLine(myCollection[i]);
                }
                else if (i % v2 == 0)
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

            stopwatch.Stop();
            var time = stopwatch.Elapsed;
            Console.WriteLine(time.ToString());
        }

        private static void doFizzBuzzSb(int v1, int v2, int v3)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= v3; i++)
            {
                sb.Clear();
                //string output = "";

                if (i % v1 == 0)
                {
                    //output += "fizz";
                    sb.Append("fizz");
                }
                if (i % v2 == 0)
                {
                    //output += "buzz";
                    sb.Append("buzz");
                }
                if (sb.Length == 0)
                {
                    //output = i.ToString();
                    sb.Append(i);
                }
                Console.WriteLine(sb);
            }

            stopwatch.Stop();
            var time = stopwatch.Elapsed;
            Console.WriteLine(time.ToString());

        }
    }
}
