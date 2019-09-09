using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fundraising_Capstone2.API
{
    public interface IClient
    {
        /// <summary>
        /// indicates if the client is intialized or not 
        /// use <see cref= "Init"/> to initialize the client 
        /// </summary>

        bool IsInitialized { get; set; }

        /// <summary>
        /// Indicates if the client supports sending text messages 
        /// </summary>summary>
         bool CanSendSms { get;}

        /// <summary>
        /// Indicates if the client supports calls 
        /// </summary>
        bool CanCall { get; }

        /// <summary> 
        //Indicates if the from number is required 
        /// </summary>
        bool FromNumberRequired { get; }

        ///<summary>
        ///Initializes and marks the client as <see cref="IsInitialized"/>
        ///</summary>
        void Init();

        ///<summary>
        /// Calls the number asynchronously 
        /// </summary>
        /// <param name="from"> The from number can be optional <seee cref="FromNumberRequired"/></param>
        /// <param name="To">The number to call</param>
        /// <param name="msg"></param>
        /// <returns>The response</returns>
        Task<IResponse> CallAsync(string from, string to, string msg);

        ///<summary>
        /// The client name
        /// </summary>
        string ToString();
    }
}