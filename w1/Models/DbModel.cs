using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace w1.Models
{
    public class Department
    {
        public Department()
        {
            this.Students = new List<Student>();
        }
        public int DepartmentId { get; set; }
        [Required, StringLength(40)]
        public string DepartmentName { get; set; }
        //navigation
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Student> Students { get; set; }
    }
    public class Student
    {
        public int StudentId { get; set; }
        [Required, StringLength(40)]
        public string StudentName { get; set; }

        public decimal E1 { get; set; }
        public decimal E2 { get; set; }
        public decimal E3 { get; set; }
        public decimal WrittenExam { get; set; }



        //FK
        [Required, ForeignKey("Department")]
        public int DepartmentId { get; set; }
        //navigation
        [Newtonsoft.Json.JsonIgnore]
        public virtual Department Department { get; set; }

    }
    public class Suggestion
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Discript1 { get; set; }
        public string Discript2 { get; set; }
    }
    public class StudentDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public StudentDbContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
    }
    public class DbInitializer : DropCreateDatabaseIfModelChanges<StudentDbContext>
    {
        protected override void Seed(StudentDbContext db)
        {
            Department d1 = new Department { DepartmentName = "Class10" };
            d1.Students.Add(new Student { StudentName = "S1", E1 = 70, E2 = 80, E3 = 90, WrittenExam = 50, DepartmentId = 1 });
            db.Departments.Add(d1);
            Department d2 = new Department { DepartmentName = "Class09" };
            d2.Students.Add(new Student { StudentName = "S1", E1 = 70, E2 = 80, E3 = 90, WrittenExam = 50, DepartmentId = 1 });
            db.Departments.Add(d2);
            Department d3 = new Department { DepartmentName = "Class08" };
            d1.Students.Add(new Student { StudentName = "S1", E1 = 70, E2 = 80, E3 = 90, WrittenExam = 50, DepartmentId = 1 });
            db.Departments.Add(d3);
            db.SaveChanges();
            base.Seed(db);
        }
    }

}