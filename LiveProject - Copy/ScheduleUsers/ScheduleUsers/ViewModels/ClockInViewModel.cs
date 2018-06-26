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
        /// The extra property to pass a different value into the javascript
        /// </summary>
        public string MyProperty { get; set; }


        // 2 Constructors for this viewmodel
        // This one takes nothing so sets ValidUser to false, and has empty string
        public ClockInViewModel()
        {
            ValidUser = false;
            Note = "";
        }

        public ClockInViewModel(ApplicationUser user, bool valid, ApplicationDbContext db, string prop)
        {
            ValidUser = valid;
            var clockEvent = db.WorkTimeEvents.Where(e => e.End == null).Where(u => u.User.Id == user.Id).FirstOrDefault();
            if (clockEvent != null) Note = clockEvent.Note;
            else Note = "";

            MyProperty = prop;
        }

        //ApplicationDbContext db = new ApplicationDbContext();

        // This constructor takes in an application user, boolean valid, and the database
        public ClockInViewModel(ApplicationUser user, bool valid, ApplicationDbContext db)
        {
            ValidUser = valid;
            var clockEvent = db.WorkTimeEvents.Where(e => e.End == null).Where(u => u.User.Id == user.Id).FirstOrDefault();
            if (clockEvent != null)
            {
                Note = clockEvent.Note;
            }
            else
            {
                Note = "";
            }   
        }
    }
}