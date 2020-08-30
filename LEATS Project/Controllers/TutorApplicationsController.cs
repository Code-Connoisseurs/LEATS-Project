using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LEATS_Project.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace LEATS_Project.Controllers
{
    public class TutorApplicationsController : Controller
    {
        private ApplicationUserManager _userManager;
        private hon06Entities2 db = new hon06Entities2();
        public TutorApplicationsController()
        {

        }
        public TutorApplicationsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: TutorApplications
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var tutorApplications = db.TutorApplications.Include(t => t.Student);
            return View(tutorApplications.ToList());
        }

        // GET: TutorApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorApplication tutorApplication = db.TutorApplications.Find(id);
            if (tutorApplication == null)
            {
                return HttpNotFound();
            }

            return View(tutorApplication);
        }

        public void ApproveTutor(int? id)
        {
            TutorApplication tutorApplication = db.TutorApplications.Find(id);
            if (tutorApplication != null)
            {
                tutorApplication.ApplicationStatus = "Approved";
                UserManager.AddToRole(tutorApplication.Student.Id, "Tutor");
                db.SaveChanges();
            }

        }


        [HttpGet]
        public FileResult DownloadFileAcademicTrans(int? id)
        {

            
            TutorApplication tutorApplication = db.TutorApplications.Find(id);
            string fileName = tutorApplication.Student.FirstName + tutorApplication.Student.LastName;
            return File(tutorApplication.AcademicTranscript, "application/pdf", fileName+"Academic Trascript.pdf");
        }
        [HttpGet]
        public FileResult DownloadFileProofofReg(int? id)
        {


            TutorApplication tutorApplication = db.TutorApplications.Find(id);
            string fileName = tutorApplication.Student.FirstName + tutorApplication.Student.LastName;
            return File(tutorApplication.ProofOfRegistration, "application/pdf", fileName + "Proof of Registration.pdf");
        }

        // GET: TutorApplications/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID");
            return View();
        }

        // POST: TutorApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationID,StudentID,ModuleCode,ModuleName,AcademicTranscript,ProofOfRegistration,ApplicationDate,ApplicationStatus")] TutorApplication tutorApplication, HttpPostedFileBase acad, HttpPostedFileBase proof)
        {
            if (ModelState.IsValid)
            {
                if (acad != null && proof != null)
                {

                    tutorApplication.AcademicTranscript = new byte[acad.ContentLength];
                    acad.InputStream.Read(tutorApplication.AcademicTranscript, 0, acad.ContentLength);

                    tutorApplication.ProofOfRegistration = new byte[proof.ContentLength];
                    proof.InputStream.Read(tutorApplication.ProofOfRegistration, 0, proof.ContentLength);

                }
                db.TutorApplications.Add(tutorApplication);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID", tutorApplication.StudentID);
            return View(tutorApplication);
        }

        // GET: TutorApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorApplication tutorApplication = db.TutorApplications.Find(id);
            if (tutorApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID", tutorApplication.StudentID);
            return View(tutorApplication);
        }

        // POST: TutorApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationID,StudentID,ModuleCode,ModuleName,AcademicTranscript,ProofOfRegistration,ApplicationDate,ApplicationStatus")] TutorApplication tutorApplication, HttpPostedFileBase acad, HttpPostedFileBase proof)
        {
            if (ModelState.IsValid)
            {
                if (acad != null && proof != null)
                {

                    tutorApplication.AcademicTranscript = new byte[acad.ContentLength];
                    acad.InputStream.Read(tutorApplication.AcademicTranscript, 0, acad.ContentLength);

                    tutorApplication.ProofOfRegistration = new byte[proof.ContentLength];
                    proof.InputStream.Read(tutorApplication.ProofOfRegistration, 0, proof.ContentLength);

                }
                db.Entry(tutorApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentID", tutorApplication.StudentID);
            return View(tutorApplication);
        }

        // GET: TutorApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorApplication tutorApplication = db.TutorApplications.Find(id);
            if (tutorApplication == null)
            {
                return HttpNotFound();
            }
            return View(tutorApplication);
        }

        // POST: TutorApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TutorApplication tutorApplication = db.TutorApplications.Find(id);
            db.TutorApplications.Remove(tutorApplication);
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
