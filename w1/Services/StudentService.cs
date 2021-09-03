using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using w1.Interface;
using w1.Models;

namespace w1.Services
{
    public class StudentService : IStudentService
    {
        private StudentDbContext db = new StudentDbContext();

        public string Create(Student Student)
        {

            db.Students.Add(Student);
            db.SaveChanges();
            return "Save Successfully!";
        }

        public string Delete(int id)
        {

            Student Student = db.Students.Find(id);
            if (Student == null)
            {
                return "Not Found!";
            }
            else
            {
                db.Entry(Student).State = EntityState.Deleted;
                db.SaveChanges();
                return "Deleted Successfully!";
            }

        }

        public List<Student> GetAllList()
        {
            return db.Students.ToList();
        }

        public Student SingleData(int id)
        {
            Student Student = db.Students.Find(id);

            return Student;


        }

        public string Update(Student Student)
        {
            db.Entry(Student).State = EntityState.Modified;
            return "Update Successfully!";
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

        }
    }

}