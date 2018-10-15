using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mexican_Wave
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in wave("two words"))
            {
                Console.WriteLine(item);
            }



            Console.Read();
        }

        public static List<string> wave(string str)
        {
            // the list of strings to be returned
            List<string> result = new List<string>();
            
            // the original string split into a list of chars
            List<char> splitStr = str.ToCharArray().ToList();

            for (int i = 0; i < splitStr.Count; i++)
            {
                StringBuilder sb = new StringBuilder();

                // check if array value is not blank, if it is, ignore it and move on
                if (splitStr[i] != ' ')
                {
                    char temp = Char.ToUpper(splitStr[i]);
                    splitStr.Remove(splitStr[i]);
                    splitStr.Insert(i, temp);
                                      



                    char temp2 = Char.ToLower(splitStr[i]);
                    splitStr.Remove(splitStr[i]);
                    splitStr.Insert(i, temp2);

                    result.Add(sb.ToString());
                    //Console.WriteLine(splitStr.ToString());

                }

                foreach (var item in splitStr)
                {
                    sb.Append(item);
                }

            }
            return result;
        }
    }
}
