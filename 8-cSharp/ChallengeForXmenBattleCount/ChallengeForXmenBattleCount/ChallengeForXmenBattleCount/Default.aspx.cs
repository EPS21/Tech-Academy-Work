using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeForXmenBattleCount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Wolverine fewest battles
            // Pheonix most battles

            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13 };

            string result = "";

            // Your Code Here!
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers.Max())
                {
                    result += String.Format("Most battles belong to: {0} (Value: {1})", names[i], numbers[i]);                    
                }

                if (numbers[i] == numbers.Min())
                {
                    result += String.Format("<br/>Least battles belong to: {0} (Value: {1})", names[i], numbers[i]);
                    break; // stop after we found our lowest value
                }                
            }

            resultLabel.Text = result;
            
            // another way to solve, by using logic to get largest and smallest values to set the index
            /*
            int L = 0;
            int S = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (numbers[i] > numbers[L])
                {
                    L = i;
                }

                if (numbers[i] < numbers[S])
                {
                    S = i;
                }
            }
            result = names[L] + numbers[L];
            result += "<br/>" + names[S] + numbers[S];

            resultLabel.Text = result;
            */
        }
    }
}