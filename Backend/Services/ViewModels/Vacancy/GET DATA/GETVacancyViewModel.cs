using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Vacancy
{
    public class GETVacancyViewModel
    {
        public int vacancyID { get; set; }
  
        public string jobTitle { get; set; }

        public int companyId { get; set; }
        public string company { get; set; }
    
        public string Description { get; set; }

        public List<string> jobTypes { get; set; }
    
        public List<string> jobTags { get; set; }

        public DateTime? publishdate { get; set; }
        public string? email { get; set; }
        public bool AppliedState { get; set; }

    }
}
