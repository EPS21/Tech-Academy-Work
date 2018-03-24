using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_020
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState.Add("MyValue", ""); // viewstate is to encode values in a webpage, and pull them up again when page is loaded.
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string value = ViewState["MyValue"].ToString();
            value += valueTextBox.Text + " ";
            ViewState["MyValue"] = value;
            resultLabel.Text = value;

            //valueTextBox.Text = "";
        }
    }
}