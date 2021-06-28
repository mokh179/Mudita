using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserCompany
    {

        [Key]
        [Column(Order =0)]
        public int ID { get; set; }

        [Column(Order = 1)]
        [ForeignKey("Company")]
        public int Company_Id { set; get; }

      
        [Column(Order = 2)]
        [ForeignKey("User")]
        public string User_Id { set; get; }

        [Column(Order = 3)]
        [ForeignKey("JobCategory")]
        public int title { get; set; }


        public DateTime from { get; set; }
        public DateTime? to { get; set; }
        public string description { get; set; }
        public Boolean StillWorking { set; get;  }
        public Boolean CanEdit { set; get;  }

        public Company Company { get; set; }
        public User User { get; set; }

        public JobCategory JobCategory { get; set; }
    }
}
