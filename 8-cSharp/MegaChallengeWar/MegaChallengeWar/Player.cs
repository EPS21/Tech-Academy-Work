using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }

        // Constructor
        public Player()
        {
            Name = "unnamed";
            Cards = new List<Card>();
        }
    }

    

}