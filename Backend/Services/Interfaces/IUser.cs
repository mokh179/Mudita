using Models;
using Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUser
    {        
        Task<BasicInfoModel> EditBasic(BasicInfoModel data);
        Task<userResumeModel> userResume(userResumeModel data);
        Task<userEducationModel> userEducation(userEducationModel data);
        Task<bool> resetPassword(PassModel pass);
        Task<SkillsModel> userSkills(SkillsModel data);   
        Task<GETBasicInfoModel> GetBasic(string ID);
        Task<GETSkillsModel> GetuserSkills(string ID);
        Task<List<GETuserResumeModel>> GetuserRusme(string ID);
        Task<List<GETuserEducationModel>> GetuserEducation(string ID);
        Task<SocialMedia> userOnlineProfile(SocialMedia data);
        Task<List<SocialMedia>> GetuserOnlineProfile(string id);
        Task<bool> DelUser(string username);
        Task<bool> DeleteEduHistroy(int data);
        Task<bool> DeleteEmpHistroy(int data);
        Task<bool> Deleteonlineprofile(int data);


       }
}
