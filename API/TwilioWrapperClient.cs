using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Fundraising_Capstone2.Keys;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio.TwiML.Voice;

namespace Fundraising_Capstone2.API
{
    public class TwilioWrapperClient : IClient
    {

        private readonly string sID, authToken;
        ///<summary>
        /// the authentication items
        ///</summary>

        public TwilioWrapperClient(string sID, string authToken)
        {
            APIKeys.sID = sID;
            APIKeys.authToken = authToken; 
        }

        public bool CanCall { get { return true; } }

        public bool CanSendSms { get { return true; } }

        public bool FromNumberRequired { get { return true; } }

        public bool IsInitialized { get; set; }

        public void Init()
        {
            TwilioClient.Init(sID, authToken);

            IsInitialized = true;
        }

        public void Dial()
        {
            var response = new VoiceResponse();
            var dial = new Dial(callerId: "414");
            dial.Number("");
            response.Append(dial);

         //   CallAsync(pnFrom, pnTo, msg);

            Console.WriteLine(response.ToString());
        }

        public async Task<IResponse> CallAsync(string from, string to, string msg)
        {
            var pnFrom = new PhoneNumber(from);
            var pnTo = new PhoneNumber(to);

            var body = WebUtility.UrlEncode(msg);

            var call = await CallResource.CreateAsync(
                pnTo,
                pnFrom,
                url: new Uri($"http://www.rokurocket.com/twilio_call_ext_server/twilio-phone-dialer-servr/voice.php")); //requesturl

            return new CallResponse(call);

}

        public async Task<IResponse> SendSmsAsync(string from, string to, string msg)
        {
            var pnFrom = new PhoneNumber(from);
            var pnTo = new PhoneNumber(to);

            var text = await MessageResource.CreateAsync(

               pnTo,
               from: pnFrom,
               body: msg);

            return new TextResponse(text);
        }
        public override string ToString()
        {
            return "Twilio API";
        }

        public class CallResponse : IResponse
        {
            private string SID;

            public bool CanUpdate { get { return true; } }

            public string Status { get; set; }

            public CallResponse(CallResource call)
            {
                SetCall(call);
            }

            private void SetCall(CallResource call)
            {
                SID = call.Sid;
                Status = call.Status.ToString();
            }

            public async System.Threading.Tasks.Task UpdateAsync()
            {
                var call = await CallResource.FetchAsync(SID);
                SetCall(call);
            }
        }

        public class TextResponse : IResponse
        {
            public static string V = APIKeys.sID;
            public bool CanUpdate { get { return true; } }

            public string Status { get; set; }

            public TextResponse(MessageResource call)
            {
                SetMessage(call);
            }

            private void SetMessage(MessageResource call)
            {
                //sid
                Status = call.Status.ToString();
            }

            public async System.Threading.Tasks.Task UpdateAsync()
            {
                var call = await MessageResource.FetchAsync(APIKeys.sID);

                SetMessage(call);
            }

            
        }
    }
}
