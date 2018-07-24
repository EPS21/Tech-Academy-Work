using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblem1
{
    class Program
    {

        static void Main(string[] args)
        {            
            // Project Euler Problem #1

            // the naive, bruteforcing slower way O(n)
            doEuler1(3, 5, 1000);

            // another way with 3 for loops, more efficent O(?)            
            doEuler2(3, 5, 1000000);            

            // most efficient way doing it arithmetically and no looping O(1)
            doEuler3(3, 5, 1000000);

            Console.ReadLine();
        }        

        private static void doEuler1(int v1, int v2, long v3)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long result = 0;
            for (int i = 1; i < v3; i++)
            {
                if (i % v1 == 0 || i % v2 == 0)
                {
                    result += i;
                }
            }
            Console.WriteLine(result);

            stopwatch.Stop();
            var time = stopwatch.Elapsed;
            Console.WriteLine(time.ToString());
        }

        private static void doEuler2(int v1, int v2, long v3)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // something is getting wrong answer here
            long result = 0;
            for (int i = 1; i < v3; i += v1)
            {
                result += i;
            }
            for (int i = 1; i < v3; i += v2)
            {
                result += i;
            }
            for (int i = 1; i < v3; i += (v1 * v2))
            {
                result -= i;
            }
            Console.WriteLine(result);

            stopwatch.Stop();
            var time = stopwatch.Elapsed;
            Console.WriteLine(time.ToString());
        }

        private static void doEuler3(int v1, int v2, long v3)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long nr = v3;
            nr--;

            long x3 = nr / v1;
            long x5 = nr / v2;
            long x15 = nr / (v1 * v2);

            long sum1 = v1 * x3 * (x3 + 1);
            long sum2 = v2 * x5 * (x5 + 1);
            long sum3 = (v1 * v2) * x15 * (x15 + 1);

            long sum = (sum1 + sum2 - sum3) / 2;
            Console.WriteLine(sum);

            stopwatch.Stop();
            var time = stopwatch.Elapsed;
            Console.WriteLine(time.ToString());
        }
    }
}
