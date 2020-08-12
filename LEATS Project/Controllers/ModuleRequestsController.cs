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
    public class ModuleRequestsController : Controller
    {
        private hon06Entities1 db = new hon06Entities1();

        // GET: ModuleRequests
        public ActionResult Index()
        {
            var moduleRequests = db.ModuleRequests.Include(m => m.Student);
            return View(moduleRequests.ToList());
        }

        // GET: ModuleRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleRequest moduleRequest = db.ModuleRequests.Find(id);
            if (moduleRequest == null)
            {
                return HttpNotFound();
            }
            return View(moduleRequest);
        }

        // GET: ModuleRequests/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Id");
            return View();
        }

        // POST: ModuleRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,StudentID,ModuleCode,ModuleName,RequestDate")] ModuleRequest moduleRequest)
        {
            if (ModelState.IsValid)
            {
                db.ModuleRequests.Add(moduleRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Id", moduleRequest.StudentID);
            return View(moduleRequest);
        }

        // GET: ModuleRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleRequest moduleRequest = db.ModuleRequests.Find(id);
            if (moduleRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Id", moduleRequest.StudentID);
            return View(moduleRequest);
        }

        // POST: ModuleRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,StudentID,ModuleCode,ModuleName,RequestDate")] ModuleRequest moduleRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Id", moduleRequest.StudentID);
            return View(moduleRequest);
        }

        // GET: ModuleRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleRequest moduleRequest = db.ModuleRequests.Find(id);
            if (moduleRequest == null)
            {
                return HttpNotFound();
            }
            return View(moduleRequest);
        }

        // POST: ModuleRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModuleRequest moduleRequest = db.ModuleRequests.Find(id);
            db.ModuleRequests.Remove(moduleRequest);
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
