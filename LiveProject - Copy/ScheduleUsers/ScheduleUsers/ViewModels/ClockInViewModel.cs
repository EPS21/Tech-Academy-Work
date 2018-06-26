/**
 * This is the viewmodel for when the user clocks in or out, and in the AccountController
 * will return ones with different constructors based on which buttons were clicked in the 
 * Login.cshtml
 **/

using ScheduleUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ScheduleUsers.ViewModels
{
    public class ClockInViewModel
    {
        /// <summary>
        /// Whether the user is valid or not
        /// </summary>
        [DisplayName("Valid User")] 
        public bool ValidUser { get; set; }

        /// <summary>
        /// The note inputted when a user clocks in or out
        /// </summary>
        [DisplayName("Note")]
        public string Note { get; set; }

        /// <summary>
        /// The string property for the AccountController associated with the different buttons
        /// </summary>
        public string MyProperty { get; set; }
                
        // Default constructor that takes in nothing so sets ValidUser to false, and sets Note value to an empty string
        public ClockInViewModel()
        {
            ValidUser = false;
            Note = "";
        }

        // Constructor that takes in application user, boolean valid, and the database
        public ClockInViewModel(ApplicationUser user, bool valid, ApplicationDbContext db, string prop)
        {            
            ValidUser = valid;

            // Grabs the worktime events that have not ended, which is the matching userID inputted
            var clockEvent = db.WorkTimeEvents.Where(e => e.End == null).Where(u => u.User.Id == user.Id).FirstOrDefault();

            // If the clockEvent exists, sets the note to what user inputted
            if (clockEvent != null) Note = clockEvent.Note;
            else Note = "";
            MyProperty = prop;
        }
        
        // This constructor takes in an application user, boolean valid, and the database
        public ClockInViewModel(ApplicationUser user, bool valid, ApplicationDbContext db)
        {
            ValidUser = valid;
            var clockEvent = db.WorkTimeEvents.Where(e => e.End == null).Where(u => u.User.Id == user.Id).FirstOrDefault();
            if (clockEvent != null) Note = clockEvent.Note;
            else Note = "";   
        }
    }
}