using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Vacancy
{
   public  class Applied_Vacancy_Model
    {

        [Required]
        public int vacancyID { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public int companyId { get; set; }
       

    }
}
