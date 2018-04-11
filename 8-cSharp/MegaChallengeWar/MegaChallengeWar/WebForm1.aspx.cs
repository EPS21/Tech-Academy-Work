using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            var battoru = new Battle("Player 1", "Player 2");
            resultLabel.Text = battoru.Play();
                       
            
            
            
            // Testing shuffling the cards
            /*
            resultLabel.Text = "";
            Deck deck = new Deck();
            deck.Shuffle();
            foreach (var card in deck._cards) // deck.cards needs public cards in Deck class
            {
                resultLabel.Text += card.Value + " " + card.Suit + "</br>";
            }
            */

            // Testing cards are distributed to each player properly
            /*
            resultLabel.Text = "";
            Player player1 = new Player { Name = "Mr. P1"};
            Player player2 = new Player { Name = "Mr. P2" };

            Deck deck = new Deck();            
            deck.Deal(player1, player2);

            resultLabel.Text = "<h1> Dealing cards... </h1><br/>";

            resultLabel.Text += player1.Name + "<br/>";
            foreach(var card in player1.Cards)
            {
                resultLabel.Text += card.Value + " " + card.Suit + "</br>";
            }            

            
            resultLabel.Text += "<br/>" + player2.Name + "<br/>";
            foreach (var card in player2.Cards)
            {
                resultLabel.Text += card.Value + " " + card.Suit + "</br>";
            }
            */
            
            
        }
    }
}