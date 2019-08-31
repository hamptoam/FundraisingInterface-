using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.Jwt;
using Twilio.Jwt.Client;

namespace Fundraising_Capstone.Controllers
{
    public class TokenController : PhoneController
    { 
        public ActionResult Index()
        {
          const string accountSid = "ACad990750b705f73b388ec579ef0a82ba";
          const string authToken = "723839759b7f1707f018d937cb1305c4";

          const string appSid = "APc1ed9c9b38d243d2f1839175c3451390";


          var scopes = new HashSet<IScope>
          {
             new OutgoingClientScope(appSid)
          };


            var capability = new ClientCapability(accountSid, authToken, scopes: scopes);

            return Content(capability.ToJwt(), "application/jwt");
        }
    }
}