using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursive_multiplication_division
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(multiplyRecursive(15, 3));
            Console.WriteLine(divideRecursive(15, 3));

            Console.Beep();
            Console.Read();
        }

        private static int multiplyRecursive(int x, int y)
        {
            if (y == 1) return x;
            if (x == 0 || y == 0) return 0;
            return x + multiplyRecursive(x, y - 1);
        }

        private static int divideRecursive(int x, int y)
        {
            if (x < y) return 0;
            if (x <= 0) return 0;
            return 1 + divideRecursive(x - y, y);
        }
        


    }

    
}
