using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeritageAllianceApp.Models;

namespace HeritageAllianceApp.Controllers
{
    public class RelatedController : Controller
    {
        private HeritageAllianceAppDb _db = new HeritageAllianceAppDb();

        public ActionResult Index()
        {
            var related = _db.Related.Include(r => r.Deceased).Include(r => r.DeceasedRelative);
            return View(related.ToList());
        }

        public ActionResult Admin()
        {            
            return View(_db.Related.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Related related = _db.Related.Find(id);
            if (related == null)
            {
                return HttpNotFound();
            }
            return View(related);
        }

        public ActionResult Create()
        {
            var deceased = _db.Deceased
                               .ToList()
                               .Select(d => new
                               {
                                   DeceasedId = d.DeceasedId,
                                   DecasedName = string.Format("{0} {1} {2}", d.FirstName, d.MiddleName, d.LastName)
                               });
            ViewBag.DeceasedId = new SelectList(deceased, "DeceasedId", "DecasedName");
            ViewBag.DeceasedRelativeId = new SelectList(deceased, "DeceasedId", "DecasedName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Related related)
        {
            if (ModelState.IsValid)
            {
                _db.Related.Add(related);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var deceased = _db.Deceased
                               .ToList()
                               .Select(d => new
                               {
                                   DeceasedId = d.DeceasedId,
                                   DecasedName = string.Format("{0} {1} {2}", d.FirstName, d.MiddleName, d.LastName)
                               });
            ViewBag.DeceasedId = new SelectList(deceased, "DeceasedId", "DecasedName");
            ViewBag.DeceasedRelativeId = new SelectList(deceased, "DeceasedId", "DecasedName");
            return View(related);
        }

        public ActionResult Edit(int id = 0)
        {
            Related related = _db.Related.Find(id);
            if (related == null)
            {
                return HttpNotFound();
            }
            var deceased = _db.Deceased
                               .ToList()
                               .Select(d => new
                               {
                                   DeceasedId = d.DeceasedId,
                                   DecasedName = string.Format("{0} {1} {2}", d.FirstName, d.MiddleName, d.LastName)
                               });
            ViewBag.DeceasedId = new SelectList(deceased, "DeceasedId", "DecasedName");
            ViewBag.DeceasedRelativeId = new SelectList(deceased, "DeceasedId", "DecasedName");
            return View(related);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Related related)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(related).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            var deceased = _db.Deceased
                               .ToList()
                               .Select(d => new
                               {
                                   DeceasedId = d.DeceasedId,
                                   DecasedName = string.Format("{0} {1} {2}", d.FirstName, d.MiddleName, d.LastName)
                               });
            ViewBag.DeceasedId = new SelectList(deceased, "DeceasedId", "DecasedName");
            ViewBag.DeceasedRelativeId = new SelectList(deceased, "DeceasedId", "DecasedName");
            return View(related);
        }

        public ActionResult Delete(int id = 0)
        {
            Related related = _db.Related.Find(id);
            if (related == null)
            {
                return HttpNotFound();
            }
            return View(related);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Related related = _db.Related.Find(id);
            _db.Related.Remove(related);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}