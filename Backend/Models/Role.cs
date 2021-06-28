using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role:IdentityRole
    {
        /*[Key]
        public int Role_Id { set; get; }*/
        public string Description { set; get; }
        public List<RoleUser> RoleUsers { set; get; }
    }
}
