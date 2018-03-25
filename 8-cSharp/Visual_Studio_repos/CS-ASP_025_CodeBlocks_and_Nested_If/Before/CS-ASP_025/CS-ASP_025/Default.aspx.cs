using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_025
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            /*
            if (firstCheckBox.Checked)
            {
                if (secondCheckBox.Checked)
                {
                    if (thirdCheckBox.Checked)
                    {
                        resultLabel.Text = "They're all checked!";
                    }
                }
            }
            */

            if (firstCheckBox.Checked || secondCheckBox.Checked || thirdCheckBox.Checked)
            {
                resultLabel.Text = "One of three checked!";
                if (firstCheckBox.Checked && secondCheckBox.Checked ||
                     firstCheckBox.Checked && thirdCheckBox.Checked ||
                     secondCheckBox.Checked && thirdCheckBox.Checked)
                {
                    resultLabel.Text = "Two of three checked!";
                }
                if (firstCheckBox.Checked && secondCheckBox.Checked && thirdCheckBox.Checked)
                {
                    resultLabel.Text = "All three checked!";
                }
            }
            
            
            
        }
    }
}