using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Authentication:IdentityUser
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public string userID { get; set; }
        public string  email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public DateTime Tokenlife { get; set; }
        public bool IsAuthenticated { get; set; }
        public Boolean canEdit { set; get; }
        public float Strength { get; set; }
        public int?  companyId{ get; set; }
        public List<int>  isRelated{ get; set; }

    }
}
