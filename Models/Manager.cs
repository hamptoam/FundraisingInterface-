using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class Manager
    {

        [Key]
        public int ManagerId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public List<Employee> Employees { get; set; }

        public List<Callee> Leads { get; set; }

        public List<Campaign> Campaigns { get; set; }

        public Decimal totalWeeklyFunds { get; set; }

        public Decimal totalMonthlyFunds { get; set; }

        public Decimal totalQuarterlyFunds { get; set; }

        public Decimal totalYearlyFunds { get; set; }

        public Decimal weeklyCampaignFunds { get; set; }

        public Decimal totalDailyFunds { get; set; }

        public Decimal dailyCampaignFunds { get; set; }

        public Decimal dailyEmployeeFunds { get; set; }

        public Decimal weeklyEmployeeFunds { get; set; }

        public Decimal weeklyFunds { get; set; }

        public Decimal monthlyFunds { get; set; }

        public Decimal quarterlyFunds { get; set; }

        public Decimal yearlyFunds { get; set; }

        //figure out how to represent visual data 

        //Make Campaign model and controller

    }
}