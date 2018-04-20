using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityFrameworkEnums
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public enum Color
    {
        Black,
        Red,
        Silver
    }
    

    public enum ProductType
    {
        Longboard,
        Skateboard,
        Helmet
    }

}