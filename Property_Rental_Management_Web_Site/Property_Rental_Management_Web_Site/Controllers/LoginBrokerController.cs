using Property_Rental_Management_Web_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Property_Rental_Management_Web_Site.Controllers
{
    public class LoginBrokerController : Controller
    {
        Property_Rental_ManagementEntities db = new Property_Rental_ManagementEntities();
        // GET: LoginBroker
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(Broker broker)
        {
            var user = db.Brokers.Where(x => x.BrokerEmail == broker.BrokerEmail && x.BrokerPassword == broker.BrokerPassword).Count();
            if (user > 0)
            {


                Session["BrokerEmail"] = broker.BrokerEmail;
                return RedirectToAction("Dashbord");
            }
            else
            {

                ViewBag.messege = "Invalid UserName Or PassWord";
                return View();
            }
        }

        public ActionResult Dashbord(Broker broker) 
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

           
            return RedirectToAction("Index", "LoginBroker");



        }


        public ActionResult Details(Broker broker)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrokerId,BrokerFirstName,BrokerLastName,BrokerEmail,BrokerPassword")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                db.Brokers.Add(broker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(broker);
        }



        //public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }

        //        Broker broker = db.Brokers.Find(id);
        //        if (broker == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(broker);
        //    }

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Broker broker = db.Brokers.Find(id);
        //    if (broker == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(broker);
        //}
    }
}