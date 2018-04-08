using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts
{
    public class Dart
    {
        public int Score { get; set; }
        public bool isDouble { get; set; }
        public bool isTriple { get; set; }
        public bool isBullsEye { get; set; }

        //private Random _random;
        private Random _random = new Random();

        // Need a constructor to pass in random
        public Dart(Random random)
        {
            _random = random;
        }

        public void Throw()
        {
            // The chance of scoring ZERO through twenty
            Score = _random.Next(0, 21);

            if (Score == 0)
            {
                isBullsEye = true;
            }

            // The 5% chance it can land on the inner or outer rings for double and triple bonuses
            int multiplier = _random.Next(1, 101); // Inclusive 1, Exclusive 101 (so 1-100)           
            if (multiplier > 95)
            {
                isTriple = true;
            } 
            else if (multiplier > 90 && multiplier <= 95)
            {
                isDouble = true;
            }
            

        }

    }
}
