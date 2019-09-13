using Fundraising_Capstone2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Voice;
using Fundraising_Capstone2.API;
using Fundraising_Capstone2.Keys;

namespace ClientQuickstart.Controllers
{


    public class PhoneController : Controller
    {
        [HttpGet]
        public ActionResult Index() //string to
        {
            return View();
           



            //public ActionResult Index(string to)
            //{
            //    var response = new VoiceResponse();
            //    response.Say("Thanks for calling!");

            //    Execute();
            //    return Content(response.ToString(), "text/xml");
            //}



            //public void Conference()
            //{
            //    var response = new VoiceResponse();
            //    var dial = new Dial();
            //    dial.Conference("miderated-conference-room",
            //    startConferenceOnEnter: false);
            //    response.Append(dial);


            //    Console.WriteLine(response.ToString());

            //   {
            //        return Content(result.RestException.Message);
            //    }

            //  //  return Content("The call has been initiated");
        }
    }
}