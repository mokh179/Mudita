using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ques_Id { set; get; }
        public string Ques_Desc { set; get; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }

        [ForeignKey("JobCat"),Column(Order = 1)]
        public int JobCat_Id { get; set; }

        //UserQues
        public List<UserQues> UserQuess { set; get; }
        //JobCat
        public JobCategory JobCat { get; set; }
        public List<Reaction> reactions { get; set; }
    }
}
