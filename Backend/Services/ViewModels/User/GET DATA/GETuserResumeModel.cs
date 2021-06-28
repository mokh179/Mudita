using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.User
{
   public class GETuserResumeModel
    {
        public int empuserID { get; set; }
        public string userID { get; set; }
        public string title { get; set; }
        public string company { get; set; }
        public string Description { get; set; }
        public bool status { get; set; }
        public DateTime from { get; set; }
        
        public DateTime To { get; set; }

        public double strength { get; set; }

        public string Message { get; set; }

    }
}
