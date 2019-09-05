using Faker;
using Faker.Extensions;
using Fundraising_Capstone2.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.Jwt;
using Twilio.Jwt.Client;

namespace ClientQuickstart.Controllers
{ 
    public class TokenController : Controller
    {   
        public ActionResult Index()
        {

            string V = APIKeys.sID;
            string W = APIKeys.authToken;
            string X = APIKeys.appSID;

            var scopes = new HashSet<IScope>
            {
                new OutgoingClientScope(X),
                new IncomingClientScope("")
            };

            var capability = new ClientCapability(V, W, scopes: scopes);

            return Content(capability.ToJwt(), "application/jwt");

          //  var identity = Internet.UserName().AlphanumericOnly();

          //  var scopes = new HashSet<IScope>
          //{
          //      {  new IncomingClientScope(identity) },
          //      { new OutgoingClientScope(X) }
          //};


          //  var capability = new ClientCapability(V, W, scopes: scopes);
          //  var token = capability.ToJwt();

          //  return Json(new
          //  {
          //      identity,
          //      token
          //  }, JsonRequestBehavior.AllowGet);

          //    return Content(capability.ToJwt(), "application/jwt");
        }
    }
}