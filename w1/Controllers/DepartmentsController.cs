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
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentService _dep ;
        //private StudentDbContext db = new StudentDbContext();

        // private readonly IStudentService _stu;

        public DepartmentsController()
        {
            _dep = new DepartmentService();
        }
        // GET: api/Departments
        public IQueryable<Department> GetDepartments()
        {
            
            return _dep.GetIQueryableList();
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(int id)
        {
            Department department = _dep.SingleData(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartment(int id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

           

            try
            {
                _dep.Update(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        [ResponseType(typeof(Department))]
        public IHttpActionResult PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dynamic msg= _dep.Create(department);

            return CreatedAtRoute("DefaultApi", new { id = department.DepartmentId }, department);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(Department))]
        public IHttpActionResult DeleteDepartment(int id)
        {
            Department department = _dep.SingleData(id);
            if (department == null)
            {
                return NotFound();
            }

             dynamic msg= _dep.Delete(id);
            return Ok(msg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                _dep.Dispose(disposing);
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(int id)
        {
            return  _dep.GetAllList().Count(e => e.DepartmentId == id) > 0;
        }
    }
}