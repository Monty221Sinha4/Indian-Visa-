using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VisaSystem;

namespace VisaSystem.Controllers
{
    public class AppilcantsController : Controller
    {
        private DBVisa db = new DBVisa();

        // GET: Appilcants
        public ActionResult Index()
        {
            var appilcants = db.Appilcants.Include(a => a.City).Include(a => a.Countries_).Include(a => a.VisaStatu).Include(a => a.VisaType);
            return View(appilcants.ToList());
        }

        // GET: Appilcants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appilcant appilcant = db.Appilcants.Find(id);
            if (appilcant == null)
            {
                return HttpNotFound();
            }
            return View(appilcant);
        }

        // GET: Appilcants/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "City");
            ViewBag.VisaID = new SelectList(db.Countries_, "CountryID", "Country");
            ViewBag.StatusID = new SelectList(db.VisaStatus, "StatusID", "VisaStatus");
            ViewBag.VisaID = new SelectList(db.VisaTypes1, "VisaID", "VisaType");
            return View();
        }

        // POST: Appilcants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppID,Firstname,Surname,DateOfBirth,CityID,CountryID,VisaID,StatusID")] Appilcant appilcant)
        {
            if (ModelState.IsValid)
            {
                db.Appilcants.Add(appilcant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "City", appilcant.CityID);
            ViewBag.VisaID = new SelectList(db.Countries_, "CountryID", "Country", appilcant.VisaID);
            ViewBag.StatusID = new SelectList(db.VisaStatus, "StatusID", "VisaStatus", appilcant.StatusID);
            ViewBag.VisaID = new SelectList(db.VisaTypes1, "VisaID", "VisaType", appilcant.VisaID);
            return View(appilcant);
        }

        // GET: Appilcants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appilcant appilcant = db.Appilcants.Find(id);
            if (appilcant == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "City", appilcant.CityID);
            ViewBag.VisaID = new SelectList(db.Countries_, "CountryID", "Country", appilcant.VisaID);
            ViewBag.StatusID = new SelectList(db.VisaStatus, "StatusID", "VisaStatus", appilcant.StatusID);
            ViewBag.VisaID = new SelectList(db.VisaTypes1, "VisaID", "VisaType", appilcant.VisaID);
            return View(appilcant);
        }

        // POST: Appilcants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppID,Firstname,Surname,DateOfBirth,CityID,CountryID,VisaID,StatusID")] Appilcant appilcant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appilcant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "City", appilcant.CityID);
            ViewBag.VisaID = new SelectList(db.Countries_, "CountryID", "Country", appilcant.VisaID);
            ViewBag.StatusID = new SelectList(db.VisaStatus, "StatusID", "VisaStatus", appilcant.StatusID);
            ViewBag.VisaID = new SelectList(db.VisaTypes1, "VisaID", "VisaType", appilcant.VisaID);
            return View(appilcant);
        }

        // GET: Appilcants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appilcant appilcant = db.Appilcants.Find(id);
            if (appilcant == null)
            {
                return HttpNotFound();
            }
            return View(appilcant);
        }

        // POST: Appilcants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appilcant appilcant = db.Appilcants.Find(id);
            db.Appilcants.Remove(appilcant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
