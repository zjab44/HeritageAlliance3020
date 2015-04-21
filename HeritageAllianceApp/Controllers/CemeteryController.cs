using HeritageAllianceApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public ActionResult Admin()
        {
            //var cemeteries = _db.Cemeteries.Include(c => c.Location);
            //return View(cemeteries.ToList());
            return View(_db.Cemeteries.ToList());
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
            Cemetery c = _db.Cemeteries.Find(id);
            var model = _db.Deceased
                .Where(d => d.CemeteryId == id)
                .OrderBy(d => d.LastName)
                .ToList();            
            ViewBag.CemeteryName = c.CemeteryName;
            return View(model);
        }
                
        public ActionResult Details(int id = 0)
        {
            Cemetery cemetery = _db.Cemeteries.Find(id);
            if (cemetery == null)
            {
                return HttpNotFound();
            }
            return View(cemetery);
        }

        public ActionResult Create()
        {
            var locations = _db.Locations                               
                               .ToList()
                               .Select(l => new 
                                { 
                                    LocationId = l.LocationId,
                                    CityStateZip = string.Format("{0}, {1}  {2}", l.City, l.State, l.Zip) 
                                });
            ViewBag.LocationId = new SelectList(locations, "LocationId", "CityStateZip");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cemetery cemetery)
        {
            if (ModelState.IsValid)
            {
                _db.Cemeteries.Add(cemetery);
                _db.SaveChanges();
                return RedirectToAction("Admin");
            }

            var locations = _db.Locations
                               .ToList()
                               .Select(l => new
                               {
                                   LocationId = l.LocationId,
                                   CityStateZip = string.Format("{0}, {1}  {2}", l.City, l.State, l.Zip)
                               });
            ViewBag.LocationId = new SelectList(locations, "LocationId", "CityStateZip");
            return View(cemetery);
        }

        public ActionResult Edit(int id = 0)
        {
            Cemetery cemetery = _db.Cemeteries.Find(id);
            if (cemetery == null)
            {
                return HttpNotFound();
            }
            var locations = _db.Locations
                               .ToList()
                               .Select(l => new
                               {
                                   LocationId = l.LocationId,
                                   CityStateZip = string.Format("{0}, {1}  {2}", l.City, l.State, l.Zip)
                               });
            ViewBag.LocationId = new SelectList(locations, "LocationId", "CityStateZip");
            return View(cemetery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cemetery cemetery)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(cemetery).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Admin");
            }
            var locations = _db.Locations
                               .ToList()
                               .Select(l => new
                               {
                                   LocationId = l.LocationId,
                                   CityStateZip = string.Format("{0}, {1}  {2}", l.City, l.State, l.Zip)
                               });
            ViewBag.LocationId = new SelectList(locations, "LocationId", "CityStateZip");
            return View(cemetery);
        }

        public ActionResult Delete(int id = 0)
        {
            Cemetery cemetery = _db.Cemeteries.Find(id);
            if (cemetery == null)
            {
                return HttpNotFound();
            }
            return View(cemetery);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cemetery cemetery = _db.Cemeteries.Find(id);
            _db.Cemeteries.Remove(cemetery);
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
