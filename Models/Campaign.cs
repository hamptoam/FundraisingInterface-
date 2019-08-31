using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }

        public List<Callee> Leads { get; set; }

        public List<Employee> assignedCallers { get; set; }

        public Manager campaignManager { get; set; }

        public Decimal dailyFunds { get; set; }

        public Decimal weeklyFunds { get; set; }

        public Decimal monthlyFunds { get; set; }

        public Decimal yearlyFunds { get; set; }

    }
}