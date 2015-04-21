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
    public class RecordController : Controller
    {
        private HeritageAllianceAppDb _db = new HeritageAllianceAppDb();

        //
        // GET: /Record/

        public ActionResult Index()
        {
            var records = _db.Records.Include(r => r.Deceased);
            return View(records.ToList());
        }

        //
        // GET: /Record/Details/5

        public ActionResult Details(int id = 0)
        {
            Record record = _db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        //
        // GET: /Record/Create

        public ActionResult Create()
        {
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName");
            return View();
        }

        //
        // POST: /Record/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Record record)
        {
            if (ModelState.IsValid)
            {
                _db.Records.Add(record);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", record.DeceasedId);
            return View(record);
        }

        //
        // GET: /Record/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Record record = _db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", record.DeceasedId);
            return View(record);
        }

        //
        // POST: /Record/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Record record)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(record).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeceasedId = new SelectList(_db.Deceased, "DeceasedId", "FirstName", record.DeceasedId);
            return View(record);
        }

        //
        // GET: /Record/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Record record = _db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        //
        // POST: /Record/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = _db.Records.Find(id);
            _db.Records.Remove(record);
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