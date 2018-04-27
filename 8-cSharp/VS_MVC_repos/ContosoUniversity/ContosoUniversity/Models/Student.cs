﻿using System;
using System.Collections.Generic;

namespace ContosoUniversity.Models
{
    public class Student
    {
        // ID is primary key
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string EmailAddress { get; set; }

        // for navigation properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}