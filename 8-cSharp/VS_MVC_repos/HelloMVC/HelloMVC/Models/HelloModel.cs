using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Models
{
    public class HelloModel
    {
        public static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Id = 1, Make = "Mazda", Model = "6"},
                new Car { Id = 2, Make = "Toyota", Model = "Hachi Roku"},
                new Car { Id = 3, Make = "BMW", Model = "528i"}
            };
            return cars;
        }

        
    }

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

}