using Fundraising_Capstone2.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class Callee
    {
        [Key]
        public int CalleeId { get; set; }

        public string phoneNumber { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int zipCode { get; set; }

        public int callCount { get; set; }

        public int answerCount { get; set; }
        
        public decimal gift { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public string giftDate { get; set; }

        public List<string> callHistory { get; set; }

        public List<string> givingHistory { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? lastCallDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? lastCallTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime? nextCallDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime? nextCallTime { get; set; }

        public bool hasResponse { get; set; }
        public IResponse response { get; set; }
        public string calleeDemeanor { get; set; }
        public bool isInterested { get; set; }

    }
}