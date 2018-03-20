using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            // http://is.gd/pagelifecycle

            // Need to check if the page is not posting back, otherwise it will 
            // reinitialize and refresh the page again when and the button won't work
            if (!Page.IsPostBack)
            {
                previousCalender.SelectedDate = DateTime.Now.Date; // need .Date to have it set in calender UI
                startDateCalender.SelectedDate = DateTime.Now.Date.AddDays(14);
                endDateCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
            }
            Page.MaintainScrollPositionOnPostBack = true; // can set this here to stop scrolling nonsese (will only be for this form)
        }

        protected void assignSpyButton_Click(object sender, EventArgs e)
        {
            DateTime datePrev = previousCalender.SelectedDate;
            DateTime startDateNew = startDateCalender.SelectedDate;
            DateTime endDateNew = DateTime.Parse(endDateCalendar.SelectedDate.ToString()); // same as previous two            

            // adding some labels next to calenders for testing purposes
            Label1.Text = datePrev.ToString();
            Label2.Text = startDateNew.ToString();
            //Label3.Text = endDateCalendar.SelectedDate.ToString();
            Label3.Text = endDateNew.ToString();




        }
    }
}