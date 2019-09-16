using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class CalleeFunds
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Callee")]
        public int CalleeId { get; set; }
        public Callee Callee { get; set; }

        [ForeignKey("Funds")]
        public int FundId { get; set; }
        public Funds Funds { get; set; }

    }
}