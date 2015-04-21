using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeritageAllianceApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the Heritage Alliance cemetery database.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // ----- ADDED ACTIONS ----- //

        public ActionResult Locations()
        {
            return RedirectToAction("Index", "Location");
        }

        public ActionResult Cemeteries()
        {
            return RedirectToAction("Index", "Cemetery");
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}
