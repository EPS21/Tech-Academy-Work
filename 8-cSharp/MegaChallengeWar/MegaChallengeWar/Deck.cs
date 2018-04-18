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
                new Card { Value = 2, ValueName = "2", Suit = "Spades"},
                new Card { Value = 3, ValueName = "3", Suit = "Spades"},
                new Card { Value = 4, ValueName = "4", Suit = "Spades"},
                new Card { Value = 5, ValueName = "5", Suit = "Spades"},
                new Card { Value = 6, ValueName = "6", Suit = "Spades"},
                new Card { Value = 7, ValueName = "7", Suit = "Spades"},
                new Card { Value = 8, ValueName = "8", Suit = "Spades"},
                new Card { Value = 9, ValueName = "9", Suit = "Spades"},
                new Card { Value = 10, ValueName = "10", Suit = "Spades"},
                new Card { Value = 11, ValueName = "Jack", Suit = "Spades"},
                new Card { Value = 12, ValueName = "Queen", Suit = "Spades"},
                new Card { Value = 13, ValueName = "King", Suit = "Spades"},
                new Card { Value = 14, ValueName = "Ace", Suit = "Spades"},

                // diamonds
                new Card { Value = 2, ValueName = "2", Suit = "Diamonds"},
                new Card { Value = 3, ValueName = "3", Suit = "Diamonds"},
                new Card { Value = 4, ValueName = "4", Suit = "Diamonds"},
                new Card { Value = 5, ValueName = "5", Suit = "Diamonds"},
                new Card { Value = 6, ValueName = "6", Suit = "Diamonds"},
                new Card { Value = 7, ValueName = "7", Suit = "Diamonds"},
                new Card { Value = 8, ValueName = "8", Suit = "Diamonds"},
                new Card { Value = 9, ValueName = "9", Suit = "Diamonds"},
                new Card { Value = 10, ValueName = "10", Suit = "Diamonds"},
                new Card { Value = 11, ValueName = "Jack", Suit = "Diamonds"},
                new Card { Value = 12, ValueName = "Queen", Suit = "Diamonds"},
                new Card { Value = 13, ValueName = "King", Suit = "Diamonds"},
                new Card { Value = 14, ValueName = "Ace", Suit = "Diamonds"},

                // hearts
                new Card { Value = 2, ValueName = "2", Suit = "Hearts"},
                new Card { Value = 3, ValueName = "3", Suit = "Hearts"},
                new Card { Value = 4, ValueName = "4", Suit = "Hearts"},
                new Card { Value = 5, ValueName = "5", Suit = "Hearts"},
                new Card { Value = 6, ValueName = "6", Suit = "Hearts"},
                new Card { Value = 7, ValueName = "7", Suit = "Hearts"},
                new Card { Value = 8, ValueName = "8", Suit = "Hearts"},
                new Card { Value = 9, ValueName = "9", Suit = "Hearts"},
                new Card { Value = 10, ValueName = "10", Suit = "Hearts"},
                new Card { Value = 11, ValueName = "Jack", Suit = "Hearts"},
                new Card { Value = 12, ValueName = "Queen", Suit = "Hearts"},
                new Card { Value = 13, ValueName = "King", Suit = "Hearts"},
                new Card { Value = 14, ValueName = "Ace", Suit = "Hearts"},

                // clubs
                new Card { Value = 2, ValueName = "2", Suit = "Clubs"},
                new Card { Value = 3, ValueName = "3", Suit = "Clubs"},
                new Card { Value = 4, ValueName = "4", Suit = "Clubs"},
                new Card { Value = 5, ValueName = "5", Suit = "Clubs"},
                new Card { Value = 6, ValueName = "6", Suit = "Clubs"},
                new Card { Value = 7, ValueName = "7", Suit = "Clubs"},
                new Card { Value = 8, ValueName = "8", Suit = "Clubs"},
                new Card { Value = 9, ValueName = "9", Suit = "Clubs"},
                new Card { Value = 10, ValueName = "10", Suit = "Clubs"},
                new Card { Value = 11, ValueName = "Jack", Suit = "Clubs"},
                new Card { Value = 12, ValueName = "Queen", Suit = "Clubs"},
                new Card { Value = 13, ValueName = "King", Suit = "Clubs"},
                new Card { Value = 14, ValueName = "Ace", Suit = "Clubs"},

            };
        }

        // Calls Shuffle() method to shuffle the cards, then adds each card to 
        // each players hand and removes it from the deck each time
        public string Deal(Player player1, Player player2)
        {
            shuffle();
            while (_cards.Count > 0)
            {
                dealCard(player1);
                dealCard(player2);
            }
            return _sb.ToString();
        }

        // shuffle the cards and put them in a random order
        private void shuffle()
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
            _sb.Append(card.ValueName + " of " + card.Suit);
        }
        

    }
}