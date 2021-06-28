using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.User
{
   public class userResumeModel
    {
        [Required]
        public string userID { get; set; }
        [Required]
        public int title { get; set; }
        [Required]
        public int company { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool status { get; set; }
        [Required]
        public DateTime from { get; set; }
        
        public DateTime To { get; set; }

        public double strength { get; set; }

        public string Message { get; set; }

    }
}
