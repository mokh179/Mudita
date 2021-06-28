using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoleUser
    {

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Role")]
        public string Role_Id { set; get; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string User_Id { set; get; }
        public User User { set; get; }
        public Role Role { set; get; }


    }
}
