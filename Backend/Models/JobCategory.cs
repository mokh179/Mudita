using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JobCategory
    {
        [Key]
        public int JobCat_Id { set; get; }
        public string JobCat_Desc { set; get; }

        public List<Vacancy> Vacancies { set; get; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public Category Category { get; set; }
         public List<User> Users { get; set; }

        public List<Questions> Questions { get; set; }

    }
}
