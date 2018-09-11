using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factorial_recursive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(findFactorialRecursive(5));

            Console.Beep();
            Console.Read();
        }

        private static int findFactorialRecursive(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            else return n * findFactorialRecursive(n - 1);
        }
    }
}
