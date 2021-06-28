using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CompanyVacany
    {

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Company")]
        public int Company_Id { set; get; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Vacancy")]
        public int Vacancy_Id { set; get; }
        [DataType(DataType.Date)]
        public DateTime? PublishDate { set; get; }
        public Company Company { set; get; }
        public Vacancy Vacancy { set; get; }

    }
}
