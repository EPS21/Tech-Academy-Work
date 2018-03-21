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
            // Business Rule 1

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
            // declaring variables
            DateTime datePrev = previousCalender.SelectedDate;
            DateTime startDateNew = startDateCalender.SelectedDate;
            DateTime endDateNew = endDateCalendar.SelectedDate; //DateTime.Parse(endDateCalendar.SelectedDate.ToString()); // same as previous two? 

            TimeSpan daysBetweenAssignment = startDateNew.Subtract(datePrev);
            TimeSpan assignmentLength = endDateNew.Subtract(startDateNew);

            double spyCost = 500 * assignmentLength.Days; // Business Rule 3
            if (assignmentLength.Days > 21) spyCost += 1000; // Business Rule 4

            // adding some labels next to calenders for testing purposes
            /*
            Label1.Text = datePrev.ToString();
            Label2.Text = startDateNew.ToString();
            Label3.Text = endDateNew.ToString();
            */           

            // Business Rule 2
            if (daysBetweenAssignment.Days < 14)
            {
                resultLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment.";
                // doesnt work
                startDateNew = datePrev.AddDays(14).Date; // won't revert date on calender
                startDateCalender.VisibleDate = startDateNew;
                startDateCalender.SelectedDate = startDateNew;

                //startDateCalender.SelectedDate = previousCalender.SelectedDate.AddDays(14).Date; // why won't my declared variables above work here?
                // seems .Date can be appended anywhere after SelectedDate
            } else if (assignmentLength.Days <= 0)
            {
                resultLabel.Text = "Error: End date of assignment cannot be on or before it's start date";
                endDateNew = startDateNew.AddDays(1).Date;
                endDateCalendar.VisibleDate = endDateNew;
                endDateCalendar.SelectedDate = endDateNew;
            }
            else
            {               
                resultLabel.Text = String.Format("Assignment of {0} to assignment {1} is authorized. Budget total: {2:C}",                    
                    spyCodeNameBox.Text,
                    assignmentNameBox.Text,
                    spyCost);
            }           
        }
    }
}
