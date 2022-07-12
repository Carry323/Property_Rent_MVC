using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Property_Rental_Management_Web_Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     //   List

        //public CheekRadio(FormCollection frm)
        //{


        //    if(string login = frm["Broker"].toString){
        //        return RedirectToAction("Index", "LoginBroker");
        //    }


        //}
    }

}