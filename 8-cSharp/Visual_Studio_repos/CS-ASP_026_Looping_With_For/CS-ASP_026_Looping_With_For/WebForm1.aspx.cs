using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_026_Looping_With_For
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";
            
            /*
            for (int i = 1; i <= 10; i+=3)
            {
                result += "<br/>" + i.ToString();
            }
            resultLabel.Text = result;
            */

            
            // Printing out an array, that has had some sort methods on it
            string[] names = new string[] { "Wolverine", "Cyclops", "Professor X", "Phoenix" };
            
            Array.Sort(names); // sorts the names in alphabetical order
            Array.Reverse(names); // then reverse the order

            for (int i = 0; i < names.Length; i++)
            {
                result += "<br/>" + names[i];
            }
            resultLabel.Text = result;
            

            // breaking out of a for before it reaches the end
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == "Professor X")
                {
                    result = String.Format("{0} is at index {1} in the list.", names[i], i);
                    break; // the break statement will exit out of the loop once it found the condition and printed it out
                           // therefore, not having to iterate through the entire thing 
                }
            }

            resultLabel.Text = result;


        }
    }
}