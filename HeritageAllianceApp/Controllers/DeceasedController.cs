using HeritageAllianceApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public ActionResult Admin()
        {
            return View(_db.Deceased.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Deceased d = _db.Deceased.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }

            BuildAssociatedLists(id);
            
            return View(d);
        }

        private void BuildAssociatedLists(int id)
        {
            List<Related> Relatives = _db.Related
                                         .Where(r => r.DeceasedId == id)
                                         .ToList<Related>();
            List<FamilyMember> FamilyMembers = _db.FamilyMembers
                                                  .Where(f => f.DeceasedId == id)
                                                  .ToList<FamilyMember>();
            List<Record> Records = _db.Records
                                      .Where(r => r.DeceasedId == id)
                                      .ToList<Record>();
            List<BiographicalInformation> BioInformation = _db.BiographicalInformation
                                                              .Where(b => b.DeceasedId == id)
                                                              .ToList<BiographicalInformation>();

            List<RecordLink> RecordLinks = new List<RecordLink>();
            foreach (Record rec in Records)
            {
                RecordLinks.Add(_db.RecordLinks.FirstOrDefault(r => r.RecordId == rec.RecordId));
            }
            
            List<InformationLink> InfoLinks = new List<InformationLink>();
            foreach (BiographicalInformation bio in BioInformation)
            {
                InfoLinks.Add(_db.InformationLinks.FirstOrDefault(i => i.InformationId == bio.BiographicalInformationId));
            }

            ViewBag.Relatives = Relatives;
            ViewBag.FamilyMembers = FamilyMembers;
            ViewBag.Records = Records;
            ViewBag.BioInformation = BioInformation;
            ViewBag.RecordLinks = RecordLinks;
            ViewBag.InfoLinks = InfoLinks;
        }

        public ActionResult Create()
        {
            var cemeteries = _db.Cemeteries
                               .ToList()
                               .Select(c => new
                               {
                                   CemeteryId = c.CemeteryId,
                                   CemeteryName = string.Format("{0}", c.CemeteryName)
                               });
            ViewBag.CemeteryId = new SelectList(cemeteries, "CemeteryId", "CemeteryName");            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Deceased deceased)
        {
            if (ModelState.IsValid)
            {
                _db.Deceased.Add(deceased);
                _db.SaveChanges();
                return RedirectToAction("Admin");
            }

            var cemeteries = _db.Cemeteries
                                           .ToList()
                                           .Select(c => new
                                           {
                                               CemeteryId = c.CemeteryId,
                                               CemeteryName = string.Format("{0}", c.CemeteryName)
                                           });
            ViewBag.CemeteryId = new SelectList(cemeteries, "CemeteryId", "CemeteryName"); return View(deceased);
        }

        public ActionResult Edit(int id = 0)
        {
            Deceased deceased = _db.Deceased.Find(id);
            if (deceased == null)
            {
                return HttpNotFound();
            }
            var cemeteries = _db.Cemeteries
                                           .ToList()
                                           .Select(c => new
                                           {
                                               CemeteryId = c.CemeteryId,
                                               CemeteryName = string.Format("{0}", c.CemeteryName)
                                           });
            ViewBag.CemeteryId = new SelectList(cemeteries, "CemeteryId", "CemeteryName"); return View(deceased);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Deceased deceased)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(deceased).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Admin");
            }
            var cemeteries = _db.Cemeteries
                                           .ToList()
                                           .Select(c => new
                                           {
                                               CemeteryId = c.CemeteryId,
                                               CemeteryName = string.Format("{0}", c.CemeteryName)
                                           });
            ViewBag.CemeteryId = new SelectList(cemeteries, "CemeteryId", "CemeteryName"); return View(deceased);
        }

        public ActionResult Delete(int id = 0)
        {
            Deceased deceased = _db.Deceased.Find(id);
            if (deceased == null)
            {
                return HttpNotFound();
            }
            return View(deceased);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deceased deceased = _db.Deceased.Find(id);
            _db.Deceased.Remove(deceased);
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
