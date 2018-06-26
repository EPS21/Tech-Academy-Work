using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ScheduleUsers.Models;

namespace ScheduleUsers.ViewModels
{
    public class TimeOffViewModel 
    {

        /// <summary>
        /// ID for the event
        /// </summary>
        [Key]
        public Guid EventID { get; set; }

        /// <summary>
        /// First name of user.
        /// </summary>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Required]
        /// <summary>
        /// Last name of user.
        /// </summary>
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Start time for the events
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        
        /// <summary>
        /// End time for the events
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? End { get; set; }

        /// <summary>
        ///Note for the event
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// The Length of the time off event
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public string RequestLengthString { get; set; }


        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Whether or not the event is active on the schedule
        /// </summary>
        [Display(Name = "Active")]
        public bool ActiveSchedule { get; set; }

        /// <summary>
        /// DateTime that displays date and time the time off event was requested.
        /// </summary>
        public DateTime? Submitted { get; set; }

        //Compute the property RequestLength.
        public TimeOffViewModel(TimeOffEvent timeOffEvent)
        {
                this.EventID = timeOffEvent.EventID;

                this.FirstName = timeOffEvent.User.FirstName;
                this.LastName = timeOffEvent.User.LastName;

                this.Start = timeOffEvent.Start;
                this.End = timeOffEvent.End;

                this.RequestLengthString = (End - Start).ToString();
  
                this.Note = timeOffEvent.Note;

                this.User = timeOffEvent.User;

                this.Submitted = timeOffEvent.Submitted;

                this.ActiveSchedule = timeOffEvent.ActiveSchedule;
        }   
    }
}