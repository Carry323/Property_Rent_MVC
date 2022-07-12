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
    public class ApartmentsController : Controller
    {
        public class Apartments1Controller : Controller
        {
            private Property_Rental_ManagementEntities db = new Property_Rental_ManagementEntities();

            // GET: Apartments1
            public ActionResult Index()
            {
                return View(db.Apartments.ToList());
            }

            // GET: Apartments1/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Apartment apartment = db.Apartments.Find(id);
                if (apartment == null)
                {
                    return HttpNotFound();
                }
                return View(apartment);
            }

            // GET: Apartments1/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Apartments1/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "ApartmentId,ApartmentNumber,StreetName,ZipCode,City,Province,Floor,NumberOfBedrooms,NumberOfBathrooms,Status,Notes")] Apartment apartment)
            {
                if (ModelState.IsValid)
                {
                    db.Apartments.Add(apartment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(apartment);
            }

            // GET: Apartments1/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Apartment apartment = db.Apartments.Find(id);
                if (apartment == null)
                {
                    return HttpNotFound();
                }
                return View(apartment);
            }

            // POST: Apartments1/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "ApartmentId,ApartmentNumber,StreetName,ZipCode,City,Province,Floor,NumberOfBedrooms,NumberOfBathrooms,Status,Notes")] Apartment apartment)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(apartment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(apartment);
            }

            // GET: Apartments1/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Apartment apartment = db.Apartments.Find(id);
                if (apartment == null)
                {
                    return HttpNotFound();
                }
                return View(apartment);
            }

            // POST: Apartments1/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Apartment apartment = db.Apartments.Find(id);
                db.Apartments.Remove(apartment);
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
}
