using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwilioMakeAndRecieveCalls;

namespace TwilioMakeAndRecieveCalls.Controllers
{
    public static class Settings
    {

        public static string AccountSid = Environment.GetEnvironmentVariable("ACad990750b705f73b388ec579ef0a82ba");

        public static string AuthToken = Environment.GetEnvironmentVariable("723839759b7f1707f018d937cb1305c4");

        public static string MyOwnNumber = Environment.GetEnvironmentVariable("+2629332309");

        public static string MyTwilioNumber = Environment.GetEnvironmentVariable("+12026847384");

    }

}