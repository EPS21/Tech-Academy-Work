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

        protected void Page_Load(object sender, EventArgs e)
        {
            // Making the hero character
            Character hero = new Character();
            hero.Name = "Hero-sama";
            hero.HP = 20;
            hero.DamageMaximum = 10;
            hero.FirstAttack = true;            

            // Making the monster character
            Character monster = new Character();
            monster.Name = "Tentacle monster";
            monster.HP = 30;
            monster.DamageMaximum = 7;
            monster.FirstAttack = false;

            // Making a dice with sides of max damage
            Dice dice = new Dice();

            // doing first attack bonus
            /*
            if (hero.FirstAttack)
            {
                monster.Defend(hero.Attack(dice));
                displayCharacterStats(hero);
                displayCharacterStats(monster);
            }                
            else if (monster.FirstAttack) // this never runs as hero has first attack hard coded as true?
            {
                hero.Defend(monster.Attack(dice));
                displayCharacterStats(hero);
                displayCharacterStats(monster);
            }
            */
            displayCharacterStats(hero);
            displayCharacterStats(monster);

            while (monster.HP > 0 && hero.HP > 0)
            {
                monster.Defend(hero.Attack(dice)); // Attack phase 1 (hero goes first) 
                displayCharacterStats(hero);
                statsLabel.Text += String.Format("{0} has dealt {1} points of damage to {2}!", hero.Name, hero.DamageDone, monster.Name);

                hero.Defend(monster.Attack(dice)); // Attack phase 2 (monster goes)                
                displayCharacterStats(monster);
                statsLabel.Text += String.Format("{0} has dealt {1} points of damage to {2}!", monster.Name, monster.DamageDone, hero.Name);
            }

            displayResult(hero, monster);
            
            //resultLabel.Text = hero.Name + " attacks! " + monster.Name + "'s health is at " + monster.HP + " HP";
            //resultLabel.Text += "<br/>" + monster.Name + " attacks! " + hero.Name + "'s health is at " + hero.HP + " HP";
        }

        public void displayCharacterStats(Character character) // Cannot be public?? less accessible or something
        {
            statsLabel.Text += String.Format("<p>Name: {0}, HP: {1}, Max Damage: {2}, Atk Bonus: {3}<br />",
                character.Name,
                character.HP,
                character.DamageMaximum,
                character.FirstAttack.ToString());

            //statsLabel.Text += "<br/>" + character + "has "
            
        }

        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.HP <= 0)
            {
                resultLabel.Text = opponent2.Name + " defeats " + opponent1.Name;
            }
            else if (opponent2.HP <= 0)
            {
                resultLabel.Text = opponent1.Name + " defeats " + opponent2.Name;
            }
            else
            {
                resultLabel.Text = "Both characters have died";
            }
        }

    }
}