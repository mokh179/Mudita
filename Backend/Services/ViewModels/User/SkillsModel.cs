using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.User
{
    public class SkillsModel
    {
        [Required]
        public string userID { get; set; }
        public List<int> Skills { get; set; }

        public string Message { get; set; }

    }
}
