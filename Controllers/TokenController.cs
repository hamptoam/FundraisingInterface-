using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fundraising_Capstone.Keys;
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
             new OutgoingClientScope(X)
          };


            var capability = new ClientCapability(V, W, scopes: scopes);

            return Content(capability.ToJwt(), "application/jwt");
        }
    }
}