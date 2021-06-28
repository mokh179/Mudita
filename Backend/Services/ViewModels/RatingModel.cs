using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class RatingModel
    {


        public double SalRate { set; get; }
        public double WorkEnvironmentRate { set; get; }
        public double ServiceRate { set; get; }
        public double SafetyRate { set; get; }
        public string Rate_Desc { set; get; }
        [Required]
        public int Company_Id { set; get; }
        [Required]
        public string user_Name { set; get; }
    }
}
