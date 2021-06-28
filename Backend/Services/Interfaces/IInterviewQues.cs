using Models;
using Services.ViewModels;
using Services.ViewModels.Interview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IInterviewQues
    {

        Task<List<InterviewQuesModel>> GetAll();
        Task<InterviewQuesModel> Add(InterviewQuesModel Q);
        Task<List<InterviewQuesModel>> GetAllUsrId(string user_Id);
        Task<InterviewQuesModel> GetQuesbyQId( int QId);
        Task<bool> DelQues (int id);
       Task<bool> EditQues(InterviewQuesModel Q);

       

        Task<bool> React(voteModel Obj);

        Task<List<InterviewQuesModel>> GetAllJobCategoy(string JCName);
    }
}
