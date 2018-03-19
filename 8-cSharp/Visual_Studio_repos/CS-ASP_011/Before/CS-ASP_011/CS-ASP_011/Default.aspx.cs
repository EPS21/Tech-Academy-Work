using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_011
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            /*
            resultLabel.Text = "";
            if (firstTextBox.Text == secondTextBox.Text)
            {
                resultLabel.Text = "Yes! They're equal!";
            }
            else
            {
                resultLabel.Text = "No, they're not equal";
            }
            */

            /*
            if (coolCheckBox.Checked)
            {
                resultLabel.Text = "Yes, you are so cooool";
            }
            else
            {
                resultLabel.Text = "you are a babby.";
            }
            */

            if (pizzaRadioButton.Checked)
            {
                resultLabel.Text = "You like pizza";
            }
            else if (hotdogRadioButton.Checked)
            {
                resultLabel.Text = "You like hotdogs";
            }
            else if (pbjRadioButton.Checked)
            {
                resultLabel.Text = "You like pb&j like a babby";
            }
            else
            {
                resultLabel.Text = "Please select a food";
            }

        }
    }
}