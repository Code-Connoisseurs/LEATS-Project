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

    public class StudentsController : Controller
    {
        private ApplicationUserManager _userManager;
        private hon06Entities2 db = new hon06Entities2();

        public StudentsController()
        {

        }
        public StudentsController(ApplicationUserManager userManager)
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
        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.AspNetUser);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Id", Session["ActiveUser"]);
            
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Id,FirstName,LastName,Gender,Ethnicity,DateOfBirth,CellphoneNo,Email,LevelOfStudy,Campus,College,StreetName,Suburb,City,Province,PostalCode,ProfilePicture")] Student student, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if(image1 != null)
                {
                    student.ProfilePicture = new byte[image1.ContentLength];
                    image1.InputStream.Read(student.ProfilePicture, 0, image1.ContentLength);
                }
                UserManager.AddToRole(student.Id, "Student");
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", Session["ActiveUser"]);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", student.Id/*Session["ActiveUser"]*/);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Id,FirstName,LastName,Gender,Ethnicity,DateOfBirth,CellphoneNo,Email,LevelOfStudy,Campus,College,StreetName,Suburb,City,Province,PostalCode,ProfilePicture")] Student student, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    student.ProfilePicture = new byte[image1.ContentLength];
                    image1.InputStream.Read(student.ProfilePicture, 0, image1.ContentLength);
                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", student.Id /*Session["ActiveUser"]*/);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
