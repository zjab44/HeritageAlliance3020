using HeritageAllianceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeritageAllianceApp.Controllers
{
    public class SearchController : Controller
    {
        private HeritageAllianceAppDb _db = new HeritageAllianceAppDb();

        public ActionResult Index()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
