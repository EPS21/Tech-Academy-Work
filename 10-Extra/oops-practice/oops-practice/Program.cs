using System;

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

            Console.Write("Enter a number: ");
            string userInput = Console.ReadLine();
            //int intVal = Convert.ToInt32(userInput);

            //a.myMethod(intVal);
            a.myMethod(Convert.ToInt32(userInput));

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
    }
}
