using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Vacancy.GET_DATA
{
    public class GETAplicantVacany
    {
        public string name { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CV { get; set; }
        public int status { get; set; }
        public int vacancyID { get; set; }

    }
}
