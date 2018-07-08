using ScheduleUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ScheduleUsers.ViewModels
{
    public class WorkTimeEventViewModel
    {
        /// <summary>
        /// The Start date and day for an event in "04/10, Mon" format
        /// </summary>
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd, ddd}", ApplyFormatInEditMode = true)]
        public DateTime StartDateDay { get; set; }
        /// <summary>
        /// The Clock In time for an event
        /// </summary>
        [DisplayName("In")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// The Clock Out time for an event
        /// </summary>
        [DisplayName("Out")]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// The total time that's passed between the Clock In and Clock Out time
        /// </summary>
        [DisplayName("Hours")]
        [DisplayFormat(DataFormatString = "{0:%h}" + "h " + "{0:%m}" + "m", ApplyFormatInEditMode = true)]
        public TimeSpan Hours { get; set; }
        /// <summary>
        /// Allows user to enter a message
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Takes in the parameters to grab the date and day of when an event started, the time of the start and end, how many hours have passed between the two, and any notes that were added
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="note"></param>
        public WorkTimeEventViewModel(DateTime startTime, DateTime? endTime, string note)
        {
            StartDateDay = startTime;
            StartTime = startTime;
            if (endTime != null)
            {
                EndTime = endTime;
                Hours = endTime.Value.Subtract(startTime);
            }
            Note = note;
        }
    }

    /// <summary>
    /// View Model used on the login page for creating and updating worktimeevents
    /// </summary>
    public class WorkTimeEventCreateViewModel
    {
        public string ClockInOut { get; set; }
        public int UserVerification { get; set; }
        public string newMessagesNotification { get; set; }
 

        /// <summary>
        /// Default constructor to set UserVerification and ClockInOut
        /// </summary>
        public WorkTimeEventCreateViewModel()
        {

        }

        /// <summary>
        /// Takes an integer that corresponds with the UserCheck() on Account/Login.cshtml
        /// </summary>
        /// <param name="userVerification"></param>
        public WorkTimeEventCreateViewModel(int userVerification)
        {
            UserVerification = userVerification;
        }

        /// <summary>
        /// Takes in an integer that corresponds with the UserCheck() on Account/Login.cshtml and 
        /// Displays a list of start/end times for work time events in string format
        /// </summary>
        /// <param name="userVerification"></param>
        /// <param name="workTimeEventList"></param>
        public WorkTimeEventCreateViewModel(int userVerification, List<WorkTimeEvent> workTimeEventList, int newMessages)
        {
            UserVerification = userVerification;

            foreach (var item in workTimeEventList)
            {
                ClockInOut += item.Start.ToShortTimeString() + " - ";
                if (item.End != null)
                    ClockInOut += item.End.Value.ToShortTimeString();
                ClockInOut += "<br/>";
            }
            // checks the number of messages from WorkTimeEventController and sends the message notification
            if (newMessages > 0) 
            {
                newMessagesNotification = "You have new unread messages. Please login. </br>";
            }
        }

        /// <summary>
        /// Takes in an integer that corresponds with the UserCheck() on Account/Login.cshtml and 
        /// Displays the unfinished event's start time in string format
        /// </summary>
        /// <param name="userVerification"></param>
        /// <param name="workTimeEventList"></param>
        public WorkTimeEventCreateViewModel(int userVerification, WorkTimeEvent unfinishedEvent, int newMessages)
        {
            UserVerification = userVerification;

            // Displays just the start time of the unfinishedEvent from a previous day
            ClockInOut += unfinishedEvent.Start.ToShortTimeString();
            ClockInOut += " - " + unfinishedEvent.Start.DayOfWeek;

            // checks the number of messages from WorkTimeEventController and sends the message notification
            if (newMessages > 0)
            {
                newMessagesNotification = "You have new unread messages. Please login. </br>";
            }
        }
    }
}