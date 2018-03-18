using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeConditionalRadioButton
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            
            resultLabel.Text = "";
            if (pencilRadioButton.Checked)
            {
                Image.ImageUrl = "pencil.png";
            }
            else if (penRadioButton.Checked)
            {
                Image.ImageUrl = "pen.png";
            }
            else if (phoneRadioButton.Checked)
            {
                Image.ImageUrl = "~/phone.png";
            }
            else if (tabletRadioButton.Checked)
            {
                Image.ImageUrl = "~/tablet.png";
            }
            else
            {
                resultLabel.Text = "Please select an option";
            }
            

            /*
            resultLabel.Text = "";
            Image.ImageUrl = (pencilRadioButton.Checked) ? "~/pencil.png" : null;
            Image.ImageUrl = (penRadioButton.Checked) ? "~/pen.png" : null;
            Image.ImageUrl = (phoneRadioButton.Checked) ? "~/phone.png" : null;
            Image.ImageUrl = (tabletRadioButton.Checked) ? "~/tablet.png" : null;
            //resultLabel.Text = (pencilRadioButton.Checked == false) ? "Please select an option" : null;
            */
        }
    }
}