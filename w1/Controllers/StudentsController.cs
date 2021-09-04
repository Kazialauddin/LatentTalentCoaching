using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using w1.Interface;
using w1.Models;
using w1.Services;

namespace w1.Controllers
{
    
    public class StudentsController : ApiController
    {
        private  IStudentService _stu =null;
       // private readonly IDepartmentService _dep;

      public StudentsController()
        {
            _stu = new StudentService();
        }


        // GET: api/Students
        public IQueryable<Student> GetStudents()
        {
          
        return _stu.GetIQueryableList();
            
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = _stu.SingleData(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

          

            try
            {
                dynamic msg= _stu.Update(student);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dynamic msg= _stu.Create(student);

            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            dynamic msg = _stu.Delete(id);
            

       

            return Ok(msg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _stu.Dispose(disposing);

            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return _stu.GetAllList().Count(x=>x.StudentId==id) > 0;
        }
    }
}