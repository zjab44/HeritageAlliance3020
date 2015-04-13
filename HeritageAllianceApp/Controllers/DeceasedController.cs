using HeritageAllianceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeritageAllianceApp.Controllers
{
    public class DeceasedController : Controller
    {
        private HeritageAllianceAppDb _db = new HeritageAllianceAppDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Deceased d = _db.Deceased.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }                            
            return View(d);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }


    }
}
