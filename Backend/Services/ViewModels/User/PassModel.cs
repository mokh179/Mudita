using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.User
{
   public class PassModel
    {
        [Required]
        public string userID { get; set; }
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm password"), Compare("NewPassword", ErrorMessage = "Password must be match the New password")]
        public string ConfirmPassword { get; set; }
    }
}
