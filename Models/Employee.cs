using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class Employee
    {
        public Employee()
        {

            this.Campaigns = new HashSet<Campaign>();
        }


        [Key]
        public int employeeId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string userName { get; set; }

        public string passWord { get; set; }

        public List<Callee> callList { get; set; }

        public Callee callee { get; set; }

        public Decimal dailyFunds { get; set; }

        public Decimal weeklyFunds { get; set; }

        public Decimal monthlyFunds { get; set; }

        public Decimal quarterlyFunds { get; set; }

        public Decimal yearlyFunds { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }

    }
}