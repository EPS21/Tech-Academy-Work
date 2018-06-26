using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleUsers.Models
{
    public class PayPeriod
    {
        [Key]
        public int PayPeriodID { get; set; }
        /// <summary>
        /// Pay period days
        /// </summary>
        public int Days { get; set; }
        /// <summary>
        /// Days left in pay period until paid
        /// </summary>
        public int DaysUntilPay { get; set; }
        /// <summary>
        /// Pay period start date
        /// </summary>
        public DateTime StartDate { get; set; }

    }
}