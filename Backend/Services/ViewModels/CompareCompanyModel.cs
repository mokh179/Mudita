using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
     public class CompareCompanyModel
    {
        public double Totalsalary { set; get; }
        public string CompanyName { set; get; }
        public int votecount { set; get; }
        public double TotalWorkingEnvironment {set; get;}
        public double TotalService { set; get;}
        public double TotalSafety {set; get;}
        public double OverAllRate {set; get;}
        public int CompanyID { set; get; }
        
    }
}
