using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Company
    {
        [Key]
         public int Company_Id { set; get; }
        public string CompanyName { set; get; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { set; get; }
        [RegularExpression("^\\+[0-9]{1,3}-[0-9]{3}-[0-9]{7}$",ErrorMessage ="Enter right format of fax {+123-567-1234567}")]
        public string Fax { set; get; }
        public string Website { set; get; }
        public string Description { get; set; }
        public DateTime? FoundedDate { get; set; }
        public string Email { get; set; }
        public string FaceProfile { get; set; }
        public string LinkedProfile { get; set; }
        public string Image { get; set; }





        [ForeignKey("Category")]
        public int Category_Id { set; get; }
        [ForeignKey("User")]
        public string Manager_Id { set; get; } 
        public bool IsActive { set; get; }
        public User User { get; set; }
        public List<CompanyVacany> CompanyVacanies { set; get; }
        public List<AppliedVacancy> AppliedVacancies { set; get; }
        public Category Category { set; get; }

        public List<Rating> Rating { set; get; }
        public List<locationcompany> companyLocations { get; set; }
        //public List<CompanyCountry> CompanyCountries { get; set; }
        //public List<CompanyCity> CompanyCities { get; set; }
        public List<UserCompany> UserCompanies { get; set; }

       // public List<CompanyQues> CompanyQues { get; set; }
    }
}
