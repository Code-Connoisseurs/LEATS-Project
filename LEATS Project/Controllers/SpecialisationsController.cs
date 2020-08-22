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
        private hon06Entities2 db = new hon06Entities2();

        // GET: Specialisations
        /*public ActionResult Index()
        {
            var specialisations = db.Specialisations.Include(s => s.Module).Include(s => s.Tutor);
            return View(specialisations.ToList());
        }*/

        public ActionResult Index(string searchBox)
        {

            return View(db.Specialisations.Where(model => model.Module.ModuleCode.Contains(searchBox) || model.Tutor.Student.FirstName.Contains(searchBox) || model.Tutor.Student.LastName.Contains(searchBox) || searchBox == null).ToList());
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
            /*/Object of selected attributes of students
            var tutorObject = from t in db.Students
                              select new {t.StudentID, t.FirstName, t.LastName, t.Gender, t.Ethnicity, t.CellphoneNo, t.Email, t.LevelOfStudy, t.Campus, t.College, t.Province, t.City, t.Suburb, t.StreetName, t.PostalCode, t.ProfilePicture };

            //Contains students id's
            var studentIds = from st in tutorObject
                             where st.StudentID.Equals(Session["ActiveStudentID"])
                             select st;
            //Object of selected attributes of Modules
            var moduleObject = from m in db.Modules
                               select new {m.ModuleID, m.ModuleCode, m.Description };
            //Contains modules id's
            /*var moduleIds = from md in moduleObject
                            where md.ModuleID.Equals("")
                            select st;
            return View(studentIds);*/
        }

        // GET: Specialisations/Create
        public ActionResult Create()
        {
            ViewBag.ModuleID = new SelectList(db.Modules, "ModuleID", "ModuleCode");
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorID");
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
