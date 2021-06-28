using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Vacancy.GET_DATA
{
   public  class GetAllJobsforCompanyModel
    {
        public int VacancyId { get; set; }
        public int NoApplicants { get; set; }
        public int NoViewed { get; set; }
        public int Noselected { get; set; }
        public int NoRejected { get; set; }
        public bool VacancyState { get; set; }
        public DateTime? PublishDate { get; set; }
        public  string title { get; set; }

    }
}
