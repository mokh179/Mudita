using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class userEducation
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("User"), Column(Order = 1)]
        public string userID { get; set; }
        [ForeignKey("Company"), Column(Order = 2)]
        public int companyID { get; set; }
        [ForeignKey("TypeOfEducation"), Column(Order = 3)]
        public int type { get; set; }

        public Company  Company{ get; set; }
        public User User { get; set; }

        public typeOfEducation TypeOfEducation { get; set; }
        //public List<userEducation> UserEducations { get; set; }
    }
}
