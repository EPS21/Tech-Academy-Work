using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_046
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";

            Car car1 = new Car("Honda", "Civic", 2017, "White");
            Car car2 = new Car("Toyota", "Hachi Roku", 1986, "Panda Trueno");
            Car car3 = new Car("Mazda", "Miata", 1991, "Red");

            List<Car> cars = new List<Car>();            

            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);

            // these crazy commands are Linq queries I think
            // This is a way to filter items by making a new list and filtering by a certain attribute
            //List<Car> whiteCars = cars.FindAll(p => p.Color == "White");

            // ForEach can change properties on everything without a loop
            //cars.ForEach(p => p.Year = 2000);

            if (cars.Exists(p => p.Year == 1986))
                result += "We do have a car from 1986 in stock! ";

            for (int i = 0; i < cars.Count; i++) // Lists use Count, not Length
            {
                result += cars.ElementAt(i).FormatDetailsForDisplay();
            }

            resultLabel.Text = result;
        }
    }
}