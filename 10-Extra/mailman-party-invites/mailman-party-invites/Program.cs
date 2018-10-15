using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mailman_party_invites
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        public static int invitations(int n)
        {
            Recip[] arrayOfDudes = new Recip[n];

            for (int i = 0; i < arrayOfDudes.Length; i++)
            {
                arrayOfDudes[i].hasGotInv = true;
            }
            // return all possible iterations
            // n the number of people
            return n;
        }

        public class Recip
        {
            public bool hasGotInv { get; set; }
        }




    }
}
