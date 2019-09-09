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

namespace Fundraising_Capstone2.API
{
    public class TwilioWrapperClient : IClient
    {
        ///<summary>
        /// the authentication items
        ///</summary>
        private readonly String(//sid, authtoken)

        public TwilioWrapperClient(string sid, string auth)
        {
            // put keys in here fix ^^
        }

        bool CanCall { get { return true; } }

        public bool CanSendSms { get { return true; } }

        public bool FromNumberRequired { get { return true; } }

        public bool IsInitialized { get; set; }

        public void Init()
        {
            TwilioClient.Init() //keys


            IsInitialized = true;
        }

        public async Task<IResponse> CallAsync(string from, string to, string msg)
        {
            var pnFrom = new PhoneNumber(from);
            var pnTo = new PhoneNumber(to);

            var body = WebUtility.UrlEncode(msg);

            var call = await CallResource.CreateAsync(
                pnTo,
                pnFrom,
                url: new Uri()); //requesturl

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
            // private string sid

            public bool CanUpdate { get { return true; } }

            public string Status { get; set; }

            public CallResponse(CallResourse call)
            {
                SetCall(call);
            }

            private void SetCall(CallResource call)
            {
                // sid call.sid
                Status = call.Status.ToString();
            }

            public async Task UpdateAsync()
            {
                var call = await CallResource.FetchAsync()//sid)
                SetCall(call);
            }
        }

        public class TextResponse : IResponse
        {
            // private string sid

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

            public async Task UpdateAsync()
            {
                var call = await MessageResource.FetchAsync();

                SetMessage(call);
            }
        }
    }
}
