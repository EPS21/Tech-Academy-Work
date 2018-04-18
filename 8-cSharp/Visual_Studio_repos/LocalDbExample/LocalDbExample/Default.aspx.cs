using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalDbExample
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // assigning db to a new AcmeEntities database
            AcmeEntities db = new AcmeEntities();
                        
            var customers = db.Customers;

            string result = "";

            foreach (var customer in customers)
            {
                result += "<p>" + customer.Name + "</p>";
            }

            Label1.Text = result;
        }
    }
}