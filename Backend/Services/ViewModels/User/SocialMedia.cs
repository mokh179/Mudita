using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.User
{
    public class SocialMedia
    {
        [Required]
        public string URL { get; set; }
        [Required]
        public string userID { get; set; }

        public int onlineID { get; set; }

        public string Message { get; set; }
    }
}
