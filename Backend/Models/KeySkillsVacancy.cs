using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KeySkillsVacancy
    {   
        [Key]
        public int Id { get; set; }

        [Column(Order = 1)]
        [ForeignKey("KeySkills")]
        public int KeySkillId { get; set; }
        [Column(Order = 2)]
        [ForeignKey("Vacancy")]
        public int? VacancyVacancy_Id { get; set; }

        public KeySkills KeySkills { get; set; }
        public Vacancy  Vacancy { get; set; }
    }
}
