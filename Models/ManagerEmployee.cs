using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class ManagerEmployee
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

    }
}