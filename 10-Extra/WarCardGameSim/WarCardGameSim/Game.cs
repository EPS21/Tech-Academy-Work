using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarCardGameSim
{
    public class Game
    {
        Player player1;
        Player player2;
        Deck deck;

        public Game(string player1Name, string player2Name)
        {
            player1 = new Player() { Name = "Player 1" };
            player2 = new Player() { Name = "Player 2" };
            deck = new Deck();
        }

        public string Play()
        {
            return deck.Deal(player1, player2);
        }
    }
}