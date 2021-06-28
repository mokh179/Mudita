using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class userSkills
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User"),Column(Order =1)]
        public string userId { get; set; }
        [ForeignKey("Skills"), Column(Order = 2)]
        public int skillID { get; set; }
        public User User { get; set; }
        public KeySkills Skills { get; set; }

    }
}