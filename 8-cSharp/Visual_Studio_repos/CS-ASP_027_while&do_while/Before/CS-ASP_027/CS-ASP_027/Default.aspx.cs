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
            monsterHP -= random.Next(1, 30);

            int round = 0;
            result += "<br />Round: " + round;
            result += String.Format("<br />Hero attacks first, leaving monster with {0} health.", 
                monsterHP);


            // Need battle logic here!
            /*
            while (heroHP > 0 && monsterHP > 0)
            {
                int heroDamage = random.Next(1, 10);
                int monsterDamage = random.Next(1, 15);

                monsterHP -= heroDamage;
                heroHP -= monsterDamage;

                result += "<br/>Round: " + ++round; // ++round versus round++?
                result += String.Format("<br/>Hero causes {0} damage, leaving monster with {1} health.", heroDamage, monsterHP);
                result += String.Format("<br/>Monster causes {0} damage, leaving hero with {1} health.", monsterDamage, heroHP);
            }
            */



            do
            {
                int heroDamage = random.Next(1, 10);
                int monsterDamage = random.Next(1, 15);

                monsterHP -= heroDamage;
                heroHP -= monsterDamage;

                result += "<br/>Round: " + ++round; // ++round versus round++?
                result += String.Format("<br/>Hero causes {0} damage, leaving monster with {1} health.", heroDamage, monsterHP);
                result += String.Format("<br/>Monster causes {0} damage, leaving hero with {1} health.", monsterDamage, heroHP);
            } while (heroHP > 0 && monsterHP > 0);




            if (heroHP > 0)
            {
                result += "<br />Hero wins!";
            }
            else
            {
                result += "<br /> Monster wins!";
            }


            resultLabel.Text = result;
            //Label1.Text = random.ToString();
        }
    }
}