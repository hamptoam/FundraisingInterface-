using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Mvc;

namespace Fundraising_Capstone2.Controllers
{
    public class HomeController : TwilioController
    {
        public ActionResult Index()
        {
            if (this.User.IsInRole("Manager"))
            {
                return RedirectToAction("Index", "Managers");
            }
            else if(this.User.IsInRole("Employee"))
            {
                return RedirectToAction("Index", "Phones");
            }
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
    }
}