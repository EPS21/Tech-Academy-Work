using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringExample
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Strings vs StringBuilder
            // sb is more memory efficient way of appending string data

            string result = "";
            string result2 = " and text line 3";
            StringBuilder sb = new StringBuilder();

            // Has to set result twice with result2
            result = "Text line 1";
            result += " and text line 2";

            // Only sets result once in memory and appends second string 
            // without having to set result again (more memory efficient)
            sb.Append(result);
            sb.Append(result2);

            resultLabel.Text = result;

            sbLabel.Text = sb.ToString();


        }
    }
}