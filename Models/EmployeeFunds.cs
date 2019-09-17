using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class EmployeeFunds
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Funds")]
        public int FundId { get; set; }
        public Funds Funds { get; set; }
    }
}