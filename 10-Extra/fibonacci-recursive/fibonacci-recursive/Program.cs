using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonacci_recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            // want to return nth value in fib sequence
            // 0, 1, 1, 2, 3, 5, 8, 13, etc.

            Console.Write(findFibValueRecursive(7));

            Console.Beep();
            Console.Read();
        }

        private static int findFibValueRecursive(int n)
        {
            if (n == 0) return 0;
            else if (n == 1) return 1;
            else return findFibValueRecursive(n - 1) + findFibValueRecursive(n - 2);
        }

    }
    
}
