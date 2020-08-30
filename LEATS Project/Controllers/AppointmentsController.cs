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
    public class AppointmentsController : Controller
    {
        private hon06Entities2 db = new hon06Entities2();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Student).Include(a => a.Tutor);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.StudentD = new SelectList(db.Students, "StudentID", "StudentID");
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "TutorID");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentID,StudentD,TutorID,RequestTime,AppointmentDate,AppointmentTime,AppointmentDuration,AppointmentType,AppointmentStatus,AppointmentDetails,Location")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                /*try
                {
                    db.SaveChanges();
                }catch(Exception)
                {

                }*/
                db.SaveChanges();
                Session["successMsg"] = true;
                return RedirectToAction("Index","Home");
            }
            ViewBag.StudentD = new SelectList(db.Students, "StudentID", "StudentID", appointment.StudentD);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", appointment.TutorID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentD = new SelectList(db.Students, "StudentID", "Id", appointment.StudentD);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", appointment.TutorID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentID,StudentD,TutorID,RequestTime,AppointmentDate,AppointmentTime,AppointmentDuration,AppointmentType,AppointmentStatus,AppointmentDetails,Location")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Select by ID
            ViewBag.StudentD = new SelectList(db.Students, "StudentID", "Id", appointment.StudentD);
            ViewBag.TutorID = new SelectList(db.Tutors, "TutorID", "Experience", appointment.TutorID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
