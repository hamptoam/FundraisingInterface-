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


    public class VoiceController : Controller
    {
        [HttpPost]
        public ActionResult Index(string to)
        {
            TwilioWrapperClient test = new TwilioWrapperClient(APIKeys.SID, APIKeys.AuthToken);
            

          var callerId = ConfigurationManager.AppSettings["TwilioCallerId"];

            var response = new VoiceResponse();
           if (!string.IsNullOrEmpty(to))
           {
                var dial = new Dial(callerId: callerId);
               // wrap the phone number or client name in the appropriate TwiML verb
            ////////    // by checking if the number given has only digits and format symbols
            if (Regex.IsMatch(to, "^[\\d\\+\\-\\(\\) ]+$"))
             {
                 dial.Number(to);
            }
             else
             {
                  dial.Client(to);
             }
               response = response.Dial(dial);
           }
           else
           {
                response.Say("Thanks for calling!");
           }
            return Content(response.ToString(), "text/xml");
        }

       

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