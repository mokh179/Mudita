 using Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserMoc : IUser
    {
        private ApiDbContext _db;
        private readonly UserManager<User> _user;
        public UserMoc(ApiDbContext db, UserManager<User> user)
        {
            _db = db;
            _user = user;
        }

        public async Task<GETBasicInfoModel> GetBasic(string ID)
        {
            var user = await _user.FindByNameAsync(ID);
            if (user == null)
                return new GETBasicInfoModel() { Message = "Sorry this Email existed " };
            else
            {
                JobCategory userTitle; 
                Category userTitleCategory;
                    userTitle = _db.JobCategory.Include(x=>x.Category).FirstOrDefault(x => x.JobCat_Id == user.title);
                if(userTitle != null)
                {
                    userTitleCategory = _db.Category.FirstOrDefault(x => x.Cat_Id == userTitle.CategoryID);
                }
                else
                {
                    userTitle = new JobCategory();
                    userTitle.JobCat_Desc = "";
                    userTitleCategory = new Category();
                    userTitleCategory.Cat_Desc = "";
                }
                    var userCity = _db.City.FirstOrDefault(x => x.City_Id == user.City_Id);
                    var usercountry = _db.Countries.FirstOrDefault(x => x.country_id == user.Country_Id);
                try
                {
                    
                    var data = new GETBasicInfoModel()
                    {
                        userID = ID,
                        title = $"{ userTitle.JobCat_Desc} , { userTitleCategory.Cat_Desc}",
                        summary = user.summary,
                        city = userCity.City_Name,
                        country = usercountry.Country_Name,
                        cityId=user.City_Id,
                        countryId=usercountry.country_id,
                        birthdate = user.birthday,
                        titleId=userTitle==null?1:userTitle.JobCat_Id,
                        CategoryId= userTitle == null ? 1 : userTitle.CategoryID,
                        email = user.Email,
                        phone = user.PhoneNumber,
                        fname = user.FName,
                        lname = user.LName,
                        image = user.Image,
                        strength = user.Strength,
                        Address = user.Address,
                        Message = "Successed"
                    };
                    return data;
                }
                catch (Exception ex)
                {
                    return new GETBasicInfoModel() { Message = "An error Occured During Processing Check Data & Try Again " };

                }

            }


        }

        public async Task<GETSkillsModel> GetuserSkills(string ID)
        {
            var user = await _user.FindByNameAsync(ID);
            if (user == null)
                return new GETSkillsModel() { Message = "Skill Model with user " };
            else
            {
                try
                {
                    var userSkills = (from q in _db.UserSkills
                                      where q.userId == user.Id && q.skillID == q.Skills.Id
                                      select q.Skills.name).ToList();

                    var data = new GETSkillsModel()
                    {
                        userID = ID,
                        Skills = userSkills,
                        Message = "Successed"
                    };
                    return data;
                }
                catch (Exception ex)
                {
                    return new GETSkillsModel() { Message = "Error in Skill Model " };

                }
            }
        }
        DateTime time;
        public async Task<List<GETuserResumeModel>> GetuserRusme(string ID)
        {
            var user = await _user.FindByNameAsync(ID);
            if (user == null)
                return new List<GETuserResumeModel>();
            else
            {
                try
                {
                    var usercompany = _db.UserCompany.Where(x => x.User_Id == user.Id)
                        .Include(x => x.Company)
                        .Include(x => x.JobCategory)
                        .Include(x=>x.User)
                        .ToList();

                    var data = new List<GETuserResumeModel>();
                    foreach (var i in usercompany)
                    {
                        var userTitle = _db.JobCategory.FirstOrDefault(x => x.JobCat_Id == i.title);
                        var userTitleCategory = _db.Category.FirstOrDefault(x => x.Cat_Id == userTitle.CategoryID);
                        if (i.StillWorking)
                        {
                            time = DateTime.Now;
                        }
                        else
                        {
                            time = i.to.Value;
                        }
                        data.Add(new GETuserResumeModel()
                        {
                            empuserID = i.ID,
                            userID = user.UserName,
                            company = i.Company.CompanyName,
                            Description = i.description,
                            status = i.StillWorking,
                            from = i.from,
                            To = time,
                            title = userTitle.JobCat_Desc + "," + userTitleCategory.Cat_Desc,
                            strength = i.User.Strength,
                            Message = "get data fom Rsume"

                        });
                    }

                    return data;
                }
                catch (Exception ex)
                {
                    return new List<GETuserResumeModel>();
                }
            }
        }

        public async Task<List<GETuserEducationModel>> GetuserEducation(string ID)
        {
            var user = await _user.FindByNameAsync(ID);
            if (user == null)
                return new List<GETuserEducationModel>();
            else
            {
                try
                {
                    var userEdu = _db.userEducations.Where(x => x.userID == user.Id).ToList();
                    var data = new List<GETuserEducationModel>();
                    foreach (var item in userEdu)
                    {
                        var typeEDU = _db.typeOfEducations.FirstOrDefault(x=>x.ID == item.type);
                        var univ = _db.Company.FirstOrDefault(x => x.Company_Id == item.companyID);
                        data.Add(new GETuserEducationModel()
                        {
                            eduuserID = item.id,
                            userID = ID,
                            TypeOfEducation = typeEDU.Name,
                            university = univ.CompanyName,
                            Message = "success"
                        });
                    }
                    return data;
                }
                catch (Exception ex)
                {
                    return new List<GETuserEducationModel>();

                }
            }
        }
        public async Task<List<SocialMedia>> GetuserOnlineProfile(string id)
        {
            var user = await _user.FindByNameAsync(id);
            if (user == null)
                return new List<SocialMedia>();
            else
            {
                try
                {
                    var userSocialMedia = _db.Onlineprofiles.Where(x => x.userID == user.Id).ToList();
                    var data = new List<SocialMedia>();
                    foreach (var item in userSocialMedia)
                    {
                        data.Add(new SocialMedia()
                        {
                            userID = id,
                            URL = item.URL,
                            onlineID = item.ID,
                            Message = "success"
                        });
                    }
                    return data;
                }
                catch (Exception ex)
                {
                    return new List<SocialMedia>();

                }
            }

        }
        public async Task<BasicInfoModel> EditBasic(BasicInfoModel data)
        {
            var user = await _user.FindByNameAsync(data.userID);
            if (await _user.FindByEmailAsync(data.email) != null && user.Email != data.email)
                return new BasicInfoModel() { Message = "Sorry this Email existed " };
            else
            {
                user.title = data.titleId;
                user.summary = data.summary;
                user.City_Id = data.cityId;
                user.Country_Id = data.countryId;
                user.Email = data.email;
                user.PhoneNumber = data.phone;
                user.FName = data.fname;
                user.LName = data.lname;
                user.Address = data.Address;
                user.birthday = data.birthdate;
                try
                {
                    _db.SaveChanges();
                    data.Message = "Successed";
                    return data;
                }
                catch (Exception ex)
                {
                    return new BasicInfoModel() { Message = "An error Occured During Processing Check Data & Try Again " };

                }

            }
        }
        public async Task<bool> resetPassword(PassModel pass)
        {
            var user = await _user.FindByNameAsync(pass.userID);
            var res = await _user.ChangePasswordAsync(user, pass.CurrentPassword, pass.NewPassword);
            return res.Succeeded;
        }
        public async Task<userResumeModel> userResume(userResumeModel data)
        {
            var user = await _user.FindByNameAsync(data.userID);
            int id = _db.UserCompany.ToList().Count == 0 ? 1 : _db.UserCompany.Max(x => x.ID) + 1;
            var resume = new UserCompany()
            {
                User_Id = user.Id,
                Company_Id = data.company,
                title = data.title,
                from = data.from,
                to = data.from,
                description = data.Description,
                StillWorking = data.status,
                ID = id
            };
            await _db.UserCompany.AddAsync(resume);
            if (_db.UserCompany.Where(x => x.User_Id == user.Id).ToList().Count == 0)
                user.Strength += 0.5f;
            try
            {
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.UserCompany OFF;");
                //_db.Database.ExecuteSql("SET IDENTITY_INSERT dbo.DestuffedContainer ON");
                _db.SaveChanges();
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.UserCompany ON;");
                data.Message = "Successed";
                data.strength = user.Strength;
                return data;
            }
            catch (Exception ex)
            {

                return new userResumeModel() { Message = "An Error Occured" };
            }
        }
        public async Task<userEducationModel> userEducation(userEducationModel data)
        {
            var user = await _user.FindByNameAsync(data.userID);
            var education = new userEducation()
            {
                userID = user.Id,
                type = data.TypeOfEducation,
                companyID = data.university
            };

            await _db.userEducations.AddAsync(education);
            if (_db.userEducations.Where(x => x.userID == user.Id).ToList().Count == 0)
                user.Strength += .15f;
            try
            {

                _db.SaveChanges();
                data.Message = "Successed";
                return data;
            }
            catch (Exception)
            {

                return new userEducationModel() { Message = "An Error Occured" };
            }
        }
        public async Task<SkillsModel> userSkills(SkillsModel data)
        {
            var user = await _user.FindByNameAsync(data.userID);
            /*var Uskills = await _db.UserSkills.Where(x => x.userId == user.Id).Select(x=>x.skillID).ToListAsync();*/
            var Uskills = (from w in _db.UserSkills where w.userId.Equals(user.Id) select w).ToList();
            if(Uskills.Count == 0)
            {
                var us = new List<userSkills>();
                for (int i = 0; i < data.Skills.Count; i++)
                {

                    us.Add(new userSkills()
                    {
                        userId = user.Id,
                        skillID = data.Skills[i]
                    });
                }
                await _db.UserSkills.AddRangeAsync(us);
                if (_db.UserSkills.Where(x => x.userId == user.Id).ToList().Count == 0)
                    user.Strength += .1f;
               
            }
            else
            {

                var oo = data.Skills.Except(Uskills.Select(x => x.skillID)).ToList(); // ma3ea el msh mwgood 3nd el user
                var pp = Uskills.Select(x=>x.skillID).Except(data.Skills).ToList(); //ma3ea el msh mwgod fe lest el data 
                var us = new List<userSkills>();
                for (int i = 0; i < oo.Count; i++)
                {
                    us.Add(new userSkills()
                    {
                        userId = user.Id,
                        skillID = oo[i]
                    });
                }
                await _db.UserSkills.AddRangeAsync(us);
                for (int i = 0; i < pp.Count; i++)
                {
                    _db.UserSkills.RemoveRange(Uskills.FirstOrDefault(x => x.skillID == pp[i]));
                }
            }
            try
            {
                _db.SaveChanges();
                data.Message = "Successed";
                return data;
            }
            catch (Exception ex)
            {
                var text = ex.Message;
                return new SkillsModel() { Message = "An Error Occured" };
            }

        }
        public async Task<SocialMedia> userOnlineProfile(SocialMedia data)
        {
            var user = await _user.FindByNameAsync(data.userID);
            var OnlineProfile = new Onlineprofile()
            {
                userID = user.Id,
                URL = data.URL
            };
            await _db.Onlineprofiles.AddAsync(OnlineProfile);
            if (_db.Onlineprofiles.Where(x => x.userID == user.Id).ToList().Count == 0)
                user.Strength += .25f;
            try
            {

                _db.SaveChanges();
                data.Message = "Successed";
                return data;
            }
            catch (Exception ex)
            {
                return new SocialMedia() { Message = "An Error Occured" };
            }
        }

        public async Task<bool> DelUser(string username)
        {
            var user = await _user.FindByNameAsync(username);
            var getuser = await _db.User.FirstOrDefaultAsync(m => m.Id == user.Id);
            getuser.IsActive = false;
            _db.SaveChanges();
            return true;
        }
        public async Task<bool> DeleteEmpHistroy(int data)
        {
            var gethistory = await _db.UserCompany.FirstOrDefaultAsync(x => x.ID == data);
            var user = await _user.FindByIdAsync(gethistory.User_Id);
            if (gethistory == null)
                return false;
            else
            {
                _db.UserCompany.Remove(gethistory);
                try
                {
                    //_db.SaveChanges();
                    if (_db.UserCompany.Where(x => x.User_Id == user.Id).ToList().Count == 0)
                        user.Strength -= .5f;

                    _db.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        
        }

        public async Task<bool> DeleteEduHistroy(int data)
        {
            var gethistory = await _db.userEducations.FirstOrDefaultAsync(x => x.id == data);
            var user = await _user.FindByIdAsync(gethistory.userID);

            if (gethistory == null)
                return false;
            else
            {
                _db.userEducations.Remove(gethistory);
                if (_db.userEducations.Where(x => x.userID == user.Id).ToList().Count == 0)
                    user.Strength -= .25f;

                _db.SaveChanges();
                return true;
            }

        }
        public async Task<bool> Deleteonlineprofile(int data)
        {
            var gethistory = await _db.Onlineprofiles.FirstOrDefaultAsync(x => x.ID == data);
            var user = await _user.FindByIdAsync(gethistory.userID);

            if (gethistory == null)
                return false;
            else
            {
                _db.Onlineprofiles.Remove(gethistory);
                _db.SaveChanges();
                return true;
            }

        }




    }
}
