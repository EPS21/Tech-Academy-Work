using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Battle
    {
        private Player _player1;
        private Player _player2;

        public Battle(string p1Name, string p2Name)
        {
            _player1 = new Player { Name = p1Name };
            _player2 = new Player { Name = p2Name };
        }

        public string Play()
        {
            Deck deck = new Deck();
            return deck.Deal(_player1, _player2);            
        }
    }
}