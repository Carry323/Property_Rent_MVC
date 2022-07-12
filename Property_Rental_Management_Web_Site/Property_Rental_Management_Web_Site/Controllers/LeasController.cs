using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Property_Rental_Management_Web_Site.Models;

namespace Property_Rental_Management_Web_Site.Controllers
{
    public class LeasController : Controller
    {
        private Property_Rental_ManagementEntities db = new Property_Rental_ManagementEntities();

        // GET: Leas
        public ActionResult Index()
        {
            var leases = db.Leases.Include(l => l.Apartment).Include(l => l.Broker).Include(l => l.Customer).Include(l => l.Owner);
            return View(leases.ToList());
        }

        // GET: Leas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leas leas = db.Leases.Find(id);
            if (leas == null)
            {
                return HttpNotFound();
            }
            return View(leas);
        }

        // GET: Leas/Create
        public ActionResult Create()
        {
            ViewBag.ApartmentId = new SelectList(db.Apartments, "ApartmentId", "ApartmentId");
            ViewBag.BrokerId = new SelectList(db.Brokers, "BrokerId", "BrokerId");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerId");
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "OwnerId");
            return View();
        }

        // POST: Leas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeaseId,PaymentDate,BrokerId,OwnerId,MonthlyRate,PaymentMethod,Fine,StartLeaseDate,EndLeaseDate,ApartmentId,CustomerId")] Leas leas)
        {
            if (ModelState.IsValid)
            {
                db.Leases.Add(leas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApartmentId = new SelectList(db.Apartments, "ApartmentId", "ApartmentId", leas.ApartmentId);
            ViewBag.BrokerId = new SelectList(db.Brokers, "BrokerId", "BrokerId", leas.BrokerId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerId", leas.CustomerId);
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "OwnerId", leas.OwnerId);
            return View(leas);
        }

        // GET: Leas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leas leas = db.Leases.Find(id);
            if (leas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApartmentId = new SelectList(db.Apartments, "ApartmentId", "ApartmentId", leas.ApartmentId);
            ViewBag.BrokerId = new SelectList(db.Brokers, "BrokerId", "BrokerId", leas.BrokerId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerId", leas.CustomerId);
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "OwnerId", leas.OwnerId);
            return View(leas);
        }

        // POST: Leas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeaseId,PaymentDate,BrokerId,OwnerId,MonthlyRate,PaymentMethod,Fine,StartLeaseDate,EndLeaseDate,ApartmentId,CustomerId")] Leas leas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApartmentId = new SelectList(db.Apartments, "ApartmentId", "ApartmentId", leas.ApartmentId);
            ViewBag.BrokerId = new SelectList(db.Brokers, "BrokerId", "BrokerId", leas.BrokerId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerId", leas.CustomerId);
            ViewBag.OwnerId = new SelectList(db.Owners, "OwnerId", "OwnerId", leas.OwnerId);
            return View(leas);
        }

        // GET: Leas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leas leas = db.Leases.Find(id);
            if (leas == null)
            {
                return HttpNotFound();
            }
            return View(leas);
        }

        // POST: Leas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leas leas = db.Leases.Find(id);
            db.Leases.Remove(leas);
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
