using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentProject1.Models
{
    public class StudentProject1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StudentProject1Context() : base("name=StudentProject1Context")
        {
        }

        public System.Data.Entity.DbSet<StudentProject1.Enrollment> Enrollments { get; set; }

        public System.Data.Entity.DbSet<StudentProject1.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<StudentProject1.Student> Students { get; set; }
    }
}
