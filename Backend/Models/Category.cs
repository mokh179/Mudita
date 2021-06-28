using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        [Key]
        public int Cat_Id { set; get; }
        public string Cat_Desc { set; get; }
        public List<Company> Companies { set; get; }
        public List<JobCategory> jobCategories { set; get; }
    }
}
