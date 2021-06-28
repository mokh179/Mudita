using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class KeySkills
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }

        public List<userSkills> UserSkills { get; set; }
        public List<KeySkillsVacancy> KeySkillsVacancies { get; set; }
    }
}
