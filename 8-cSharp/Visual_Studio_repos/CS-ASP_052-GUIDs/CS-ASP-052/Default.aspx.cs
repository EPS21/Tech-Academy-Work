using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_052
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // http://en.wikipedia.org/wiki/Globally_unique_identifier

            var myGuid = Guid.NewGuid();
            //resultLabel.Text = myGuid.ToString();


            // 14738105-48a5-4042-8330-d09613944abd 
            // Taking this string of the previously made GUID and parsing it into another new GUID.
            Guid myOtherGuid;
            if (Guid.TryParse("14738105-48a5-4042-8330-d09613944abd", out myOtherGuid))
            {
                resultLabel.Text = myOtherGuid.ToString();
            }



        }
    }
}