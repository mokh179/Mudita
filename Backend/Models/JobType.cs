using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class JobType
    {
        [Key]
        public int Id { get; set; }
        public string  Description { get; set; }

        public List<JobTypeVacancy> jobTypeVacancies { get; set; }

    }
}
