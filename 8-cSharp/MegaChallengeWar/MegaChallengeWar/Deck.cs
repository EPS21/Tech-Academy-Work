using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace MegaChallengeWar
{
    public class Deck
    {
        // cards is private until Deal method is called? 
        private List<Card> _cards;
        private StringBuilder _sb = new StringBuilder();
        private Random _random = new Random();


        // Constructor
        public Deck()
        {            
            _cards = new List<Card>
            {
                // 52 Cards in here of each number and suit
                // Jack is 11, Queen is 12, King is 13, Ace is 14

                // spades
                new Card { Value = 2, Suit = "spade"},
                new Card { Value = 3, Suit = "spade"},
                new Card { Value = 4, Suit = "spade"},
                new Card { Value = 5, Suit = "spade"},
                new Card { Value = 6, Suit = "spade"},
                new Card { Value = 7, Suit = "spade"},
                new Card { Value = 8, Suit = "spade"},
                new Card { Value = 9, Suit = "spade"},
                new Card { Value = 10, Suit = "spade"},
                new Card { Value = 11, Suit = "spade"},
                new Card { Value = 12, Suit = "spade"},
                new Card { Value = 13, Suit = "spade"},
                new Card { Value = 14, Suit = "spade"},

                // diamonds
                new Card { Value = 2, Suit = "diamond"},
                new Card { Value = 3, Suit = "diamond"},
                new Card { Value = 4, Suit = "diamond"},
                new Card { Value = 5, Suit = "diamond"},
                new Card { Value = 6, Suit = "diamond"},
                new Card { Value = 7, Suit = "diamond"},
                new Card { Value = 8, Suit = "diamond"},
                new Card { Value = 9, Suit = "diamond"},
                new Card { Value = 10, Suit = "diamond"},
                new Card { Value = 11, Suit = "diamond"},
                new Card { Value = 12, Suit = "diamond"},
                new Card { Value = 13, Suit = "diamond"},
                new Card { Value = 14, Suit = "diamond"},

                // hearts
                new Card { Value = 2, Suit = "heart"},
                new Card { Value = 3, Suit = "heart"},
                new Card { Value = 4, Suit = "heart"},
                new Card { Value = 5, Suit = "heart"},
                new Card { Value = 6, Suit = "heart"},
                new Card { Value = 7, Suit = "heart"},
                new Card { Value = 8, Suit = "heart"},
                new Card { Value = 9, Suit = "heart"},
                new Card { Value = 10, Suit = "heart"},
                new Card { Value = 11, Suit = "heart"},
                new Card { Value = 12, Suit = "heart"},
                new Card { Value = 13, Suit = "heart"},
                new Card { Value = 14, Suit = "heart"},

                // clubs
                new Card { Value = 2, Suit = "club"},
                new Card { Value = 3, Suit = "club"},
                new Card { Value = 4, Suit = "club"},
                new Card { Value = 5, Suit = "club"},
                new Card { Value = 6, Suit = "club"},
                new Card { Value = 7, Suit = "club"},
                new Card { Value = 8, Suit = "club"},
                new Card { Value = 9, Suit = "club"},
                new Card { Value = 10, Suit = "club"},
                new Card { Value = 11, Suit = "club"},
                new Card { Value = 12, Suit = "club"},
                new Card { Value = 13, Suit = "club"},
                new Card { Value = 14, Suit = "club"}

            };
        }

        // Calls Shuffle() method to shuffle the cards, then adds each card to 
        // each players hand and removes it from the deck each time
        public string Deal(Player player1, Player player2)
        {
            Shuffle();
            while (_cards.Count > 0)
            {
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }

        // shuffle the cards and put them in a random order
        private void Shuffle()
        {
            List<Card> tempCards = new List<Card>();            
            while (_cards.Count > 0)
            {
                Card card = _cards.ElementAt(_random.Next(_cards.Count));
                tempCards.Add(card);
                _cards.Remove(card);
            }
            _cards = tempCards;
        }        
        
        // Helper method for the Deal method to deal a card for each player
        private void dealCard(Player player)
        {
            Card card = _cards.ElementAt(_cards.Count - 1);
            player.Cards.Add(card);
            _cards.Remove(card);

            _sb.Append("<br/>" + player.Name + " is dealt the ");
            _sb.Append(card.Value + " of " + card.Suit);
        }
        

    }
}