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
    public class BiographicalInformationController : Controller
    {
        private HeritageAllianceAppDb _db = new HeritageAllianceAppDb();

        //
        // GET: /BiographicalInformation/

        public ActionResult Index()
        {
            var biographicalinformation = _db.BiographicalInformation.Include(b => b.Deceased).Include(b => b.FamilyMember);
            return View(biographicalinformation.ToList());
        }

        //
        // GET: /BiographicalInformation/Details/5

        public ActionResult Details(int id = 0)
        {
            BiographicalInformation biographicalinformation = _db.BiographicalInformation.Find(id);
            if (biographicalinformation == null)
            {
                return HttpNotFound();
            }
            return View(biographicalinformation);
        }

        //
        // GET: /BiographicalInformation/Create

        public ActionResult Create()
        {
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName");
            ViewBag.FamilyMemberId = new SelectList(_db.FamilyMembers, "FamilyMemberId", "Relationship");
            return View();
        }

        //
        // POST: /BiographicalInformation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BiographicalInformation biographicalinformation)
        {
            if (ModelState.IsValid)
            {
                _db.BiographicalInformation.Add(biographicalinformation);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", biographicalinformation.DeceasedId);
            ViewBag.FamilyMemberId = new SelectList(_db.FamilyMembers, "FamilyMemberId", "Relationship", biographicalinformation.FamilyMemberId);
            return View(biographicalinformation);
        }

        //
        // GET: /BiographicalInformation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BiographicalInformation biographicalinformation = _db.BiographicalInformation.Find(id);
            if (biographicalinformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", biographicalinformation.DeceasedId);
            ViewBag.FamilyMemberId = new SelectList(_db.FamilyMembers, "FamilyMemberId", "Relationship", biographicalinformation.FamilyMemberId);
            return View(biographicalinformation);
        }

        //
        // POST: /BiographicalInformation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BiographicalInformation biographicalinformation)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(biographicalinformation).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", biographicalinformation.DeceasedId);
            ViewBag.FamilyMemberId = new SelectList(_db.FamilyMembers, "FamilyMemberId", "Relationship", biographicalinformation.FamilyMemberId);
            return View(biographicalinformation);
        }

        //
        // GET: /BiographicalInformation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BiographicalInformation biographicalinformation = _db.BiographicalInformation.Find(id);
            if (biographicalinformation == null)
            {
                return HttpNotFound();
            }
            return View(biographicalinformation);
        }

        //
        // POST: /BiographicalInformation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BiographicalInformation biographicalinformation = _db.BiographicalInformation.Find(id);
            _db.BiographicalInformation.Remove(biographicalinformation);
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