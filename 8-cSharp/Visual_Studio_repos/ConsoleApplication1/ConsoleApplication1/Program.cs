﻿using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {           
            Console.Beep();
            
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
            Console.Read();
        }
    }
}