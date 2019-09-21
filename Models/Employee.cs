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
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public Campaign Campaign { get; set; }

        public string Password { get; set; }

        public List<Callee> CallList { get; set; }

        public Callee callee { get; set; }

        public string outgoingText { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd]", ApplyFormatInEditMode = true)]
        public DateTime HireDate;

        public virtual ICollection<Campaign> Campaigns { get; set; }

        public int DailyCalls { get; set; }

        public int QuantityGifts { get; set; }

        public int WeeklyCalls { get; set; } 

        public int WeeklyQuantityGifts { get; set; }

    }
}