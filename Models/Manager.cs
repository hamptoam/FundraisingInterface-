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

       
        //figure out how to represent visual data 

        //Make Campaign model and controller

    }
}