using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroMonsterClasses
{
    public class Dice
    {
        public int Sides { get; set; }

        private int myVar;

        // setting a property can have logic in the class as well to prevent certain values
        // propfull
        public int MyProperty
        {
            get { return myVar; }
            set
            {
                if (value > 1000)
                    myVar = value;
                else
                    throw new Exception();

                myVar = value;
            }
        }

        // for setting a value to the property from only within this class
        // propg
        public int MyProperty1 { get; private set; }


        private Random random = new Random();
        public int Roll()
        {
            return random.Next(1, this.Sides);
        }
    }
}