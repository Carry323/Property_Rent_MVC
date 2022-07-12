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
    public class TenantsController : Controller
    {
        private Property_Rental_ManagementEntities db = new Property_Rental_ManagementEntities();

        // GET: Tenants

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tenant tenant)
        {
            // var user = db.Owners.Where(x => x.OwnerEmail == owner.OwnerEmail && x.OwnerPassword == owner.OwnerPassword).Count();
            var user = db.Tenants.Where(x => x.TenantEmail == tenant.TenantEmail && x.TenantPhoneNumber == tenant.TenantPhoneNumber).Count();
            if (user > 0)
            {


                ViewBag.messege = "Invalid UserName Or PassWord";
                return RedirectToAction("Dashbord");

            }
            else
            {

                Session["TenantEmail"] = tenant.TenantEmail;
                return RedirectToAction("Dashbord");
            }
        }

        public ActionResult Dashbord(Tenant tenant)
        {

            return View();
            //return RedirectToAction("Detals");



        }
        public ActionResult ShowInf()
        {
            var tenants = db.Tenants.Include(t => t.Leas);
            return View(tenants.ToList());
        }

        // GET: Tenants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // GET: Tenants/Create
        public ActionResult Create()
        {
            ViewBag.LeaseId = new SelectList(db.Leases, "LeaseId", "LeaseId");
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenantId,LeaseId,TenantFirstName,TenantLastName,TenantEmail,TenantPassword,TenantPhoneNumber")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Tenants.Add(tenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeaseId = new SelectList(db.Leases, "LeaseId", "LeaseId", tenant.LeaseId);
            return View(tenant);
        }

        // GET: Tenants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeaseId = new SelectList(db.Leases, "LeaseId", "LeaseId", tenant.LeaseId);
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenantId,LeaseId,TenantFirstName,TenantLastName,TenantEmail,TenantPhoneNumber,TenantPassword,")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeaseId = new SelectList(db.Leases, "LeaseId", "LeaseId", tenant.LeaseId);
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            db.Tenants.Remove(tenant);
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
