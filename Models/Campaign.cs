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

        public string CampaignName { get; set; }
 
       // public List<Employee> assignedCallers { get; set; 
        public virtual ICollection<Employee> Employees { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public string campaignStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public string campaignEndDate { get; set; }

    }
}