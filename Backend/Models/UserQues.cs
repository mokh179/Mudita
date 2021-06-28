using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserQues
    {
        [Key]
        public int userQues_Id { get; set; }

        [Column(Order = 1)]
        [ForeignKey("Question")]
        public int Ques_Id { set; get; }

        [Column(Order = 2)]
        [ForeignKey("User")]
        public string User_Id { set; get; }
        public int NumOfVote { set; get; }
        public int Reports { set; get; }
        public Questions Question { set; get; }
        public User User { set; get; }

    }
}
