using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fundraising_Capstone2.Models
{
    public class Funds 
    {
        [Key]
        public int FundId { get; set; }

        public Double DailyFunds { get; set; }

        public Double WeeklyFunds { get; set; }

        public Double MonthlyFunds { get; set; }

        public Double QuarterlyFunds { get; set; }

        public Double YearlyFunds { get; set; }

    }
}