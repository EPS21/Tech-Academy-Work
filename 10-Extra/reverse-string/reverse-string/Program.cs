using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given a string, reverse it.
            string str = "qwerasdf1234";
            Console.Write(reverseString(str));
            // read to keep console window from immediately closing
            Console.Read();
        }

        static string reverseString(string str)
        {
            // Using StringBuilder class to concatenate strings more efficiently
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
    }
}
