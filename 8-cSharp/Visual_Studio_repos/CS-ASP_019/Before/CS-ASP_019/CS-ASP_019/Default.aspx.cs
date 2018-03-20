using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_019
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            //string result = String.Format("Thank you, {0}, for your business", nameTextBox.Text);
            // same way to do above
            string result2 = "Thank you, " + nameTextBox.Text + ", for your business";
            int ss = int.Parse(ssTextBox.Text);
            long phone = long.Parse(phoneTextBox.Text);
            DateTime today = DateTime.Now;
            double salary = double.Parse(salaryTextBox.Text);

            /*
            string result = String.Format("Thank you, {0}, for your business. " +
                "<br/>Your SSN for all to see is: {1:000-00-0000}" +
                "<br/>Phone: {2:(000) 000-0000}" +
                "<br/>Loan Date: {3: dddd, MM/dd/yyyyy (zzz) gg}", // more custom date formatting info here http://is.gd/formattingdates
                nameTextBox.Text, 
                ss, 
                phone,
                loanDateCalendar.SelectedDate);

            resultLabel.Text = result;
            */

            string result = String.Format("Thank you, {0}, for your business. " +
                "<br/>Your SSN for all to see is: {1:000-00-0000}" +
                "<br/>Phone: {2:(000) 000-0000}" +
                // more custom date formatting info here http://is.gd/formattingdates
                "<br/>Loan Date: {3:dddd, MM/dd/yyyyy (zzz) gg}" + 
                // C is for system's currency more info http://is.gd/formattingcurrency/
                "<br/>Salary: {4:C}", 
                nameTextBox.Text,
                ss,
                phone,
                loanDateCalendar.SelectedDate,
                salary);
                

            resultLabel.Text = result;
        }
    }
}