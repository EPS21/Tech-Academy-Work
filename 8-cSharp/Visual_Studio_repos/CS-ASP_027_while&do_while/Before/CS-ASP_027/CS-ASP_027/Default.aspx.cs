using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_027
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int heroHP = 30;
            int monsterHP = 30;

            string result = "";

            // Hero gets bonus first preemptive attack 
            monsterHP -= random.Next(1, 10);

            int round = 0;
            result += "<br />Round: " + round;
            result += String.Format("<br />Hero attacks first, leaving monster with {0} health.", 
                monsterHP);

            /* 
                * x = 0;
                * y = array[x++]; // This will get array[0]
                * 
                * x = 0;
                * y = array[++x]; // This will get array[1]
                *
                */
            // Need battle logic here!
            /*
            while (heroHP > 0 && monsterHP > 0)
            {
                int heroDamage = random.Next(1, 10);
                int monsterDamage = random.Next(1, 15);

                monsterHP -= heroDamage;
                heroHP -= monsterDamage;

                result += "<br/>Round: " + ++round; // ++round increments before round, round++ increments after      
                result += String.Format("<br/>Hero causes {0} damage, leaving monster with {1} health.", heroDamage, monsterHP);
                result += String.Format("<br/>Monster causes {0} damage, leaving hero with {1} health.", monsterDamage, heroHP);
            }
            */



            do // do will make sure this executes at least once
            {
                int heroDamage = random.Next(5, 10);
                int monsterDamage = random.Next(5, 20);

                result += "<br/>Round: " + ++round + " (Hero HP: " + heroHP + " MonsterHP: " + monsterHP + ")";

                if (heroHP > 0)
                {
                    monsterHP -= heroDamage;
                    result += String.Format("<br/>Hero causes {0} damage, leaving monster with {1} health.", heroDamage, monsterHP);
                }

                if (monsterHP > 0)
                {
                    heroHP -= monsterDamage;
                    result += String.Format("<br/>Monster causes {0} damage, leaving hero with {1} health.", monsterDamage, heroHP);
                }               
                            

            } while (heroHP > 0 && monsterHP > 0);

            if (heroHP > 0)
            {
                result += "<br />Hero wins! ";                
            }
            else
            {
                result += "<br /> Monster wins! ";                
            }

            resultLabel.Text = result + "Hero HP: " + heroHP + " MonsterHP: " + monsterHP;
            //Label1.Text = random.ToString();
        }
    }
}