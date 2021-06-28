using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Admin
{
   public class AdminUserModel
    {
        public string User_Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Country_Id { get; set; }
        public string Country_Name { get; set; }
        public string Gender { get; set; }

    }
}
