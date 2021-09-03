using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using w1.Interface;
using w1.Models;

namespace w1.Services
{
    public class DepartmentService : IDepartmentService
    {
        private StudentDbContext db = new StudentDbContext();

       
        public string Delete(int id)
        {

            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return "Not Found!";
            }
            else
            {
                db.Entry(department).State = EntityState.Deleted;
                db.SaveChanges();
                return "Deleted Successfully!";
            }

        }

        public List<Department> GetAllList()
        {
            return db.Departments.ToList();
        }

        public Department SingleData(int id)
        {
            Department department = db.Departments.Find(id);

            return department;


        }

        public string Update(Department department)
        {
            throw new NotImplementedException();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

        }
        public string Create(Department department)
        {

            db.Departments.Add(department);
            db.SaveChanges();
            return "Save Successfully!";
        }

    }

}