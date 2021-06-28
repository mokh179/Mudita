using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.User
{
  public  class userEducationModel
    {
        [Required]
        public string userID { get; set; }
        [Required]
        public int TypeOfEducation { get; set; }
        [Required]
        public int university { get; set; }
        public string Message { get; set; }
    }
}
