using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeroMonsterClasses
{   

    public partial class WebForm1 : System.Web.UI.Page
    {        
        // driver code
        protected void Page_Load(object sender, EventArgs e)
        {
            // Making the hero character
            Character hero = new Character() { Name = "Hero-sama", HP = 35,
                                               DamageMaximum = 20, FirstAttack = false };

            // Making the monster character
            Character monster = new Character() { Name = "Tentacle Monster", HP = 21,
                                                  DamageMaximum = 25, FirstAttack = false };
            
            displayCharacterStats(hero);
            displayCharacterStats(monster);
            doBattleLoop(hero, monster);
            displayResult(hero, monster);            
        }

        private void doBattleLoop(Character opponent1, Character opponent2)
        {
            // Making a dice with sides of max damage when it is called in an attack
            Dice dice = new Dice();
            Dice coin = new Dice() { Sides = 2 };
            int flippedCoin = coin.Roll();

            if (flippedCoin == 1)
                opponent1.FirstAttack = true;
            else if (flippedCoin == 2)
                opponent2.FirstAttack = true;
            
            while (opponent2.HP > 0 && opponent1.HP > 0)
            {
                if (opponent1.FirstAttack == true)
                {
                    int opponent1Atk = opponent1.Attack(dice);
                    opponent2.Defend(opponent1Atk); // Attack phase 1 (hero goes first) 
                    displayCharacterStats(opponent1);
                    statsLabel.Text += String.Format("{0} has dealt {1} points of damage to {2}!",
                                                     opponent1.Name, opponent1Atk, opponent2.Name);
                    opponent1.FirstAttack = false;
                    opponent2.FirstAttack = true;
                }
                
                else if (opponent2.FirstAttack == true)
                {
                    int opponent2Atk = opponent2.Attack(dice);
                    opponent1.Defend(opponent2Atk); // Attack phase 2 (monster goes)                
                    displayCharacterStats(opponent2);
                    statsLabel.Text += String.Format("{0} has dealt {1} points of damage to {2}!",
                                                     opponent2.Name, opponent2Atk, opponent1.Name);
                    opponent1.FirstAttack = true;
                    opponent2.FirstAttack = false;
                }
            }
        }

        //private int coinFlip()
        //{
        //    Dice coin = new Dice() { Sides = 2 };
        //    return coin.Roll();
        //}

        private void displayCharacterStats(Character character)
        {
            statsLabel.Text += String.Format("<p>Name: {0}, HP: {1}, Max Damage: {2}, Atk Bonus: {3}<br />",
                character.Name,
                character.HP,
                character.DamageMaximum,
                character.FirstAttack.ToString());
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.HP <= 0 && opponent2.HP <= 0)
                resultLabel.Text = "Both characters have died";
            else if (opponent1.HP <= 0)
                resultLabel.Text = opponent2.Name + " defeats " + opponent1.Name;
            else if (opponent2.HP <= 0)
                resultLabel.Text = opponent1.Name + " defeats " + opponent2.Name;            
        }
    }
}