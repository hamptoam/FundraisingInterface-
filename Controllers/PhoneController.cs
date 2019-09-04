using Fundraising_Capstone.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.TwiML.Voice;

namespace Fundraising_Capstone.Controllers
{
    public class PhoneController : TwilioController
    {

        public ActionResult Index()
        {
            var response = new VoiceResponse();
            response.Say("Thanks for calling!");

            Execute();
            return Content(response.ToString(), "text/xml"); 
        }

        [HttpPost]
        public void Execute() //string numberToCall
        {
            TwilioClient.Init(APIKeys.sID, APIKeys.authToken);
            var call = CallResource.Create(
                url: new Uri("https://ACad990750b705f73b388ec579ef0a82ba:723839759b7f1707f018d937cb1305c4}@api.twilio.com/2010-04-01/Accounts"),
                to: new Twilio.Types.PhoneNumber("14146990466"),
                from: new Twilio.Types.PhoneNumber("+12026847384")
                );

                Console.WriteLine(call.Sid);
        }

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
}