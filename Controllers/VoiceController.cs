using Fundraising_Capstone.Keys;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace ClientQuickstart.Controllers
{
    public class VoiceController : Controller
    {
        [HttpPost]
        public ActionResult Index(string to)
        {
            var callerId = ConfigurationManager.AppSettings["TwilioCallerId"];

            var response = new VoiceResponse();
            if (!string.IsNullOrEmpty(to))
            {
                var dial = new Dial(callerId: callerId);
                // wrap the phone number or client name in the appropriate TwiML verb
                // by checking if the number given has only digits and format symbols
                if (Regex.IsMatch(to, "^[\\d\\+\\-\\(\\) ]+$"))
                {
                    dial.Number(to);
                }
                else
                {
                    dial.Client(to);
                }
                response.Dial(dial);
            }
            else
            {
                response.Say("Thanks for calling!");
            }
            return Content(response.ToString(), "text/xml");
        }
    }
}

    }
}


    //public ActionResult Index(string to)
    //{
    //    var response = new VoiceResponse();
    //    response.Say("Thanks for calling!");

    //    Execute();
    //    return Content(response.ToString(), "text/xml");
    //}

    //[HttpPost]
    //public void Execute() //string numberToCall
    //{
    //    TwilioClient.Init(APIKeys.sID, APIKeys.authToken);
    //    var call = CallResource.Create(
    //        url: new Uri("https://ACad990750b705f73b388ec579ef0a82ba:723839759b7f1707f018d937cb1305c4}@api.twilio.com/2010-04-01/Accounts"),
    //        to: new Twilio.Types.PhoneNumber("14146990466"),
    //        from: new Twilio.Types.PhoneNumber("+12026847384")
    //        );

    //    Console.WriteLine(call.Sid);
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
    //}
}