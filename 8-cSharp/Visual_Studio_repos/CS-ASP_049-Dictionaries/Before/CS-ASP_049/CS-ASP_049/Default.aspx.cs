using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_049
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";

            // The dictionary is like a list but you can add a primary key thing to it, such as
            // a cars VIN is a good canditate key so we use that as a string

            /*
            Dictionary<string, Car> cars = new Dictionary<string, Car>();
            cars.Add("V1", new Car { Make = "Toyota", Color = "Red", Model = "MR2", Year = 1988, Engine = "4AGE" });
            cars.Add("V2", new Car { Make = "Mazda", Color = "Orange", Model = "787b", Year = 1991, Engine = "Super Rotary Kyoudai" });
            */

            
            Dictionary<string, Car> cars = new Dictionary<string, Car>()
            {
                { "V1", new Car { Make = "Toyota", Color = "Red", Model = "MR2", Year = 1988, Engine = "4AGE" } },
                { "V2", new Car { Make = "Mazda", Color = "Orange", Model = "787b", Year = 1991, Engine = "Super Rotary Kyoudai" } }
            };

            // How to remove an item in dictionary
            if (cars.Remove("V1"))
                result += "Successfully removed V1<br/>";

            for (int i = 0; i < cars.Count; i++)
            {
                result += "<h2>" + cars.ElementAt(i).Key + "</h2>" 
                    + cars.ElementAt(i).Value.FormatDetailsForDisplay();
            }
            

            /*
            Car v2;
            // If it finds V2, output it into this new car of v2
            if (cars.TryGetValue("V2", out v2)) 
                result += v2.FormatDetailsForDisplay();
            */

            resultLabel.Text = result;
        }
    }
}