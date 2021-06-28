using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Admin
{
   public class AdminCityModel 
    {
        public int City_Id { set; get; }
        [Required]
        public string City_Name { get; set; }

        public int country_id { get; set; }
    }
}
