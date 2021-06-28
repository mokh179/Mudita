using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobTypeVacancy
    {
        [Key]
        public int Id { get; set; }

        [Column(Order = 1)]
        [ForeignKey("JobType")]
        public int JobTypeId { get; set; }
        [Column(Order = 2)]
        [ForeignKey("Vacancy")]
        public int? Vacancy_Id { get; set; }

        public JobType JobType { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
