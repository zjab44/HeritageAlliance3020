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
    public class FamilyMemberController : Controller
    {
        private HeritageAllianceAppDb _db = new HeritageAllianceAppDb();

        //
        // GET: /FamilyMember/

        public ActionResult Index()
        {
            var familymembers = _db.FamilyMembers.Include(f => f.Deceased);
            return View(familymembers.ToList());
        }

        //
        // GET: /FamilyMember/Details/5

        public ActionResult Details(int id = 0)
        {
            FamilyMember familymember = _db.FamilyMembers.Find(id);
            if (familymember == null)
            {
                return HttpNotFound();
            }
            return View(familymember);
        }

        //
        // GET: /FamilyMember/Create

        public ActionResult Create()
        {
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName");
            return View();
        }

        //
        // POST: /FamilyMember/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FamilyMember familymember)
        {
            if (ModelState.IsValid)
            {
                _db.FamilyMembers.Add(familymember);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", familymember.DeceasedId);
            return View(familymember);
        }

        //
        // GET: /FamilyMember/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FamilyMember familymember = _db.FamilyMembers.Find(id);
            if (familymember == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", familymember.DeceasedId);
            return View(familymember);
        }

        //
        // POST: /FamilyMember/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FamilyMember familymember)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(familymember).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", familymember.DeceasedId);
            return View(familymember);
        }

        //
        // GET: /FamilyMember/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FamilyMember familymember = _db.FamilyMembers.Find(id);
            if (familymember == null)
            {
                return HttpNotFound();
            }
            return View(familymember);
        }

        //
        // POST: /FamilyMember/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyMember familymember = _db.FamilyMembers.Find(id);
            _db.FamilyMembers.Remove(familymember);
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