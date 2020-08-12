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
    public class SpecialisationsController : Controller
    {
        private hon06Entities1 db = new hon06Entities1();

        // GET: Specialisations
        public ActionResult Index()
        {
            var specialisations = db.Specialisations.Include(s => s.Module).Include(s => s.Tutor);
            return View(specialisations.ToList());
        }

        // GET: Specialisations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialisation specialisation = db.Specialisations.Find(id);
            if (specialisation == null)
            {
                return HttpNotFound();
            }
            return View(specialisation);
        }

        // GET: Specialisations/Create
        public ActionResult Create()
        {
            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModuleCode");
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience");
            return View();
        }

        // POST: Specialisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecialisationID,ModuleID,TutorID")] Specialisation specialisation)
        {
            if (ModelState.IsValid)
            {
                db.Specialisations.Add(specialisation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModuleCode", specialisation.ModuleID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", specialisation.TutorID);
            return View(specialisation);
        }

        // GET: Specialisations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialisation specialisation = db.Specialisations.Find(id);
            if (specialisation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModuleCode", specialisation.ModuleID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", specialisation.TutorID);
            return View(specialisation);
        }

        // POST: Specialisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecialisationID,ModuleID,TutorID")] Specialisation specialisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialisation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModuleCode", specialisation.ModuleID);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", specialisation.TutorID);
            return View(specialisation);
        }

        // GET: Specialisations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specialisation specialisation = db.Specialisations.Find(id);
            if (specialisation == null)
            {
                return HttpNotFound();
            }
            return View(specialisation);
        }

        // POST: Specialisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialisation specialisation = db.Specialisations.Find(id);
            db.Specialisations.Remove(specialisation);
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
