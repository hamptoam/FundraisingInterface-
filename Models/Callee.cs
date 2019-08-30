using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone.Models
{
    public class Callee
    {
        [Key]
        public int phoneNumber { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set;  }

        public string Address { get; set; }

        public int callCount { get; set; }

        public int answerCount { get; set; }

        public List<string> callHistory { get; set;}

        public List<string> givingHistory { get; set; }

        //add more as they come up

    }
}