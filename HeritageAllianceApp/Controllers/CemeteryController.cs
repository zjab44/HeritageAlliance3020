using HeritageAllianceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeritageAllianceApp.Controllers
{
    public class CemeteryController : Controller
    {
        private HeritageAllianceAppDb _db = new HeritageAllianceAppDb();

        public ActionResult Index()
        {
            var model = _db.Cemeteries.AsEnumerable<Cemetery>()
                .OrderBy(c => c.CemeteryName)
                .ToList();  
            return View(model);           
        }

        public ActionResult ListByCity(string city, string state)
        {
            ViewBag.City = city;
            ViewBag.State = state;
            var model = _db.Cemeteries
                .Where(c => c.Location.City == city && c.Location.State == state)
                .OrderBy(c => c.CemeteryName)
                .ToList();
            return View(model);  
        }

        public ActionResult ListByCounty(string county, string state)
        {
            ViewBag.County = county;
            ViewBag.State = state;
            var model = _db.Cemeteries
                .Where(c => c.Location.County == county && c.Location.State == state)
                .OrderBy(c => c.CemeteryName)
                .ToList();
            return View(model);
        }

        public ActionResult ListDeceased(int id)
        {
            var model = _db.Deceased
                .Where(d => d.CemeteryId == id)
                .OrderBy(d => d.LastName)
                .ThenBy(d => d.FirstName)
                .ToList();            
            ViewBag.CemeteryName = _db.Cemeteries
                .Where(c => c.CemeteryId == id)
                .Select(c => c.CemeteryName);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

    }
}
