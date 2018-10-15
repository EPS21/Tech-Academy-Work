using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WarCardGameSim
{
    public class Deck
    {
        private List<Card> deck;
        private Random random;
        private StringBuilder sb;

        // Constructor
        public Deck()
        {           

            // The better way, looping through two list of strings
            deck = new List<Card>();
            random = new Random();
            sb = new StringBuilder();

            string[] suits = new string[] { "Clubs", "Hearts", "Diamonds", "Spades" };
            string[] kinds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                            "Jack", "Queen", "King", "Ace" };
            foreach (var suit in suits)
            {
                foreach (var kind in kinds)
                {
                    deck.Add(new Card() { Suit = suit, Kind = kind });
                }
            }

        }

        // Deal method
        public string Deal(Player player1, Player player2)
        {
            while (deck.Count > 0)
            {
                dealCard(player1);
                dealCard(player2);
            }
            return sb.ToString();
        }

        private void dealCard(Player player)
        {
            Card card = deck.ElementAt(random.Next(deck.Count));
            player.Cards.Add(card);
            deck.Remove(card);

            sb.Append("<br/>" + player.Name + " is dealt the " + card.Kind + " of " + card.Suit);            
        }
    }
}