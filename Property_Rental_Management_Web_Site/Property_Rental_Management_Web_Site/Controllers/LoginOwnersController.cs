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
    public class LoginOwnersController : Controller
    {
        private Property_Rental_ManagementEntities db = new Property_Rental_ManagementEntities();

        public ActionResult Index()
        {
            return View();
        }
        // GET: Owners
        [HttpPost]
        public ActionResult Index(Owner owner)
        {
           var user = db.Owners.Where(x => x.OwnerEmail == owner.OwnerEmail && x.OwnerPhoneNumber== owner.OwnerPhoneNumber).Count();
          //  var user = db.Owners.Where(x => x.OwnerEmail == owner.OwnerEmail).FirstOrDefault();
            if (user == null)
            {


                ViewBag.messege = "Invalid UserName Or PassWord";
                return View();

            }
            else
            {

                Session["OwnerEmail"] = owner.OwnerEmail;
                return RedirectToAction("Dashbord");
            }
        }

        public ActionResult Dashbord(Owner owner)
        {

            return View();
            //return RedirectToAction("Detals");



        }

        public ActionResult LogOut()
        {

            Session.Abandon();
            return RedirectToAction("Index", "Home");



        }

        public ActionResult LogIn()
        {


            return RedirectToAction("Index", "LoginOwner");



        }


        public ActionResult Details(Owner owner)
        {
            return View();
        }


        // GET: Owners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OwnerId,OwnerFirstName,OwnerLastName,OwnerEmail,OwnerPhoneNumber")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Owners.Add(owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(owner);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OwnerId,OwnerFirstName,OwnerLastName,OwnerEmail,OwnerPhoneNumber")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner owner = db.Owners.Find(id);
            db.Owners.Remove(owner);
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
