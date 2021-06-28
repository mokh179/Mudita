using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels.Interview
{
    public class voteModel
    {
        public int Ques_Id { get; set; }
        public string username { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
    }
}
