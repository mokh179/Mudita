using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rating
    {
        [Key]
        public int Rate_Id { set; get; }
        public string Rate_Desc { set; get; }
        public double SalRate { set; get; }
        public double WorkEnvironmentRate { set; get; }
        public double ServiceRate { set; get; }
        public double SafetyRate { set; get; }
        public double OverAllRate { set; get; }






        [ForeignKey("Company")]
        public int Company_Id { set; get; }
        [ForeignKey("User")]
        public string User_Id { set; get; }
        public Company Company { set; get; }
        public User User { set; get; }
    }
}
