using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_015
{
    public partial class Default : System.Web.UI.Page
    {
        DateTime myBirthday = DateTime.Parse("11/10/1988");

        protected void Page_Load(object sender, EventArgs e)
        {
            myAgeLabel.Text = "The date being used is: " + myBirthday.ToString();
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            // http://is.gd/timespan
            // Days.Hours:Minutes:Seconds.Milliseconds

            TimeSpan myTimeSpan = TimeSpan.Parse("1.2:3:30.5"); // 1 day, 2 hours, 3 minutes, 30 seconds, 500 miliseconds            

            // initializing new TimeSpan object myAge as with the time now, subtracted by my birthday
            // for example "3/18/2018" minus "11/10/1988"
            
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);

            resultLabelYears.Text = "Age in Years: " + (DateTime.Now.Year - myBirthday.Year).ToString();
            resultLabelDays.Text = "Age in Days: " + myAge.TotalDays.ToString();
            resultLabelHours.Text = "Age in Hours: " + myAge.TotalHours.ToString();
            resultLabelMinutes.Text = "Age in Minutes: " + myAge.TotalMinutes.ToString();
            resultLabelSeconds.Text = "Age in Seconds: " + myAge.TotalSeconds.ToString();
        }
    }
}