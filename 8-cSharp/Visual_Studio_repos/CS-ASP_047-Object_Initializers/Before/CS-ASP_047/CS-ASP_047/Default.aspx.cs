using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_047
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";

            /*
            Car car1 = new Car("BMW", "528i", 2010, "Black");
            Car car2 = new Car("BMW", "745li", 2005, "Black");
            Car car3 = new Car("Ford", "Escape", 2008, "White");
            */

            // How to add cars in a list with less lines (and no seperate car objects)
            // This is 'Object Initialization'
            /*
            List<Car> cars = new List<Car>();
            cars.Add(new Car { Make = "BMW", Model = "528i", Color = "Black", Year = 2010 });
            cars.Add(new Car { Make = "BMW", Model = "745li", Year = 2005, Color = "Black" });
            cars.Add(new Car { Make = "Ford", Model = "Escape", Year = 2008, Color = "White" });
            cars.Add(new Car { Make = "Mazda", Model = "6s", Color = "Silver", Year = 2004 });

            for (int i = 0; i < cars.Count; i++)
            {
                result += cars.ElementAt(i).FormatDetailsForDisplay();
            }
            */

            // Collection initializer, this way don't need to do cars.Add everytime
            // Something about a valid state?

            var cars = new List<Car>() // same as below but its implicit
            //List<Car> cars = new List<Car>()
            {
                new Car { Make = "BMW", Model = "528i", Color = "Black", Year = 2010 },
                new Car { Make = "BMW", Model = "745li", Year = 2005, Color = "Black" },
                new Car { Make = "Ford", Model = "Escape", Year = 2008, Color = "White" },
                new Car { Make = "Mazda", Model = "6s", Color = "Silver", Year = 2004 }
            };

            /*
            for (int i = 0; i < cars.Count; i++)
            {
                result += cars.ElementAt(i).FormatDetailsForDisplay();
            }
            */
            string jName = "Baruteku";
            var Name = "Baltek";
            // Video 50 and 51  
            // Same as for loop above but more elegent
            foreach (Car car in cars)
            {
                result += car.FormatDetailsForDisplay();
            }

            /*
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            */

            // Do stuff

            resultLabel.Text = result;
        }
    }
}