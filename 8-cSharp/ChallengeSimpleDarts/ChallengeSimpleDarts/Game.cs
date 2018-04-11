using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Game
    {
        private Player Player1;
        private Player Player2;

        private Random random;

        // Constructor
        public Game(string player1Name, string player2Name)
        {
            Player1 = new Player();
            Player1.Name = player1Name;

            Player2 = new Player();
            Player2.Name = player2Name;

            // is this needed? Yes it is
            random = new Random();
        }

        public string PlayGame()
        {
            while (Player1.Score < 300 && Player2.Score < 300)
            {
                playRound(Player1);
                playRound(Player2);
            }

            return displayResults();
        }

        private string displayResults()
        {
            string result = string.Format("{0}: {1}<br/>{2}: {3}", 
                Player1.Name, 
                Player1.Score, 
                Player2.Name, 
                Player2.Score);            

            string playerWhoWon = "";
            if (Player1.Score > Player2.Score)
                playerWhoWon = Player1.Name;
            else if (Player2.Score > Player1.Score)
                playerWhoWon = Player2.Name;
            
            return result += "<br/>Winner: " + playerWhoWon;

            //result += "Winner: " + (Player1.Score > Player2.Score ? Player1.Name : Player2.Name);
        }

        private void playRound(Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                Dart dart = new Dart(random);
                dart.Throw();
                //Score scorez = new Score(); // non static way
                Score.ScoreDart(player, dart); // static method from Score.cs
            }
            
        }
    }
}