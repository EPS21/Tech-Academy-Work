namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; } // Primary Key
        public int CourseID { get; set; } // also a Foreign Key
        public int StudentID { get; set; } // Foreign Key
        public Grade? Grade { get; set; } // can be nullable

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}