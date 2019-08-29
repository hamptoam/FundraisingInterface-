using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.AspNet.Mvc;
using Twilio.Rest.Api.V2010.Account;

namespace Fundraising_Capstone.Controllers
{
    public class PhoneController : TwilioController
    {

        public ActionResult Index()
        {
            Execute();
            return View(); 
        }

        [HttpPost]
        public void Execute() //string numberToCall
        {
            TwilioClient.Init(APIKeys.APIKeys.sID, APIKeys.APIKeys.authToken);
            //var result = TwilioClient.(Settings.MyTwilioNumber, number, "http://www.televisiontunes.com/uploads/audio/Star%20Wars%20-%20The%20Imperial%20March.mp3");

            var call = CallResource.Create(
                url: new Uri("https://ACad990750b705f73b388ec579ef0a82ba:723839759b7f1707f018d937cb1305c4}@api.twilio.com/2010-04-01/Accounts"),
                to: new Twilio.Types.PhoneNumber(""),
                from: new Twilio.Types.PhoneNumber("+12026847384")
                );

                Console.WriteLine(call.Sid);
        }

        //    {
        //        return Content(result.RestException.Message);
        //    }

        //    return Content("The call has been initiated");














    }
}