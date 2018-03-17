using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeSimpleCalculator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = 3;
            double y = 3.14;
            int asdf = x * (int)y;
        }
        
        protected void plusButton_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(TextBox1.Text);
            double num2 = double.Parse(TextBox2.Text);

            double result = num1 + num2;
            resultLabel.Text = result.ToString();
        }

        protected void minusButton_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(TextBox1.Text);
            double num2 = double.Parse(TextBox2.Text);

            double result = num1 - num2;
            resultLabel.Text = result.ToString();
        }

        protected void multiplyButton_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(TextBox1.Text);
            double num2 = double.Parse(TextBox2.Text);

            double result = num1 * num2;
            resultLabel.Text = result.ToString();
        }

        protected void divideButton_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(TextBox1.Text);
            double num2 = double.Parse(TextBox2.Text);

            double result = num1 / num2;
            resultLabel.Text = result.ToString();
        }
    }
}