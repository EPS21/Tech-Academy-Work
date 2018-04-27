using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // this lets you enter primary key for course (instead of DB generating it)
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        // navigation property
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}