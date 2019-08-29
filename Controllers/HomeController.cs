using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Clients;
using Twilio.TwiML;
using TwilioMakeAndRecieveCalls.Controllers;
using Fundraising_Capstone.APIKeys;
using Twilio.Rest.Api.V2010.Account;

namespace Fundraising_Capstone.Controllers
{
    public class HomeController : TwilioController
    {
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult RecieveCall()
        {
            var twiml = new VoiceResponse();
            return TwiML(twiml.Say("You are calling Amelia").Dial(Settings.MyOwnNumber));
        }




        //[HttpPost]
        //public ActionResult MakeCall(string number)
        //{
        //    var client = new TwilioRestClient(Settings.AccountSid, Settings.AuthToken);
        //   

        //    
        //}


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


        //public ActionResult Create(
        //    [Bind(Include = "firstName, lastName, phoneNumber")] Ticket ticket)
        //{
        //    ticket.CreatedAt = DateTime.UtcNow;
        //    if (ModelState.IsValid)
        //    {
        //        _repository.Create(ticket);
        //        ViewBag.Success = "Your ticket was submitted!";
        //        ModelState.Clear();
        //        return View("Index");
        //    }
        //    return View("Index");
        //    }
        //}

    }
}