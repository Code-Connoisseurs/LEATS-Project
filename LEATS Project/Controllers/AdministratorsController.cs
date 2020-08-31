using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LEATS_Project.Models;
using System.IO;
using System.Web.Hosting;

namespace LEATS_Project.Controllers
{
    public class AdministratorsController : Controller
    {
        private hon06Entities2 db = new hon06Entities2();

        // GET: Administrators
        [Authorize]
        public ActionResult Index()
        {
            var administrators = db.Administrators.Include(a => a.AspNetUser);
            return View(administrators.ToList());
        }

        // GET: Administrators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // GET: Administrators/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Id", Session["ActiveUser"]);
            return View();
        }

        // POST: Administrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdministratorID,Id,FirstName,LastName,Gender,Ethnicity,DateOfBirth,CellphoneNo,Email,StreetName,Suburb,City,Province,PostalCode,ProfilePicture")] Administrator administrator, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    administrator.ProfilePicture = new byte[image1.ContentLength];
                    image1.InputStream.Read(administrator.ProfilePicture, 0, image1.ContentLength);
                }else
                {
                    byte[] imageBytes = null;
                    string path = HostingEnvironment.MapPath("~/Images/");

                    FileStream filestream = null;
                    if (administrator.Gender == "Male")
                    {
                        filestream = new FileStream(path + "ProfilePicMale.jfif", FileMode.Open, FileAccess.Read);
                    }
                    else
                    {
                        filestream = new FileStream(path + "ProfilePicFemale.png", FileMode.Open, FileAccess.Read);
                    }
                    using (BinaryReader reader = new BinaryReader(filestream))
                    {
                        imageBytes = new byte[reader.BaseStream.Length];
                        for (int i = 0; i < reader.BaseStream.Length; i++)
                        {
                            imageBytes[i] = reader.ReadByte();
                        }
                    }
                    administrator.ProfilePicture = imageBytes;
                }
                db.Administrators.Add(administrator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Id", Session["ActiveUser"]);
            return View(administrator);
        }

        // GET: Administrators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Id", administrator.Id);
            return View(administrator);
        }

        // POST: Administrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdministratorID,Id,FirstName,LastName,Gender,Ethnicity,DateOfBirth,CellphoneNo,Email,StreetName,Suburb,City,Province,PostalCode,ProfilePicture")] Administrator administrator, HttpPostedFileBase image1)
        {
            if (ModelState.IsValid)
            {
                if (image1 != null)
                {
                    administrator.ProfilePicture = new byte[image1.ContentLength];
                    image1.InputStream.Read(administrator.ProfilePicture, 0, image1.ContentLength);
                }else
                {
                    byte[] imageBytes = null;
                    string path = HostingEnvironment.MapPath("~/Images/");

                    FileStream filestream = null;
                    if (administrator.Gender == "Male")
                    {
                        filestream = new FileStream(path + "ProfilePicMale.jfif", FileMode.Open, FileAccess.Read);
                    }
                    else
                    {
                        filestream = new FileStream(path + "ProfilePicFemale.png", FileMode.Open, FileAccess.Read);
                    }
                    using (BinaryReader reader = new BinaryReader(filestream))
                    {
                        imageBytes = new byte[reader.BaseStream.Length];
                        for (int i = 0; i < reader.BaseStream.Length; i++)
                        {
                            imageBytes[i] = reader.ReadByte();
                        }
                    }
                    administrator.ProfilePicture = imageBytes;
                }
                db.Entry(administrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", administrator.Id);
            return View(administrator);
        }

        // GET: Administrators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrator administrator = db.Administrators.Find(id);
            db.Administrators.Remove(administrator);
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
