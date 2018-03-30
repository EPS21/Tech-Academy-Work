﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_035
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            // escape character \
            //resultLabel.Text = "<p style=\"color:#ee3b32;\">Hi</p>";

            string value = valueTextBox.Text;

            // Access any specific character
            //resultLabel.Text = value[2].ToString();

            // StartWith(), EndWith(), Contains()
            // Capital letters are not same as lowercase
            /*
            if (value.StartsWith("A"))
                resultLabel.Text = "Value starts with 'A'";

            if (value.EndsWith("."))
                resultLabel.Text += "<br/>Value ends with a '.'";

            if (value.Contains("sdf"))
                resultLabel.Text += "<br/>Value looks like a 'asdf'";
            */

            // IndexOf()
            int index = value.IndexOf("good");
            resultLabel.Text = "'good' begins at index " + index.ToString();

            // Insert, Remove
            //resultLabel.Text = value.Insert(index, "jolly");

            // asdfgood --> asdf
            //resultLabel.Text = value.Remove(index, value.Length - index);

            // Substring
            // "blahblahblahgood." --> good
            //resultLabel.Text = value.Substring(index, value.Length - index - 1);

            // Trim, TrimStart, TrimEnd
            // useful for comparing strings that may have spaces in their input
            //resultLabel.Text = string.Format("Length Before: {0}<br/>Length After: {1}", value.Length, value.Trim().Length);

            // PadLeft, PadRight
            // the char in PadLeft method takes "chars", you must use single quotes for these
            //resultLabel.Text = value.PadLeft(10, '*');

            // ToUpper, ToLower
            //if (valueTextBox.Text.Trim().ToUpper() == "BOB") resultLabel.Text = "The same";
            //else resultLabel.Text = "Different";

            // Replace()
            //string template = "[NAME] said it would be ok. Maybe you should take that up with [NAME]";
            //resultLabel.Text = template.Replace("[NAME]", valueTextBox.Text);

            // Split and StringBuilder, a better way to append strings 
            //string result = "";
            StringBuilder sb = new StringBuilder();
            string[] values = valueTextBox.Text.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                //result += values[i] + " " + values[i].Length + "<br/>";
                sb.Append(values[i]);
                sb.Append(" ");
                sb.Append(values[i].Length);
                sb.Append("<br />");
            }
            //resultLabel.Text = result;
            resultLabel.Text = sb.ToString();
        }
    }
}