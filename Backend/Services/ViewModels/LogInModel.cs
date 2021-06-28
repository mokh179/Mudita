using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class LogInModel
    {
        [Required, MaxLength(120),Display(Name ="Enter Username or Email")]
        public string Username { get; set; }
       
        [Required, MaxLength(256)]
        public string Password { get; set; }

    }
}
