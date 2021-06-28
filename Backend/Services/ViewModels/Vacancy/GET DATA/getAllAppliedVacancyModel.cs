using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Vacancy.GET_DATA
{
   public class getAllAppliedVacancyModel
    {
        public string state { get; set; }
        public string title { get; set; }
        public string companyName { get; set; }
        public string description { get; set; }
        public DateTime? AppliedDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public int NoApplicants { get; set; }
        public int NoViewed { get; set; }
        public int Noselected{ get; set; }
        public int NoRejected { get; set; }
        public string CompanyImage { get; set; }
        public bool VacancyState { get; set; }
        public int vacancyId { get; set; }

    }
}
