using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Company
{
    public class LocationModel
    {
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public int CityID { get; set; }
        [Required]
        public int CountryID { get; set; }
        public string  Message { get; set; }
    }
}
