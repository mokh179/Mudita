using Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using Services.ViewModels;
using Services.ViewModels.Interview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class InterviewQuesMoc : IInterviewQues
    {
        private ApiDbContext _db;
       private readonly UserManager<User> _user;
        // UserManager<User> user
        public InterviewQuesMoc(ApiDbContext db, UserManager<User> user)
        {
            _db = db;
           _user = user;
        }
        public async Task<List<InterviewQuesModel>> GetAll()
        {
            var loadAll =await  _db.Questions
                            .Where(a => a.IsActive != false)
                            .Include(a=>a.reactions)
                            .ToListAsync();
        
                var len = loadAll.Count();
                List<InterviewQuesModel> AllQues = new List<InterviewQuesModel>();
                for (int i = 0; i < len; i++)
                {                            
                    var Ques = await  _db.UserQues.FirstOrDefaultAsync(a => a.Ques_Id == loadAll[i].Ques_Id);
                    var jobcat = await _db.JobCategory.FirstOrDefaultAsync(x => x.JobCat_Id == loadAll[i].JobCat_Id);
                    var status = await  _db.Reactions.FirstOrDefaultAsync(a => a.qId==loadAll[i].Ques_Id);
                if (status != null)
                {
                    AllQues.Add(new InterviewQuesModel()
                    {
                        Ques_Desc = loadAll[i].Ques_Desc,
                        NumOfVote = Ques.NumOfVote,
                        Reports = Ques.Reports,
                        CreateOn = loadAll[i].CreateOn,
                        IsActive = loadAll[i].IsActive,
                        JobCat_Desc = jobcat.JobCat_Desc,
                        Ques_Id = loadAll[i].Ques_Id,
                        Like=status.Like,
                        Dislike=status.Dislike,
                        general = true
                    });
                }
                else
                {

                AllQues.Add(new InterviewQuesModel()
                    {
                        Ques_Desc = loadAll[i].Ques_Desc,
                        NumOfVote = Ques.NumOfVote,
                        Reports = Ques.Reports,
                        CreateOn = loadAll[i].CreateOn,
                        IsActive = loadAll[i].IsActive,
                        JobCat_Desc = jobcat.JobCat_Desc,
                        Ques_Id=loadAll[i].Ques_Id,
                        general=false
                });
                }
            }
            return AllQues;
        }

        public async Task<InterviewQuesModel> Add(InterviewQuesModel Q)
        {
            
            int QId = _db.Questions.ToList().Count() > 0 ? _db.UserQues.Max(x => x.Ques_Id) + 1 : 1;
            var JobCatName = await _db.JobCategory.FirstOrDefaultAsync(x => x.JobCat_Desc == Q.JobCat_Desc);
            var JobCatId = await _db.JobCategory.Where(a => a.JobCat_Id == JobCatName.JobCat_Id).Select(a => a.JobCat_Id).FirstOrDefaultAsync();
            var ques = new Questions()
            {
                Ques_Id = QId,
                Ques_Desc = Q.Ques_Desc,
                CreateOn = DateTime.Now,
                JobCat_Id= JobCatId,
                IsActive =true,
            };
            _db.Questions.Add(ques);
            int userQID = _db.UserQues.ToList().Count() > 0 ? _db.UserQues.Max(x => x.userQues_Id) + 1 : 1;
            var user = await _db.User.FirstOrDefaultAsync(x => x.UserName == Q.Username);
            var userQ = new UserQues()
            {
                Ques_Id=ques.Ques_Id,
                User_Id= user.Id,
                userQues_Id= userQID,
                NumOfVote =0,
                Reports=0
            };
            _db.UserQues.Add(userQ);
            _db.SaveChanges();
            return Q;
        }
  
        public async Task<List<InterviewQuesModel>> GetAllUsrId(string username)
        {
            var user = await _user.FindByNameAsync(username);
            var loadAll = await _db.UserQues
                .Where(a => a.User_Id == user.Id && a.Question.IsActive).Include(a=>a.Question)
                .ToListAsync();
            var len = loadAll.Count();
            List<InterviewQuesModel> AllQues = new List<InterviewQuesModel>();
            for (int i = 0; i < len; i++)
            {
                var jobcat = await _db.JobCategory.FirstOrDefaultAsync(x => x.JobCat_Id == loadAll[i].Question.JobCat_Id);
                AllQues.Add(new InterviewQuesModel()
                {
                    Ques_Id = loadAll[i].Ques_Id,
                    Username = user.UserName,
                    JobCat_Id = loadAll[i].Question.JobCat_Id,
                    Ques_Desc = loadAll[i].Question.Ques_Desc,
                    NumOfVote = loadAll[i].NumOfVote,
                    Reports = loadAll[i].Reports,
                    CreateOn = loadAll[i].Question.CreateOn,
                    IsActive = loadAll[i].Question.IsActive,
                    JobCat_Desc = jobcat.JobCat_Desc
                });
            }

          return AllQues;
        }

        public async Task<List<InterviewQuesModel>> GetAllJobCategoy(string  JCName)
        {
            if(JCName!=null)
            {
            var loadAll = await _db.Questions
                .Where(a => a.JobCat.JobCat_Desc.Contains(JCName) && a.IsActive || a.JobCat.JobCat_Desc == JCName)
                .ToListAsync();
                var len = loadAll.Count();           
                List< InterviewQuesModel > AllQues = new List<InterviewQuesModel>();
            for (int i = 0; i < len; i++)
            {
                var Ques = await _db.UserQues.FirstOrDefaultAsync(a => a.Ques_Id == loadAll[i].Ques_Id);
                var JobCatDesc = await _db.JobCategory.Where(a => a.JobCat_Id == loadAll[i].JobCat_Id).Select(a => a.JobCat_Desc).FirstOrDefaultAsync();


                    AllQues.Add(new InterviewQuesModel()
                {
                    Ques_Desc = loadAll[i].Ques_Desc,
                    NumOfVote = Ques.NumOfVote,
                    Reports = Ques.Reports,
                    CreateOn = loadAll[i].CreateOn,
                    IsActive = loadAll[i].IsActive,
                    JobCat_Desc = JobCatDesc,
                });

              }
                return AllQues;
            }
        

            else {
                var All = await GetAll();
                return All; 
        }


    }
        public async Task<InterviewQuesModel> GetQuesbyQId( int QId)
        {


            var load = await _db.UserQues.Include(a => a.Question).FirstOrDefaultAsync(a => a.Question.IsActive && a.Question.Ques_Id == QId);
            var jobcat = await _db.JobCategory.FirstOrDefaultAsync(x => x.JobCat_Id == load.Question.JobCat_Id);

          

            InterviewQuesModel InterviewQ = new InterviewQuesModel()
            {
                Ques_Desc = load.Question.Ques_Desc,
                NumOfVote = load.NumOfVote,
                Reports = load.Reports,
                CreateOn = load.Question.CreateOn,
                IsActive = load.Question.IsActive,
                JobCat_Desc= jobcat.JobCat_Desc
            };

            return InterviewQ;
        }

        public async Task<bool> DelQues(int id)
        {
            var getques =await  _db.Questions.FirstOrDefaultAsync(m => m.Ques_Id == id);
            getques.IsActive = false;
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> React(voteModel Obj)
        {
            bool res = false;
            var user = await _user.FindByNameAsync(Obj.username);
            var question = await _db.UserQues.FirstOrDefaultAsync(m => m.Ques_Id == Obj.Ques_Id);

            if (await _db.Reactions.Where(x => x.userId == user.Id && x.qId == Obj.Ques_Id).FirstOrDefaultAsync() == null)
            {
                Reaction reaction=new Reaction();
                if (Obj.Like)
                {
                    question.NumOfVote += 1;
                     reaction = new Reaction()
                    {
                        qId = Obj.Ques_Id,
                        userId = user.Id,
                        Like = Obj.Like,
                        Dislike=!Obj.Like
                    };
                }

                else if(Obj.Dislike)
                {
                    question.Reports += 1;
                     reaction = new Reaction()
                    {
                        qId = Obj.Ques_Id,
                        userId = user.Id,
                        Like = !Obj.Dislike,
                        Dislike = Obj.Dislike
                    };
                }
                _db.Reactions.Add(reaction);
            }
            else
            {
                var userReact = await _db.Reactions.Where(x => x.userId == user.Id && x.qId == Obj.Ques_Id).FirstOrDefaultAsync();
                if (Obj.Dislike)
                {
                    question.Reports += 1;
                    question.NumOfVote -= 1;
                    userReact.Dislike = Obj.Dislike;
                    userReact.Like = !Obj.Dislike;
                }
                else if(Obj.Like)
                {
                    question.Reports -= 1;
                    question.NumOfVote += 1;
                    userReact.Like = Obj.Like;
                    userReact.Dislike = !Obj.Like;
                }
            }
            try
            {
                _db.SaveChanges();
                return res=true;
            }
            catch (Exception ex)
            {
                string txt = ex.Message;
            }
            return res;
        }

        public async Task<bool> EditQues(InterviewQuesModel Q)
        {
            var user = await _user.FindByNameAsync(Q.Username);
            if(_db.UserQues.FirstOrDefault(a=>a.User_Id==user.Id&&a.Ques_Id==Q.Ques_Id)!=null)
            {
                var getques = await _db.Questions.FirstOrDefaultAsync(m => m.Ques_Id == Q.Ques_Id);
                getques.Ques_Desc = Q.Ques_Desc;
                getques.JobCat_Id = Q.JobCat_Id;
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
 