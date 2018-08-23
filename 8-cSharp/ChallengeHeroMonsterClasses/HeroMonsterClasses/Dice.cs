using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroMonsterClasses
{
    public class Dice
    {
        public int Sides { get; set; }     

        Random random = new Random();
        public int Roll()
        {
            // returns a number between 1 (inclusive) and Sides (inclusive)
            return random.Next(1, Sides + 1);
        }
    }
}