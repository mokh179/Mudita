using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.User
{
    public class BasicInfoModel
    {
        [Required]
        public string userID { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }
        
        public int? titleId { get; set; }
        public string title { get; set; }
       
        public string city { get; set; }
        public int cityId { get; set; }
       
        public int countryId { get; set; }
        
        public string summary { get; set; }
        [Required]
        public string email { get; set; }
    
        public DateTime birthdate { get; set; }
      
        public string phone { get; set; }

        public string image { get; set; }
        public string Address { get; set; }
        public float strength { get; set; }

        public string Message { get; set; }

    }
}
