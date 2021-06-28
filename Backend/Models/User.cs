using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User:IdentityUser
    {
        
        public string FName { set; get; }
        public string LName { set; get; }
        public string CV { set; get; }
        public string Image { set; get; }
        public DateTime birthday { get; set; }
        public string summary { get; set; }
        [ForeignKey("JobCategory"),Column(Order =3)]
        public int? title { get; set; }
        [ForeignKey("Country"), Column(Order = 1)]
        public int Country_Id { get; set; }
        [ForeignKey("City"), Column(Order = 2)]
        public int City_Id { get; set; }
        public Company Company { get; set; }
        [Range(0.25,1)]
        public float Strength { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool? IsActive { set; get; }
        public DateTime JoinedDate { get; set; }     
        public List<UserCompany> UserCompanies { get; set; }
        public List<RoleUser> RoleUsers { set; get; }
        public Countries Country { set; get; }
        public City City { set; get; }
        public List<UserQues> UserQuess { set; get; }
        public List<AppliedVacancy> AppliedVacancies { set; get; }
        public List<Rating> Rating { set; get; }
        public JobCategory JobCategory { get; set; }
        public List<userSkills> UserSkills { get; set; }
        public List<userEducation> userEducations { get; set; }
        public List<Onlineprofile> Onlineprofiles { get; set; }
        public List<Reaction> reactions { get; set; }

    }
}
