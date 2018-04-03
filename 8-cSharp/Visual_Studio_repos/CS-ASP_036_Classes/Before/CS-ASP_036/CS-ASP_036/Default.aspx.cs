using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS_ASP_036
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Car myNewCar = new Car(); // This is an object; an instance of the Car class

            myNewCar.Make = "Toyota";
            myNewCar.Model = "Hachi Roku";
            myNewCar.Year = 1986;
            myNewCar.Color = "Panda White";

            //double myMarketValueOfCar = determinteMarketValue(myNewCar); // Calling with helper method outside of class Car
            double myMarketValueOfCar = myNewCar.DeterminteMarketValue(); // Calling with helper method from inside of class Car

            resultLabel.Text = String.Format("{0} - {1} - {2} - {3} - {4:C}",
                myNewCar.Make,
                myNewCar.Model,
                myNewCar.Year.ToString(),
                myNewCar.Color,
                myMarketValueOfCar);
        }

        /*
        private double DeterminteMarketValue(Car car)
        {
            //double carValue = 100.0;
            //double driftTax = 5000;
            // Someday write code to go online and look up the car's value from KBB
            // retrieve its value in the carValue variable.

            double carValue;

            if (car.Year > 2010)
                carValue = 10000.0;
            else if (car.Year > 2000)
                carValue = 3000.0;
            else
                carValue = 2000.0;

            return carValue;
        }
        */

    }

    class Car // This is a class
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        // A helper method can be put inside a class, with some tweaks
        // See above snippet for changes
        public double DeterminteMarketValue() 

        {
            //double carValue = 100.0;
            //double driftTax = 5000;
            // Someday write code to go online and look up the car's value from KBB
            // retrieve its value in the carValue variable.

            double carValue;

            if (this.Year > 2010)
                carValue = 10000.0;
            else if (this.Year > 2000)
                carValue = 3000.0;
            else
                carValue = 2000.0;

            return carValue;
        }

    }

}