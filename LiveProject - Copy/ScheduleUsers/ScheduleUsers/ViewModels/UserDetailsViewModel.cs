using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleUsers.ViewModels
{
    public class UserDetailsViewModel
    {
        /// <summary>
        /// First name of user.
        /// </summary>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of user.
        /// </summary>
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// User's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Hire Date of user.
        /// </summary>
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public string HireDate { get; set; }

        /// <summary>
        /// Department of the user.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Position of the user.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// User's hourly wage.
        /// </summary>
        public decimal HourlyPayRate { get; set; }

        /// <summary>
        /// Distinction if the user is a fulltime employee or not.
        /// </summary>
        public bool Fulltime { get; set; }

        /// <summary>
        /// Implements user details
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="hireDate"></param>
        /// <param name="department"></param>
        /// <param name="position"></param>
        /// <param name="hourlyPayRay"></param>
        /// <param name="fullTime"></param>
        public UserDetailsViewModel(string firstName, string lastName, string address, string hireDate, string department, string position, decimal hourlyPayRay, bool fullTime)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            HireDate = hireDate;
            Department = department;
            Position = position;
            HourlyPayRate = hourlyPayRay;
            Fulltime = fullTime;
        }
        
        /// <summary>
        /// Message Count
        /// </summary>
        public bool messages { get; set; }
       
    }
}