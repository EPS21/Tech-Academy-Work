using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_023
{
    public partial class Default : System.Web.UI.Page
    {
        // initialize hours array of doubles, in outside scope
        double[] hours;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hours = new double[0];
                ViewState.Add("Hours", hours); // initialize the viewstate memory location of "Hours"
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            // pulling out of memory "Hours" and casting as double[]
            hours = (double[])ViewState["Hours"]; 

            // needs to reference the array, then resizes it
            Array.Resize(ref hours, hours.Length + 1);

            // stores the highest indexed value of the array into newestItem
            int newestItem = hours.GetUpperBound(0);

            // gets the index of latest item in hours array, and puts it in the hoursTextBox (after its parsed as a double)
            hours[newestItem] = double.Parse(hoursTextBox.Text);

            // place back into hours
            ViewState["Hours"] = hours;

            System.Threading.Thread.Sleep(100);
            

            resultLabel.Text = String.Format("Total hours: {0}<br />Most Hours: {1}<br />Least Hours: {2}<br />Average Hours: {3:N2}<br />Index Size: {4}", // Nx gets decimal to x amount of places 
                hours.Sum(),
                hours.Max(),
                hours.Min(),
                hours.Average(),
                hours.Length);
                
            
        }
    }
}