using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeDaysBetweenDates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            DateTime fromCal1 = Calendar1.SelectedDate;
            DateTime fromCal2 = Calendar2.SelectedDate;
            // Calendar1.SelectedDate.Subtract(Calendar2.SelectedDate).TotalDays.ToString();

            if (fromCal2 > fromCal1)
            {
                TimeSpan result = fromCal2.Subtract(fromCal1);
                resultLabel.Text = result.TotalDays.ToString();

                /* I tried using TotalDays instead of just Days to see if I wouldn't
                 * need the last else if statement, but guess not. In this case, how I
                 * set it up, result.TotalDays.ToString() and result.Days.ToString()
                 * do the same thing, because the Subtract method already did the totaling.
                 */
            }
            else if (fromCal1 > fromCal2)
            {
                TimeSpan result = fromCal1.Subtract(fromCal2);
                resultLabel.Text = result.Days.ToString();

                //resultLabel.Text = (fromCal1.Day - fromCal2.Day).ToString();
            }
            else if (fromCal1 == fromCal2)
            {
                resultLabel.Text = "0";
            }

        }
    }
}