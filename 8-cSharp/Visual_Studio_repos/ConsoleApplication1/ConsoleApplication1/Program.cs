using System;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {           
            Console.Beep();
            //System.Threading.Thread.Sleep(2000);
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
            System.Threading.Thread.Sleep(1000);
            Console.Beep();
            Console.WriteLine("I");
            System.Threading.Thread.Sleep(250);
            Console.Beep();
            Console.WriteLine("Love");
            System.Threading.Thread.Sleep(250);
            Console.Beep();
            Console.WriteLine("You!");
            Console.Read();
        }
    }
}
