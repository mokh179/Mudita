using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class locationcompany
    {
        [Key]
        public int ID { get; set; }

        [Column(Order = 1)]
        [ForeignKey("Company")]
        public int companyId { set; get; }


        [Column(Order = 2)]
        [ForeignKey("Country")]
        public int countryId { set; get; }


        [Column(Order = 3)]
        [ForeignKey("City")]
        public int cityId { set; get; }

        public Company Company { get; set; }
        public City City { get; set; }
        public Countries Country { get; set; }
    }
}
