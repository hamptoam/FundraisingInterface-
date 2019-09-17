using Fundraising_Capstone2.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class Text : Phone 
    {
        public int Id { get; set; }

        public Callee Callee { get; set; }

        public Employee Employee { get; set; }

        public IResponse Response { get; set; }

    }
}