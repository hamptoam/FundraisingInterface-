using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class Campaign
    {

        public Campaign()
        {
            this.Employees = new HashSet<Employee>();
        }


        [Key]
        public int CampaignId { get; set; }

        public List<Callee> Leads { get; set; }
    
       // public List<Employee> assignedCallers { get; set; }

        public List<Callee> callees { get; set; }

        public Manager campaignManager { get; set; }

        public Decimal dailyFunds { get; set; }

        public Decimal weeklyFunds { get; set; }

        public Decimal monthlyFunds { get; set; }

        public Decimal yearlyFunds { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}