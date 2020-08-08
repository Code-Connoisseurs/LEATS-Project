using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEATS_Project.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult StudentHome()
        {
            ViewBag.Message = "Student Home.";

            return View();
        }

        public ActionResult TutorHome()
        {
            ViewBag.Message = "TutorHome";

            return View();
        }

        public ActionResult FindTutor()
        {
            ViewBag.Message = "Find your private Tutor";

            return View();
        }

        public ActionResult BecomeTutor()
        {
            ViewBag.Message = "Tutor with the best";

            return View();
        }

        //For linking to layout
        public ActionResult GoInside()
        {
            return View();
        }
    }
}