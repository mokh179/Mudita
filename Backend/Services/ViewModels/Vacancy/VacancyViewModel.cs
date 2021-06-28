using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Vacancy
{
    public class VacancyViewModel
    {
        
        public int? vacancyID { get; set; }
        [Required]
        public int jobTitle { get; set; }
        [Required]
        public int company { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<int> jobTypes { get; set; }
        [Required]
        public List<int> jobTags { get; set; }

    }
}
