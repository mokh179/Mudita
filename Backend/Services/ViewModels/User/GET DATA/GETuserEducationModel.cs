using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.User
{
  public class GETuserEducationModel
  {

        public string userID { get; set; }
        public int eduuserID { get; set; }
        public string TypeOfEducation { get; set; }

        public string university { get; set; }
        public string Message { get; set; }
  }
}
