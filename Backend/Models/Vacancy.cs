using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vacancy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Vacancy_Id { set; get; }
        public string Vacancy_Desc { set; get; }
        [ForeignKey("JobCategory")]
        public int JobCat_Id { set; get; }
        public JobCategory JobCategory { set; get; }

        public bool IsActive { get; set; }
        public List<CompanyVacany> CompanyVacanies { set; get; }
        public List<AppliedVacancy> AppliedVacancies { set; get; }
         public List<KeySkillsVacancy> KeySkillsVacancies { get; set; }
         public List<JobTypeVacancy> jobTypeVacancies { get; set; }

    }
}
