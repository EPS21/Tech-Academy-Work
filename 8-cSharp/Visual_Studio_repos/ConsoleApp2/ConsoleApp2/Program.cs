using System;

namespace ConsoleApp2
{
    class Program
    {
        class Result
        {
            public string str;
            public int num;            
        }

        static void Main(string[] args)
        {
            var result = GetTuple("asdf", 3);
            var result2 = addAndString(5, "zxcv");

            Console.WriteLine(result2.str);
            Console.WriteLine(result2.num);
            Console.ReadLine();
        }

        private static Tuple<string, int> GetTuple(string x, int y)
        {
            return Tuple.Create(x, y);
        }

        private static Result addAndString(int number, string inputStr)
        {
            var result = new Result
            {
                str = inputStr + number.ToString(),
                num = number * 2
            };
            return result;
        }

    }
}
