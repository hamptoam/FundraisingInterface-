using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Fundraising_Capstone.APIKeys
{
    public static class APIKeys
    {
        private const string V = "ACad990750b705f73b388ec579ef0a82ba";
        public static string sID = V;

       private const string W = "723839759b7f1707f018d937cb1305c4";
       public static string authToken = W;

        public static string AuthToken { get => authToken; set => authToken = value; }
       
    }
}