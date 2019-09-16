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

        public Decimal DailyFunds { get; set; }

        public Decimal WeeklyFunds { get; set; }

        public Decimal MonthlyFunds { get; set; }

        public Decimal QuarterlyFunds { get; set; }

        public Decimal YearlyFunds { get; set; }

    }
}