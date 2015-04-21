using HeritageAllianceApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public ActionResult Admin()
        {
            return View(_db.Locations.ToList());
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

        public ActionResult MapList()
        {
            var model = _db.Cemeteries
                .ToList();
            return View(model);
        }

        public ActionResult Details(int id = 0)
        {
            Location location = _db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                _db.Locations.Add(location);
                _db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(location);
        }
        
        public ActionResult Edit(int id = 0)
        {
            Location location = _db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(location).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(location);
        }

        public ActionResult Delete(int id = 0)
        {
            Location location = _db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = _db.Locations.Find(id);
            _db.Locations.Remove(location);
            _db.SaveChanges();
            return RedirectToAction("Admin");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose(); 
            base.Dispose(disposing);
        }
    }
}
