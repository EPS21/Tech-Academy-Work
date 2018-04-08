using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_043
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Car myCar = new Car(); // Car() is the default constructor method
            Car myCar = new Car("Honda", "Civic Type R", 2017, "Championship White");
            resultLabel.Text =  myCar.FormatDetailsForDisplay();

            //DateTime d = new DateTime()
        }
    }
}