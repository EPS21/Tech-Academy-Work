
using ScheduleUsers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleUsers.Models
{
    public class Event
    {
        //Initializing Event Model with necessary information


        [Key]
        /// <summary>
        /// ID for the event
        /// </summary>
        public Guid EventID { get; set; }

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
        /// Event Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Whether or not the event is active on the schedule
        /// </summary>
        public bool ActiveSchedule { get; set; }
        /// <summary>
        /// Id of the Admin who approved this time off event
        /// </summary>
        public string ApproverId { get; set; }
        [Column("UserId")]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Message> Messages { get; set; } 
    }
}