using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Admin
{
   public class AdminCountryModel
    {
        public int country_id { get; set; }
        public string Country_Name { get; set; }
        public string Sort_Name { get; set; }
        public int Phone_code { get; set; }
    }
}
