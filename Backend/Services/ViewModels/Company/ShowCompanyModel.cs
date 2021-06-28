using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
   public class ShowCompanyModel
    {
        public string ManagerID { set; get; }
        public string CompanyName { set; get; }
        public string Phone { set; get; }
        public string Fax { set; get; }
        public string Website { set; get; }
        public string Category { set; get; }
        public int CategoryID { set; get; }
        public List<string> Countries { set; get; }
        public List<int> CountriesID { set; get; }
        public List<string> Citis { set; get; }
        public List<int> CitisID { set; get; }
        public string Manager { set; get; }
        public  double? OverAllRate { set; get; }
        public double? SalRate { set; get; }
        public double? WorkEnvironmentRate { set; get; }
        public double? ServiceRate { set; get; }
        public double? SafetyRate { set; get; }
        public List<string> Reviews { set; get; }
        public string LinkedProfile { get; set; }
        public string faceProfile { get; set; }
        public DateTime? foundedDate { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public string Message { get; set; }
    }
}
