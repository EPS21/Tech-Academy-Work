using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_014
{
    public partial class Default : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime myValue = DateTime.Now;

            resultLabel1.Text = myValue.ToString();
            resultLabel2.Text = myValue.ToLongDateString();
            resultLabel3.Text = myValue.ToLongTimeString();
            resultLabel4.Text = myValue.ToShortDateString();
            resultLabel5.Text = myValue.AddDays(2).ToString(); // adding two days with AddDays(2)
            resultLabel6.Text = myValue.AddMonths(-2).ToString();

            resultLabel7.Text = myValue.Month.ToString(); // gets just the month
            resultLabel8.Text = myValue.IsDaylightSavingTime().ToString(); // returns a boolean of whether we're in daylights savings
            resultLabel9.Text = myValue.DayOfWeek.ToString();
            resultLabel10.Text = myValue.DayOfYear.ToString();


            DateTime mybirthday = DateTime.Parse("11/10/1988"); // making my birthday
            DateTime myvalue2 = DateTime.Parse("05/16/2018"); // one way to make a specific date in past or future
            DateTime myvalue3 = new DateTime(1969, 12, 7, 6, 30, 0); // another way to make it

            
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            /*
            DateTime dateValue = new DateTime();
            if (dateValue == null)
            {
                resultLabel0.Text = "Please input a valid date";
            }
            else
            {
                resultLabel0.Text = dateValue.ToLongDateString();
            }
            */

            // working but no error exception
            DateTime dateValue = DateTime.Parse(TextBox1.Text);
            resultLabel0.Text = dateValue.ToLongDateString();
            


        }
    }
}