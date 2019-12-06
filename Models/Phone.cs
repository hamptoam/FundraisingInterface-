
using Fundraising_Capstone2.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        //public Callee Callee { get; private set; }

        public int CalleeId { get; set; }

        public Employee Employee { get; set; }

        public string outgoingText { get; set; }

        public IResponse Response { get; set; }
    }
}