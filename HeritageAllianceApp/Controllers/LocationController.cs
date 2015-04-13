using HeritageAllianceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeritageAllianceApp.Controllers
{
    public class LocationController : Controller
    {
        private HeritageAllianceAppDb _db = new HeritageAllianceAppDb();

        public ActionResult Index()
        {
            
            return View();
        }       

        public ActionResult CityList()
        {
            var model = _db.Locations
                .Select(l => new LocationHandler { City = l.City, State = l.State })
                .Distinct()
                .OrderBy(l => l.City)
                .ToList();                               
            return View(model);
        }

        public ActionResult CountyList()
        {
            var model = _db.Locations
                .Select(l => new LocationHandler { County = l.County, State = l.State })
                .Distinct()
                .OrderBy(l => l.County )                 
                .ToList();
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose(); 
            base.Dispose(disposing);
        }

    }
}
