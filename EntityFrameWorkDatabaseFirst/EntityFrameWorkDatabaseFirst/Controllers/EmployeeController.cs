using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameWorkDatabaseFirst;

namespace EntityFrameWorkDatabaseFirst.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: /Employee/
        public ActionResult Index()
        {
            return View(db.tbl_employee.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employee);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmployeeId,FirstName,LastName,Address,Phone")] tbl_employee tbl_employee)
        {
            if (ModelState.IsValid)
            {
                db.tbl_employee.Add(tbl_employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EmployeeId,FirstName,LastName,Address,Phone")] tbl_employee tbl_employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            if (tbl_employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_employee tbl_employee = db.tbl_employee.Find(id);
            db.tbl_employee.Remove(tbl_employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
