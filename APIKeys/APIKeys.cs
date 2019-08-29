using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Fundraising_Capstone.APIKeys
{
    public class APIKeys
    {
        private const string V = "ACad990750b705f73b388ec579ef0a82ba";
        public static string sID = V;

        private const string W = "723839759b7f1707f018d937cb1305c4";
        private static string authToken = W;

        public static string AuthToken { get => authToken; set => authToken = value; }
        public void Execute()
        {
            TwilioClient.Init(V, W);

            var call = CallResource.Create(
                url: new Uri("https://ACad990750b705f73b388ec579ef0a82ba:723839759b7f1707f018d937cb1305c4}@api.twilio.com/2010-04-01/Accounts"),
                to: new Twilio.Types.PhoneNumber(""),
                from: new Twilio.Types.PhoneNumber("+12026847384")
                );

            Console.WriteLine(call.Sid);
        }
    }
}