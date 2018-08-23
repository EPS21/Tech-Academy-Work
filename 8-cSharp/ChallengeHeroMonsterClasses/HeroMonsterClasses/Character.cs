using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroMonsterClasses
{
    public class Character
    {
        public string Name { get; set; } // prop tab tab
        public int HP { get; set; }
        public int DamageMaximum { get; set; }
        public bool FirstAttack { get; set; }        

        Random random = new Random();
        public int Attack(Dice dice)
        {            
            dice.Sides = this.DamageMaximum;            
            return dice.Roll();
        }

        public void Defend(int damage)
        {
            this.HP -= damage;
        }
    }
}