using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using w1.Interface;
using w1.Models;

namespace w1.Controllers
{
    [Authorize]
    public class Students1Controller : Controller
    {
        private readonly IStudentService _stu;
        private readonly IDepartmentService _dep;
        private StudentDbContext db = new StudentDbContext();

        public Students1Controller(IStudentService stu, IDepartmentService dep)
        {
            _stu = stu;
            _dep = dep;
        }

        // GET: Students1
        public ActionResult Index()
        {
            var students = _stu.GetAllList();
            return View(students);
        }

        // GET: Students1/Details/5
        public ActionResult Details(int id)
        {
            
            Student student = _stu.SingleData(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students1/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_dep.GetAllList(), "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Students1/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,E1,E2,E3,WrittenExam,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
               dynamic msg= _stu.Create(student);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // GET: Students1/Edit/5
        public ActionResult Edit(int id)
        {

            Student student = _stu.SingleData(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(_dep.GetAllList(), "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // POST: Students1/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,E1,E2,E3,WrittenExam,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
               dynamic msg= _stu.Update(student);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", student.DepartmentId);
            return View(student);
        }

        // GET: Students1/Delete/5
        public ActionResult Delete(int id)
        {

            Student student = _stu.SingleData(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dynamic msg = _stu.Delete(id);
          
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _stu.Dispose(disposing);
            }
            base.Dispose(disposing);
        }
    }
}
