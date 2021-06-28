using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public   class Onlineprofile
    {
        [Key]
        public int ID { get; set; }
        public string URL { get; set; }

        [ForeignKey("User")]
        public string userID { get; set; }

        public User User { get; set; }


    }
}
