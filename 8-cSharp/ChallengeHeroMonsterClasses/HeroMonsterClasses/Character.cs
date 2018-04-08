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
        public int DamageDone { get; set; }

        Random random = new Random();
        public int Attack(Dice dice)
        {
            //int damage = random.Next(1, this.DamageMaximum);
            dice.Sides = this.DamageMaximum;
            int damage = dice.Roll();
            DamageDone = damage;
            return damage;

            //return this.DamageMaximum = random.Next(1, this.DamageMaximum);            
        }

        public void Defend(int damage)
        {
            this.HP -= damage;
        }
    }
}