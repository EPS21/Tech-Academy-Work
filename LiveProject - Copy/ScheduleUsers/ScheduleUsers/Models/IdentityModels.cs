using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ScheduleUsers.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        // [Required]

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
        /// Hire Date of user.
        /// </summary>
        public System.DateTime HireDate { get; set; }

        /// <summary>
        /// Department of the user.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Position of the user.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// User's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// User's hourly wage.
        /// </summary>
        public decimal HourlyPayRate { get; set; }

        /// <summary>
        /// Distinction if the user is a fulltime employee or not.
        /// </summary>
        public bool Fulltime { get; set; }


        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<TimeOffEvent> RequestedTimeOff { get; set; }
        public virtual ICollection<WorkTimeEvent> WorkEvents { get; set; }
        [InverseProperty("Sender")]
        public virtual ICollection<Message> SenderMessages { get; set; }
        [InverseProperty("Recipient")]
        public virtual ICollection<Message> RecipientMessages { get; set; }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ScheduleUsers", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }
        public DbSet<WorkTimeEvent> WorkTimeEvents { get; set; }
        public DbSet<TimeOffEvent> TimeOffEvents { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<WorkPeriod> WorkPeriods { get; set; }
    }
}