using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WarCardGameSim
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            //Deck newDeck = new Deck();
            //foreach (var card in newDeck.deck)
            //{
            //    resultLabel.Text += "<br/>" + card.Kind + " " + card.Suit;
            //}

            Game game = new Game("Player 1", "Player 2");
            resultLabel.Text =  game.Play();

        }
    }
}