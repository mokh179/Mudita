using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Countries
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int country_id { get; set; }
        public string Sort_Name { get; set; }
        public string Country_Name { get; set; }
        public int Phone_code { get; set; }
        public List<City> City { set; get; }
        public List<User> Users { set; get; }
 
        public List<locationcompany> CompanyLocations { set; get; }
    }

}
