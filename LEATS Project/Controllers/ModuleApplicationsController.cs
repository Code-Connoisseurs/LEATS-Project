using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LEATS_Project.Models;

namespace LEATS_Project.Controllers
{
    public class ModuleApplicationsController : Controller
    {
        private hon06Entities2 db = new hon06Entities2();

        // GET: ModuleApplications
        public ActionResult Index()
        {
            var moduleApplications = db.ModuleApplications.Include(m => m.Tutor);
            return View(moduleApplications.ToList());
        }

        // GET: ModuleApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleApplication moduleApplication = db.ModuleApplications.Find(id);
            if (moduleApplication == null)
            {
                return HttpNotFound();
            }
            return View(moduleApplication);
        }

        // GET: ModuleApplications/Create
        public ActionResult Create()
        {
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience");
            return View();
        }

        // POST: ModuleApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleApplicationID,TutorID,ModuleCode,ModuleName,Date,Status")] ModuleApplication moduleApplication)
        {
            if (ModelState.IsValid)
            {
                db.ModuleApplications.Add(moduleApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", moduleApplication.TutorID);
            return View(moduleApplication);
        }

        // GET: ModuleApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleApplication moduleApplication = db.ModuleApplications.Find(id);
            if (moduleApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", moduleApplication.TutorID);
            return View(moduleApplication);
        }

        // POST: ModuleApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleApplicationID,TutorID,ModuleCode,ModuleName,Date,Status")] ModuleApplication moduleApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", moduleApplication.TutorID);
            return View(moduleApplication);
        }

        // GET: ModuleApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleApplication moduleApplication = db.ModuleApplications.Find(id);
            if (moduleApplication == null)
            {
                return HttpNotFound();
            }
            return View(moduleApplication);
        }

        // POST: ModuleApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModuleApplication moduleApplication = db.ModuleApplications.Find(id);
            db.ModuleApplications.Remove(moduleApplication);
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
