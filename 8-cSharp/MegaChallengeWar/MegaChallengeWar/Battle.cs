using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaChallengeWar
{
    public class Battle
    {
        private Player _player1;
        private Player _player2;
        private StringBuilder _sb = new StringBuilder();
        private StringBuilder _display = new StringBuilder();
        private List<Card> _tempcards = new List<Card>();
        private bool _p1IsWinner;
        private bool _isWar = false;
        private int _turns = 0;

        // Constructor
        public Battle(string p1Name, string p2Name)
        {
            _player1 = new Player { Name = p1Name };
            _player2 = new Player { Name = p2Name };
        }

        // Main method for playing the game
        public string Play()
        { 
            // make a new deck of cards
            Deck deck = new Deck();

            // deal the cards to each player evenly
            _display.Append("<h3>Dealing cards...</h3><br/>");
            _display.Append( deck.Deal(_player1, _player2) ); // Deal returns a string

            // Battle Sequence Loop and Game logic
            _display.Append("<h3>Begin battle...</h3><br/>");
            while (_turns < 20)
            {
                displayBattleCards(_player1.Cards, _player2.Cards, 0, 0);
                compareCards(_player1.Cards.ElementAt(0), _player2.Cards.ElementAt(0));
                
                if (_isWar)
                {
                    war();                    
                }                
                else
                {
                    _display.Append("Bounty ...<br/>");
                    removeCard(_player1);
                    removeCard(_player2);
                    calculateWinner();
                }

                // Uncomment this to see how many cards each player has at the end of each round
                //_display.Append(_player1.Name + " has " + _player1.Cards.Count.ToString() + " cards. ");
                //_display.Append(_player2.Name + " has " + _player2.Cards.Count.ToString() + " cards.<br/><br/>");

                // clearing the tempcards before the next round
                _tempcards = new List<Card>();
                // incrementing turns
                _turns++;
            }

            if (_player1.Cards.Count > _player2.Cards.Count) _display.Append("<b><font color='red'>Player 1 Wins!</font></b><br/>");
            else if (_player1.Cards.Count < _player2.Cards.Count) _display.Append("<b><font color='blue'>Player 2 Wins!</font></b><br/>");
            else _display.Append("<b><font color='green'>It's a tie game!</font></b><br/>");

            // ternary of above but dunno how to account for tie game
            //_display.Append((_player1.Cards.Count > _player2.Cards.Count) ? "<b><font color='red'>Player 1 Wins!</font></b><br/>" :
            //    "<b><font color='blue'>Player 2 Wins!</font></b><br/>");
                        
            _display.Append("<b><font color='red'>" + _player1.Name + ":" + _player1.Cards.Count.ToString() + "</font></b><br/>");
            _display.Append("<b><font color='blue'>" + _player2.Name + ":" + _player2.Cards.Count.ToString() + "</font></b><br/>");
            return _display.ToString();
        }

        // compare the two cards removed and see who's is higher
        private void compareCards(Card card1, Card card2)
        {
            if (card1.Value > card2.Value) _p1IsWinner = true;
            else if (card1.Value < card2.Value) _p1IsWinner = false;
            else _isWar = true;            
        }

        // this war method evaluates the last card drawn by the player to evaluate the winner
        private void war()
        {
            _isWar = false;
            _display.Append("***************WAR***************<br/><br/>");

            removeCard(_player1);
            removeCard(_player2);

            removeCard(_player1);
            removeCard(_player2);
            removeCard(_player1);
            removeCard(_player2);
            removeCard(_player1);
            removeCard(_player2);

            displayBattleCards(_tempcards, _tempcards, _tempcards.Count - 2, _tempcards.Count - 1);

            compareCards(_tempcards.ElementAt(_tempcards.Count - 2), _tempcards.ElementAt(_tempcards.Count - 1));
            if (_isWar == true)
            {
                war();
            }
            else
            {
                calculateWinner();
            }            
        }

        // remove the top card from the players deck and store in temp list
        private void removeCard(Player player)
        {
            _display.Append("&emsp;" + player.Cards.ElementAt(0).ValueName + " of " + player.Cards.ElementAt(0).Suit + "<br/>").ToString();
            Card card = player.Cards.ElementAt(0); // Card at element 0 (top of deck), (playerCards.Count - 1) is element 25 at bottom
            _tempcards.Add(card);            
            player.Cards.Remove(card);            
        }       

        // takes the cards from _tempcards and adds them to bottom of players deck
        private void addCards(Player player)
        {
            foreach (var card in _tempcards)
            {
                player.Cards.Add(card);
            }
            _display.Append("<b>" + player.Name + " wins!</b><br/><br/>");
        }

        // determines who is the winner of the game, then calls addCards to give those cards to the winner
        private void calculateWinner()
        {
            if (_p1IsWinner == true)
            {
                addCards(_player1);
            }
            else if (_p1IsWinner == false)
            {
                addCards(_player2);
            }
        }

        private void displayBattleCards(List<Card> cards1, List<Card> cards2, int index1, int index2)
        {
            _display.Append(String.Format("Battle Cards: {0} of {1} versus {2} of {3}<br/>",
                    cards1.ElementAt(index1).ValueName,
                    cards1.ElementAt(index1).Suit,
                    cards2.ElementAt(index2).ValueName,
                    cards2.ElementAt(index2).Suit));            
        }

    }
}