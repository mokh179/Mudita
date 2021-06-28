using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
   public class InterviewQuesModel
    {
        public int? Ques_Id { set; get; }
        public int JobCat_Id { get; set; }
        public string JobCat_Desc { set; get; }
        public string Ques_Desc { set; get; }
        public string Username { set; get; }
        public int? NumOfVote { set; get; }
        public int? Reports { set; get; }
        public bool IsActive { get; set; }
        public DateTime CreateOn { get; set; }
        public bool?  Like { set; get; }
        public bool? Dislike { set; get; }
        public bool general { set; get; }
    }
}
