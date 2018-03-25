using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_021
{
    public partial class Default : System.Web.UI.Page
    {
        // initialize array up here dawg
        string[] values;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)        {
            
            values = new string[5]; // initializing a string array when addButton_Click event
            values[0] = TextBox1.Text;
            values[1] = TextBox2.Text;
            values[2] = TextBox3.Text;
            values[3] = TextBox4.Text;
            values[4] = TextBox5.Text;            

            //resultLabel.Text = values[2];
            //resultLabel.Text = values.Length.ToString();

            
            //string[] values = new string[5] { "bob", "steve", "chuck", "brian", "andy" };
            //values[5] = "Andrew";
            ViewState.Add("MyValues", values); // this is the way to store the array 'values' in the webpage
            resultLabel.Text = "Values added...";
            TextBox1.Text = ""; TextBox2.Text = ""; TextBox3.Text = ""; TextBox4.Text = ""; TextBox5.Text = "";
        }

        protected void retrieveButton_Click(object sender, EventArgs e)
        {
            values = (string[])ViewState["MyValues"];
            
            TextBox1.Text = values[0];
            TextBox2.Text = values[1];
            TextBox3.Text = values[2];
            TextBox4.Text = values[3];
            TextBox5.Text = values[4];            

            // A loop that prints the values of the textboxes sequentially
            resultLabel.Text = "Values retrieved ";
            for (int i = 0; i <= values.Length - 1; i++)
            {
                resultLabel.Text += values[i] + " ";
            }

        }
    }
}