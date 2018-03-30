using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            // 1.  Reverse your name
            string name = "Eric Sheng";
            // In my case, the result would be:
            // robaT boB
            StringBuilder sb = new StringBuilder();            
            for (int i = name.Length - 1; i >= 0; i--)
            {
                sb.Append(name[i]);
            }
            ansLabel1.Text = sb.ToString();  // Complete!
            
                        
            // 2.  Reverse this sequence:
            string names = "Luke,Leia,Han,Chewbacca";
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke

            //split names into an array            
            string[] values = names.Split(',');            
            string result = "";
            for (int i = values.Length - 1; i >= 0; i--)
            {
                result += values[i] + ",";                
            }
            result = result.Remove(result.Length - 1, 1); // get rid of the last comma
            ansLabel2.Text = result; // Complete!
                        
                        
            // 3. Use the sequence to create ascii art:
            // *****luke*****
            // *****leia*****
            // *****han******
            // **Chewbacca***

            //format each value of names[i] with asterisks
            //string[] values = names.Split(',');
            string result2 = "";

            for (int i = 0; i < values.Length; i++)
            {
                string paddedString = values[i].PadLeft((values[i].Length + ((14 - values[i].Length) / 2)), '*').PadRight(14, '*');
                result2 += paddedString + "<br/>";
            }
            ansLabel3.Text = result2; // Complete!

            //resultLabel.Text = testName.PadLeft(testName.Length + ((14 - testName.Length) / 2), '*').PadRight(14, '*');
            //resultLabel.Text = testname.PadLeft(9, '*').PadRight(14, '*'); // returns *****luke*****
            


            // 4. Solve this puzzle:
            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";
            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.
            /*
            puzzle = puzzle.Replace('Z', 'T');
            puzzle = puzzle.ToLower();
            puzzle = puzzle.Remove(9, 9);
            puzzle = puzzle.Remove(0, 1);
            puzzle = puzzle.Insert(0, "N");
            */

            // get this all a one liner
            ansLabel4.Text = puzzle.Replace('Z', 'T').ToLower().Remove(9, 9).Remove(0, 1).Insert(0, "N");
            

        }
    }
}