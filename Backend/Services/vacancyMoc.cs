using Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using Services.ViewModels;
using Services.ViewModels.User;
using Services.ViewModels.Vacancy;
using Services.ViewModels.Vacancy.GET_DATA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class vacancyMoc : IVacancy
    {
        private readonly ApiDbContext _db;
        private readonly UserManager<User> _user;


        public vacancyMoc(ApiDbContext db, UserManager<User> user)
        {
            _db = db;
            _user = user;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _db.Vacancy.FirstOrDefaultAsync(x => x.Vacancy_Id == id);
            var userdata = await _db.AppliedVacancy.Where(x => x.Vacancy_Id == id).ToListAsync();
            if (data == null)
                return false;
            else
            {
                data.IsActive = false;
                foreach (var item in userdata)
                {
                    item.status = 5;
                }

                /*_db.UpdateRange(userdata);
                _db.Update(data);*/
                _db.SaveChanges();
                return true;
            }
        }

        public async Task<string> EditVacancy(VacancyViewModel vc)
        {
            if (vc.vacancyID == null||vc.vacancyID==0)
            {
                int vacid = _db.Vacancy.ToList().Count == 0 ? 1 : _db.Vacancy.Max(x => x.Vacancy_Id) + 1;
                var vacancy = new Vacancy()
                {
                    IsActive = true,
                    Vacancy_Desc = vc.Description,
                    JobCat_Id = vc.jobTitle,
                    Vacancy_Id = vacid
                };
                _db.Vacancy.Add(vacancy);

                var companyVacancy = new CompanyVacany()
                {
                    PublishDate = DateTime.Now,
                    Company_Id = vc.company,
                    Vacancy_Id = vacancy.Vacancy_Id
                };
                _db.CompanyVacany.Add(companyVacancy);

                var types = new List<JobTypeVacancy>();
                var tags = new List<KeySkillsVacancy>();
                for (int i = 0; i < vc.jobTypes.Count; i++)
                {
                    types.Add(new JobTypeVacancy()
                    {
                        JobTypeId = vc.jobTypes[i],
                        Vacancy_Id = vacancy.Vacancy_Id
                    });
                }
                _db.jobTypeVacancies.AddRange(types);
                for (int i = 0; i < vc.jobTags.Count; i++)
                {
                    tags.Add(new KeySkillsVacancy()
                    {
                        KeySkillId = vc.jobTags[i],
                        VacancyVacancy_Id = vacancy.Vacancy_Id
                    });
                }
                _db.KeySkillsVacancies.AddRange(tags);
                _db.SaveChanges();
            }
            else
            {
                var vacancySkills = _db.KeySkillsVacancies.Where(x => x.VacancyVacancy_Id == vc.vacancyID).ToList();
                var updatedSkils = vc.jobTags.Except(vacancySkills.Select(x => x.KeySkillId)).ToList(); // ma3ea el msh mwgood 3nd el user
                var deletedSkills = vacancySkills.Select(x => x.KeySkillId).Except(vc.jobTags).ToList(); //ma3ea el msh mwgod fe lest el data 



                var us = new List<KeySkillsVacancy>();
                var typs = new List<JobTypeVacancy>();
                var types = _db.jobTypeVacancies.Where(x => x.Vacancy_Id == vc.vacancyID).ToList();
                var updatedtypes = vc.jobTypes.Except(types.Select(x => x.JobTypeId)).ToList();
                var deletedtypes = types.Select(x => x.JobTypeId).Except(vc.jobTypes).ToList();



                for (int i = 0; i < updatedtypes.Count; i++)
                {
                    typs.Add(new JobTypeVacancy()
                    {
                        Vacancy_Id = vc.vacancyID,
                        JobTypeId = updatedtypes[i]
                    });
                }
                //await _db.jobTypeVacancies.AddRangeAsync(typs);
                for (int i = 0; i < deletedtypes.Count; i++)
                {
                    _db.jobTypeVacancies.Remove(types.FirstOrDefault(x => x.JobTypeId == deletedtypes[i]));
                }

                for (int i = 0; i < updatedSkils.Count; i++)
                {
                    us.Add(new KeySkillsVacancy()
                    {
                        VacancyVacancy_Id = vc.vacancyID,
                        KeySkillId = updatedSkils[i]
                    });
                }
                await _db.KeySkillsVacancies.AddRangeAsync(us);
                for (int i = 0; i < deletedSkills.Count; i++)
                {
                    _db.KeySkillsVacancies.Remove(vacancySkills.FirstOrDefault(x => x.KeySkillId == deletedSkills[i]));
                }
                var vac = _db.Vacancy.Find(vc.vacancyID);
                vac.JobCat_Id = vc.jobTitle;
                vac.Vacancy_Desc = vc.Description;
                _db.SaveChanges();

            }
            return "Done";

        }
        public async Task<List<GETVacancyViewModel>> getAll(string userName)
        {
            var checkVacancy = await _db.Vacancy.Where(x => x.IsActive.Equals(true)).ToListAsync();
            var data = new List<GETVacancyViewModel>();
           
            
            if (userName == null || userName == string.Empty||userName=="null")
            {
                foreach (var item in checkVacancy)
                {
                    var jobstag = _db.KeySkillsVacancies.Where(x => x.VacancyVacancy_Id == item.Vacancy_Id)
                                    .Select(x => x.KeySkills.name)
                                    .ToList();

                    var jobstype = _db.jobTypeVacancies.Where(x => x.Vacancy_Id == item.Vacancy_Id)
                        .Select(x => x.JobType.Description)
                        .ToList();

                    var company = _db.CompanyVacany.Include(a => a.Company).FirstOrDefault(x => x.Vacancy_Id == item.Vacancy_Id);

                    var JobCat = _db.JobCategory.FirstOrDefault(x => x.JobCat_Id == item.JobCat_Id).JobCat_Desc;

                    var date = _db.CompanyVacany.FirstOrDefault(x => x.Vacancy_Id == item.Vacancy_Id).PublishDate;
                    data.Add(new GETVacancyViewModel()
                    {
                        vacancyID = item.Vacancy_Id,
                        company = company.Company.CompanyName,
                        Description = item.Vacancy_Desc,
                        jobTags = jobstag,
                        jobTitle = JobCat,
                        jobTypes = jobstype,
                        publishdate = date,
                        companyId = company.Company_Id,
                       // AppliedState = _db.AppliedVacancy.Where(a => a.Vacancy_Id == item.Vacancy_Id && a.User_Id == user).ToList().Count() > 0 ? true : false
                    });
                }

            }
            else
            {
                {
                    var user = _user.FindByNameAsync(userName).Result.Id;

                    foreach (var item in checkVacancy)
                    {
                        var jobstag = _db.KeySkillsVacancies.Where(x => x.VacancyVacancy_Id == item.Vacancy_Id)
                                        .Select(x => x.KeySkills.name)
                                        .ToList();

                        var jobstype = _db.jobTypeVacancies.Where(x => x.Vacancy_Id == item.Vacancy_Id)
                            .Select(x => x.JobType.Description)
                            .ToList();

                        var company = _db.CompanyVacany.Include(a => a.Company).FirstOrDefault(x => x.Vacancy_Id == item.Vacancy_Id);

                        var JobCat = _db.JobCategory.FirstOrDefault(x => x.JobCat_Id == item.JobCat_Id).JobCat_Desc;

                        var date = _db.CompanyVacany.FirstOrDefault(x => x.Vacancy_Id == item.Vacancy_Id).PublishDate;
                        data.Add(new GETVacancyViewModel()
                        {
                            vacancyID = item.Vacancy_Id,
                            company = company.Company.CompanyName,
                            Description = item.Vacancy_Desc,
                            jobTags = jobstag,
                            jobTitle = JobCat,
                            jobTypes = jobstype,
                            publishdate = date,
                            companyId = company.Company_Id,
                            AppliedState = _db.AppliedVacancy.Where(a => a.Vacancy_Id == item.Vacancy_Id && a.User_Id == user).ToList().Count() > 0 ? true : false
                        });
                    }
                }
            }
            return data;
        }
        public async Task<List<GetAllJobsforCompanyModel>> getAllByCompany(int id)
        {
            var company = await _db.Company.FirstOrDefaultAsync(x => x.Company_Id == id);
            if (company == null)
                return new List<GetAllJobsforCompanyModel>();
            else
            {
                try
                {
                    var vacancy = await _db.CompanyVacany.Where(x => x.Company_Id == id)
                        .ToListAsync();

                    var data = new List<GetAllJobsforCompanyModel>();
                    foreach (var i in vacancy)
                    {
                        var checkVacancy = await _db.Vacancy.Include(a => a.JobCategory).Include(a => a.CompanyVacanies).Where(x => x.IsActive.Equals(true))
                            .FirstOrDefaultAsync(x => x.Vacancy_Id == i.Vacancy_Id);
                        if (checkVacancy != null)
                        {



                            data.Add(new GetAllJobsforCompanyModel()
                            {
                                VacancyId = checkVacancy.Vacancy_Id,
                                title = checkVacancy.JobCategory.JobCat_Desc,
                                NoApplicants = _db.AppliedVacancy.Count(x => x.Vacancy_Id == checkVacancy.Vacancy_Id),
                                NoViewed = _db.AppliedVacancy.Count(x => x.Vacancy_Id == checkVacancy.Vacancy_Id && x.status == 2),
                                Noselected = _db.AppliedVacancy.Count(x => x.Vacancy_Id == checkVacancy.Vacancy_Id && x.status == 3),
                                NoRejected = _db.AppliedVacancy.Count(x => x.Vacancy_Id == checkVacancy.Vacancy_Id && x.status == 4),
                                PublishDate = _db.CompanyVacany.FirstOrDefault(x => x.Vacancy_Id == checkVacancy.Vacancy_Id).PublishDate
                            });
                        }
                    }
                    return data;
                }
                catch (Exception ex)
                {
                    return new List<GetAllJobsforCompanyModel>();
                }
            }


        }
        public async Task<GETVacancyViewModel> getByID(int id)
        {
            var checkVacancy = await _db.Vacancy.FirstOrDefaultAsync(x => x.Vacancy_Id == id);

            var jobstag = _db.KeySkillsVacancies.Where(x => x.VacancyVacancy_Id == checkVacancy.Vacancy_Id)
                                .Select(x => x.KeySkills.name)
                                .ToList();

            var jobstype = _db.jobTypeVacancies.Where(x => x.Vacancy_Id == checkVacancy.Vacancy_Id)
                .Select(x => x.JobType.Description)
                .ToList();

            var company = _db.CompanyVacany.Include(a => a.Company).FirstOrDefault(x => x.Vacancy_Id == checkVacancy.Vacancy_Id);


            var JobCat = _db.JobCategory.FirstOrDefault(x => x.JobCat_Id == checkVacancy.JobCat_Id).JobCat_Desc;

            var date = _db.CompanyVacany.FirstOrDefault(x => x.Vacancy_Id == checkVacancy.Vacancy_Id).PublishDate;


            var data = new GETVacancyViewModel()
            {
                vacancyID = checkVacancy.Vacancy_Id,
                company = company.Company.CompanyName,
                Description = checkVacancy.Vacancy_Desc,
                jobTags = jobstag,
                jobTitle = JobCat,
                jobTypes = jobstype,
                publishdate = date,
                companyId = company.Company_Id
                
            };

            return data;
        }

        public async Task<bool> withdraw(int id, string username)
        {
            var user = _user.FindByNameAsync(username).Result.Id;
            var vac=await _db.AppliedVacancy.FirstOrDefaultAsync(a => a.Vacancy_Id == id && a.User_Id == user);
            if (vac!=null)
            {
                vac.withDraw = true;
                _db.SaveChanges();
                return true;

            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Apply(Applied_Vacancy_Model vm)
        {
            var user = _user.FindByNameAsync(vm.userName).Result.Id;
            var appiled = new AppliedVacancy()
            {
                status = 1,
                isActive = true,
                AppliedDate = DateTime.Now,
                withDraw = false,
                Vacancy_Id = vm.vacancyID,
                Company_Id = vm.companyId,
                User_Id = user
            };
            var res = await _db.AppliedVacancy.AddAsync(appiled);
            if (res.State == EntityState.Added)
            {
                try
                {

                _db.SaveChanges();
                return true;
                }
                catch (Exception x )
                {
                    string t = x.Message;
                    throw;
                }
            }
            else
                return false;
        }


        public async Task<List<getAllAppliedVacancyModel>> GetUserVacancy(string obj)
        {

            var user = await _user.FindByNameAsync(obj);
            List<getAllAppliedVacancyModel> result = new List<getAllAppliedVacancyModel>();
            var allVacancies = _db.AppliedVacancy.Include(a => a.Vacancy).Include(a => a.Company).Include(a => a.State).Where(a => a.User_Id == user.Id&&a.withDraw==false).ToList();
            string folderName;
            foreach (var item in allVacancies)
            {
                if (item.Company.Image !=null)
                {
                   folderName = Path.Combine("Resources", "Company", "images",item.Company.Image);
                }
                else
                {
                    folderName = null;
                }
                result.Add(new getAllAppliedVacancyModel()
                {
                    title = _db.JobCategory.FirstOrDefault(x => x.JobCat_Id == item.Vacancy.JobCat_Id).JobCat_Desc,
                    description = item.Vacancy.Vacancy_Desc,
                    //PublishDat = Convert.ToDateTime(_db.CompanyVacany.Where(x => x.Company_Id == item.Company_Id && x.Vacancy_Id == item.Vacancy_Id).Select(a => a.PublishDate)),
                    PublishDate = _db.CompanyVacany.FirstOrDefault(x => x.Company_Id == item.Company_Id && x.Vacancy_Id == item.Vacancy_Id).PublishDate,
                    companyName = item.Company.CompanyName,
                    AppliedDate = item.AppliedDate,
                    state = item.State.state,
                    VacancyState = item.Vacancy.IsActive,
                    NoApplicants = _db.AppliedVacancy.Count(x => x.Vacancy_Id == item.Vacancy_Id),
                    NoViewed = _db.AppliedVacancy.Count(x => x.Vacancy_Id == item.Vacancy_Id && x.status == 2),
                    Noselected = _db.AppliedVacancy.Count(x => x.Vacancy_Id == item.Vacancy_Id && x.status == 3),
                    NoRejected = _db.AppliedVacancy.Count(x => x.Vacancy_Id == item.Vacancy_Id && x.status == 4),
                    CompanyImage = folderName,
                    vacancyId=item.Vacancy_Id,
                    
                });
            }
            return result;
        }
        public async Task<List<GETAplicantVacany>> GetResumes(int comId, int VacId)
        {
            var getAplicaent = await _db.AppliedVacancy.Include(x=>x.User).Where(x => x.Company_Id == comId && x.Vacancy_Id == VacId).ToListAsync();
           if(getAplicaent.Count == 0)
                return new List<GETAplicantVacany>();
            else
            {
                List<GETAplicantVacany> result = new List<GETAplicantVacany>();

                foreach (var item in getAplicaent)
                {
                    string titl = "";
                    var title = _db.JobCategory.FirstOrDefault(x => x.JobCat_Id == item.User.title);
                    if(title != null)
                    {
                        titl = title.JobCat_Desc;
                    }

                    if(!item.withDraw && item.isActive) //We check if Application is WithDraw or Rejected
                    {
                        var cityname = _db.City.FirstOrDefault(x => x.City_Id == item.User.City_Id).City_Name;
                        var countryname = _db.Countries.FirstOrDefault(x => x.country_id == item.User.Country_Id).Country_Name;
                        result.Add(new GETAplicantVacany()
                        {
                            City = cityname,
                            Country = countryname,
                            name = item.User.FName + " " + item.User.LName,
                            CV = item.User.CV,
                            Title = titl,
                            status = item.status,
                            UserName = item.User.UserName,
                            vacancyID = item.Vacancy_Id
                        });

                    }
                }
                return result;

            }




        }
        public async Task<Boolean> changeStatus(GETAplicantVacany st)
        {
            var uservac =await _db.AppliedVacancy.FirstOrDefaultAsync(x => x.User_Id == _user.FindByNameAsync(st.UserName).Result.Id &&
                                                                 x.Vacancy_Id == st.vacancyID);
            uservac.status = st.status;
            if (st.status == 4 )
            {
                uservac.isActive = false;
            }

            try
            {
                _db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
            

        }
    }
}
 