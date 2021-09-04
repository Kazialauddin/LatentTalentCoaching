
using System.Web.Mvc;
using w1.Interface;
using w1.Models;
using w1.Services;

namespace w1.Controllers
{
    [Authorize]
    public class Departments1Controller : Controller
    {
        private readonly  IDepartmentService _department;

        public Departments1Controller(IDepartmentService department)
        {

            _department = department;
        }
        // GET: Departments1
        public ActionResult Index()
        {
           var dep= _department.GetAllList();
            return View(dep);
        }

        // GET: Departments1/Details/5
        public ActionResult Details(int id)
        {
            //

            var department = _department.SingleData(id);
            return View(department);
        }

        // GET: Departments1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                dynamic msg =  _department.Create(department);
              
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments1/Edit/5
        public ActionResult Edit(int id)
        {
           
            var department = _department.SingleData(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments1/Edit/5
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                dynamic msg= _department.Update(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments1/Delete/5
        public ActionResult Delete(int id)
        {

            var department = _department.SingleData(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dynamic msg = _department.Delete(id);
          
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                 _department.Dispose(disposing);
                            }
            base.Dispose(disposing);
        }
    }
}
