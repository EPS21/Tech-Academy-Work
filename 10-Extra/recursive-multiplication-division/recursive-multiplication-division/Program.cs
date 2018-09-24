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

            //Console.WriteLine(multiplyRecursive(15, 3));
            Console.WriteLine(divideRecursive(9, 0));
            //Console.WriteLine(divide(9, 0));

            //Console.Beep();
            Console.Read();
        }

        private static int multiplyRecursive(int x, int y)
        {
            if (y == 1) return x;
            if (x == 0 || y == 0) return 0;
            return x + multiplyRecursive(x, y - 1);
        }

        private static int divideRecursive(int a, int b)
        {
            int answer;

            if (b == 0)
            {
                DivideByZeroException e = new DivideByZeroException();
                Console.Write(e.ToString());
                return 0;
            }

            else if (a < 0 && b < 0)
            {
                a = Math.Abs(a);
                b = Math.Abs(b);
                if (a <= 0) return 0;
                else if (a < b) return 0;
                else return answer = (1 + divideRecursive(a - b, b));
            }

            else if (a < 0 || b < 0)
            {
                a = Math.Abs(a);
                b = Math.Abs(b);
                if (a <= 0) return 0;
                else if (a < b) return 0;
                else
                {
                    answer = (1 + divideRecursive(a - b, b));
                    return answer * -1;
                }
            }

            else
            {
                if (a <= 0) return 0;
                else if (a < b) return 0;
                else return 1 + divideRecursive(a - b, b);
            }
        }

        static int doDivide(int a, int b)
        {

        }

        static int divide(int a, int b)
        {            
            return Math.DivRem(a, b, out int x);
        }
        


    }

    
}
