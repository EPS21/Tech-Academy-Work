using System;
using System.Collections.Generic;
using System.Text;

namespace oops_practice
{
    class Program
    {
        static void Main()
        {
            //MyClass a = new MyClass();
            //Console.WriteLine(a.myMethod(12));
            ////MyClass b = new MyClass();
            //Console.WriteLine(a.myMethod((decimal)4));
            ////MyClass c = new MyClass();
            //Console.WriteLine(a.myMethod("5"));

            //string userinput = Console.ReadLine();
            //Console.Write("Enter a number: ");
            //int x = Convert.ToInt32(userinput);
            //Console.WriteLine("Your number times 5 is: " + x * 5);

            //string userInput;
            //int intVal;

            MyClass2 a = new MyClass2();
            MyClass b = new MyClass();

            

            //a.myMethod(intVal);
            //int result = b.myMethod(Convert.ToInt32(userInput));

            // make a while loop just keep asking

            while (true)
            {
                Console.Write("Enter a number: ");
                string userInput = Console.ReadLine();
                bool ifIntVal = int.TryParse(userInput, out int parsedResult);

                if (ifIntVal)
                {
                    Console.WriteLine($"You entered an int of {parsedResult}");
                }

                string result = b.reverseString(userInput);
                Console.WriteLine(result);

            }








            Console.Read();
        }
    }

    class MyClass
    {
        public int x { get; set; }
        public int y { get; set; }

        public int myMethod(int x)
        {
            x = x * x;
            return x;
        }

        public int myMethod(decimal x)
        {
            x = x + x;
            return (int)x;
        }

        public int myMethod(string x)
        {
            //int result = int.Parse(x);
            int result = Convert.ToInt32(x);
            return result + 5;
        }

        // there we go reversed a string again
        public string reverseString(string input)
        {
            List<char> x = new List<char>();
            
            StringBuilder sb = new StringBuilder();

            foreach (char character in input)
            {
                x.Add(character);
            }
            
            for (int i = x.Count - 1; i >= 0; i--)
            {
                sb.Append(x[i]);
            }

            return sb.ToString();
        }
    }
}
