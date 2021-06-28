using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public class CompanyModel
    {
        [Required]
        public string CompanyName { set; get; }
        [Required]
        public string Phone { set; get; }
        //[RegularExpression("^\\+[0-9]{1,3}-[0-9]{3}-[0-9]{7}$", ErrorMessage = "Enter right format of fax {+123-567-1234567}")]
        public string Fax { set; get; }
        public string Website { set; get; }
        [Display(Name ="Working Category"),Required]
        public int Category_Id { set; get; }
       
        [Display(Name = "Manager"), Required]
        public string Manager_Id { set; get; }
        public string Message { get; set; }

        public List<int> CityID { get; set; }
        public List<int> CountryID { get; set; }
        public int CompanyID { get; set; }
    }
}
