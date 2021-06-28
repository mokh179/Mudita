using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Company
{
  public  class AllCompanyDataModel
    {
        public int companyID { get; set; }
        public double overAllRate  { get; set; }
        public string companyName { get; set; }
        public string categoryName { get; set; }
        public string  img{ get; set; }
        public int Category_Id { set; get; }
        public string City_Name { get; set; }

    }
}
