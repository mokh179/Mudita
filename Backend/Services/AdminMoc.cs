using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using Services.ViewModels.Admin;
using Services.ViewModels.Company;
using Services.ViewModels.Vacancy;
using Services.ViewModels.Vacancy.GET_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminMoc : IAdmin
    {
        private readonly ApiDbContext _db;
        //Admin Function

        public AdminMoc(ApiDbContext db)
        {
            _db = db;
           
        }

        //Vacancy Functions 
        public async Task<bool> DeleteVacancy(int id)
        {
            var data = await _db.Vacancy.Where(x => x.Vacancy_Id == id).FirstOrDefaultAsync();
            if (data == null)
                return false;
            else
            {
                _db.KeySkillsVacancies.RemoveRange(_db.KeySkillsVacancies.Where(x => x.VacancyVacancy_Id == data.Vacancy_Id).ToList());
                _db.jobTypeVacancies.RemoveRange(_db.jobTypeVacancies.Where(x => x.Vacancy_Id == data.Vacancy_Id).ToList());
                _db.CompanyVacany.Remove(_db.CompanyVacany.FirstOrDefault(x => x.Vacancy_Id == data.Vacancy_Id));
                _db.AppliedVacancy.RemoveRange(_db.AppliedVacancy.Where(x => x.Vacancy_Id == data.Vacancy_Id).ToList());
                _db.Vacancy.Remove(data);
                _db.SaveChanges();
                return true;
            }
        }
        public async Task<List<getAllAppliedVacancyModel>> GetCloseVacancy()
        {
            var data = await _db.Vacancy.Include(x=>x.JobCategory).Include(x=>x.CompanyVacanies).Where(x=> x.IsActive == false).ToListAsync();
            if (data == null)
                return new List<getAllAppliedVacancyModel>();
            else
            {
                List<getAllAppliedVacancyModel> result = new List<getAllAppliedVacancyModel>();
                foreach (var item in data)
                {
                    var getcompmy = _db.CompanyVacany.Include(x => x.Company).FirstOrDefault(x => x.Vacancy_Id == item.Vacancy_Id);
                    /* var getcompany = from q in _db.CompanyVacany where q.Vacancy_Id.Equals(item.Vacancy_Id)
                                      select q.Company.CompanyName;*/
                    result.Add(new getAllAppliedVacancyModel()
                    {
                        title = item.JobCategory.JobCat_Desc,
                        PublishDate = getcompmy.PublishDate,
                        companyName = getcompmy.Company.CompanyName,
                        vacancyId = item.Vacancy_Id,
                    }); 
                }
                return result;


            }
        }

        //User Func      
        public async Task<bool> DeleteUser(string username)
        {
            var user = await _db.User.FirstOrDefaultAsync(a => a.UserName == username);
            if (user == null)
                return false;
            else
            {
                var userid = await _db.User.Where(a => a.UserName == username).Select(a => a.Id).FirstOrDefaultAsync();
                var appliedvavancy = await  _db.AppliedVacancy.Where(a => a.User_Id == userid).ToListAsync();
                var onlineprofile = await  _db.Onlineprofiles.Where(a => a.userID == userid).ToListAsync();
                var Rating = await _db.Rating.Where(a => a.User_Id == userid).ToListAsync();
                var Reaction = await _db.Reactions.Where(a => a.userId == userid).ToListAsync();
                var RoleUser = await _db.RoleUser.Where(a => a.User_Id == userid).ToListAsync();
                var UserCompany = await _db.UserCompany.Where(a => a.User_Id == userid).ToListAsync(); ;
                var UserEducation = await _db.userEducations.Where(a => a.userID == userid).ToListAsync();
                var UserQuestions = await _db.UserQues.Where(a => a.User_Id == userid).ToListAsync();
                var UserSkills = await _db.UserSkills.Where(a => a.userId == userid).ToListAsync();
                var companyUser = await _db.Company.Where(a => a.Manager_Id == userid).ToListAsync();

             //   for (int i = 0; i < len; i++) { }

                if (appliedvavancy != null)
                {
                    _db.AppliedVacancy.RemoveRange(appliedvavancy);
                }
                 if (onlineprofile!=null)
                {
                    _db.Onlineprofiles.RemoveRange(onlineprofile);
                }
                 if (Rating != null)
                {
                    _db.Rating.RemoveRange(Rating);
                }
                 if (Reaction != null)
                {
                    _db.Reactions.RemoveRange(Reaction);
                }
                 if (RoleUser != null)
                {
                    _db.RoleUser.RemoveRange(RoleUser);
                }
                 if (UserCompany != null)
                {
                    _db.UserCompany.RemoveRange(UserCompany);
                }
                 if (UserEducation != null)
                {
                    _db.userEducations.RemoveRange(UserEducation);
                } 
                 if (UserQuestions != null)
                {
                    _db.UserQues.RemoveRange(UserQuestions);
                }  
                 if (UserSkills != null)
                {
                    _db.UserSkills.RemoveRange(UserSkills);
                }
                 if (companyUser != null)
                {
                    _db.Company.RemoveRange(companyUser);
                }
                _db.User.Remove(user);
                _db.SaveChanges();
                return true;
            }

        }

        
        public async Task<List<AdminUserModel>> GetAllUsers()
        {
            var AllUsers = await _db.User.ToListAsync();

            var len = AllUsers.Count();
            List<AdminUserModel> Allusers = new List<AdminUserModel>();
            for (int i = 0; i < len; i++)
            {

                Allusers.Add(new AdminUserModel()
                {
                    User_Id = AllUsers[i].Id,
                    Email= AllUsers[i].Email,
                    UserName = AllUsers[i].UserName,
                    Gender = AllUsers[i].Gender,
                    Country_Id = AllUsers[i].Country_Id,
                    Country_Name = await _db.Countries.Where(a=>AllUsers[i].Country_Id==a.country_id).Select(a=>a.Country_Name).FirstOrDefaultAsync()    ,
                    PhoneNumber = AllUsers[i].PhoneNumber,
                }) ;
            }
            return Allusers;
        }



        //Countries Func

        public async Task<List<AdminCountryModel>> GetAllCountries()
        {
            var AllCountries = await _db.Countries.ToListAsync();
                         
            var len = AllCountries.Count();
            List<AdminCountryModel> AllCount = new List<AdminCountryModel>();
            for (int i = 0; i < len; i++)
            {

                AllCount.Add(new AdminCountryModel()
                {
                    country_id = AllCountries[i].country_id,
                    Country_Name = AllCountries[i].Country_Name,
                    Phone_code= AllCountries[i].Phone_code,
                    Sort_Name= AllCountries[i].Sort_Name,
                }) ;
            }
            return AllCount;
        }

        public async Task<AdminCountryModel> GetCountrybyId(int id)
        {
            var GetCountryById = await _db.Countries.FirstOrDefaultAsync(a => a.country_id == id);
                AdminCountryModel AllCount = new AdminCountryModel()
                 {
                    country_id = GetCountryById.country_id,
                    Country_Name = GetCountryById.Country_Name,
                    Phone_code = GetCountryById.Phone_code,
                    Sort_Name = GetCountryById.Sort_Name,

                };
                return AllCount;    
        }
        
        public async Task<AdminCountryModel> AddCountry(AdminCountryModel c1)
        {
            int CId = _db.Countries.ToList().Count() > 0 ? _db.Countries.Max(x => x.country_id) + 1 : 1;
            var Countr = new Countries()
            {
                country_id = CId,
                Country_Name = c1.Country_Name,
                Phone_code = c1.Phone_code,
                Sort_Name =c1.Sort_Name,

            };
            _db.Countries.Add(Countr);
            _db.SaveChanges();
            return c1 ;

        }

        public async Task<AdminCountryModel> EditCountry(AdminCountryModel c1)
        {
                var Country = await _db.Countries.FirstOrDefaultAsync(a=>a.country_id==c1.country_id);         
                Country.country_id = c1.country_id;
                Country.Country_Name = c1.Country_Name;
                Country.Phone_code = c1.Phone_code;
                Country.Sort_Name = c1.Sort_Name;
               _db.SaveChanges(); 
            return c1; 
        }

        public async Task<bool> DeleteCountry(int id)
        {
            var data = await _db.Countries.FirstOrDefaultAsync(x => x.country_id == id);
            if (data == null)
                return false;
            else
            {
               // var cities = await _db.City.Where(a => a.Country_Id == id).ToListAsync();
               // _db.Remove(cities); 
                _db.Remove(data);
                _db.SaveChanges();
                return true;
            }
        }


        //City Functions 

        public async Task<List<AdminCityModel>> GetAllCities()
        {
            var AllCities = await _db.City.ToListAsync();

            var len = AllCities.Count();
            List<AdminCityModel> AllCity = new List<AdminCityModel>();
            for (int i = 0; i < len; i++)
            {

                AllCity.Add(new AdminCityModel()
                {
                    City_Id = AllCities[i].City_Id,
                    City_Name = AllCities[i].City_Name,
                    country_id=AllCities[i].Country_Id
                   
                });
            }
            return AllCity;
        }

        public async Task<AdminCityModel> GetCitybyId(int id)
        {
            var GetCitybyId = await _db.City.FirstOrDefaultAsync(a => a.City_Id == id);
            AdminCityModel AllCity = new AdminCityModel()
            {
                City_Id = GetCitybyId.City_Id,
                City_Name = GetCitybyId.City_Name,
               country_id = GetCitybyId.Country_Id

            };
            return AllCity;
        }

        public async Task<AdminCityModel> AddCity(AdminCityModel c1)
        {
            
            var City = new City()
            {
               
                City_Name = c1.City_Name,
                Country_Id = c1.country_id
             

            };
            _db.City.Add(City);
            _db.SaveChanges();
            return c1;
        }

        public async Task<AdminCityModel> EditCity(AdminCityModel c1)
        {
            var City = await _db.City.FirstOrDefaultAsync(a => a.City_Id == c1.City_Id);
                City.City_Name = c1.City_Name;
                _db.SaveChanges();
                return c1;  
        }

        public async Task<bool> DeleteCity(int id)
        {
            var data = await _db.City.FirstOrDefaultAsync(x => x.City_Id == id);
            if (data == null)
                return false;
            else
            {
                _db.Remove(data);
                _db.SaveChanges();
                return true;
            }
        }

        //Category Functions 

        public async Task<List<Category>> GetAllCategory()
        {
                return await _db.Category.ToListAsync();       
        }

        public async Task<AdminCategoryModel> GetCategorybyId(int id)
        {
            var GetCategorybyId = await _db.Category.FirstOrDefaultAsync(a => a.Cat_Id == id);
            AdminCategoryModel AllCat = new AdminCategoryModel()
            {
                Cat_Id = GetCategorybyId.Cat_Id,
                Cat_Desc = GetCategorybyId.Cat_Desc,
        

            };
            return AllCat;
        }

        public async Task<AdminCategoryModel> AddCategory(AdminCategoryModel c1)
        {
            var Category = new Category()
            {
                Cat_Id = c1.Cat_Id,
                Cat_Desc = c1.Cat_Desc,
               


            };
            _db.Category.Add(Category);
            _db.SaveChanges();
            return c1;
        }

        public async Task<AdminCategoryModel> EditCategory(AdminCategoryModel c1)
        {

            var Category = await _db.Category.FirstOrDefaultAsync(a => a.Cat_Id == c1.Cat_Id);
            if (Category == null)
                return new AdminCategoryModel();
            else
            {
                Category.Cat_Id = c1.Cat_Id;
                Category.Cat_Desc = c1.Cat_Desc;
                _db.SaveChanges();
                return c1;
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var data = await _db.Category.FirstOrDefaultAsync(x => x.Cat_Id == id);
            if (data == null)
                return false;
            else
            {
                _db.Remove(data);
                _db.SaveChanges();
                return true;
            }
        }


        // Company Functions
        public async Task<bool> DeleteCompany(int id)
        {
            var data = await _db.Company.FirstOrDefaultAsync(x => x.Company_Id == id );
            if (data == null)
                return false;
            else
            {
                _db.Company.Remove(data);
                _db.SaveChanges();
                return true;
            }
        }
        



        ////Count Functions 

        ///User
        public int GetAllUser()
        {
            var UsersNum= _db.User.Count();

            return UsersNum; 
        }

        public int GetAllActiveUser()
        {
            var UsersNum = _db.User.Where(a => a.IsActive == true).Count();

            return UsersNum;
        }
        public int GetAllDeactiveUser()
        {
            var UsersNum = _db.User.Where(a => a.IsActive == false).Count();

            return UsersNum;
        }
        ///Company
        public int GetAllCompany()
        {
            var CompanyNum = _db.Company.Count();

            return CompanyNum;
        }

        public int GetAllActiveCompany()
        {
            var CompanyNum = _db.Company.Where(a => a.IsActive == true).Count();

            return CompanyNum;
        }
        public int GetAllDeactiveCompany()
        {
            var CompanyNum = _db.Company.Where(a => a.IsActive == false).Count();

            return CompanyNum;
        }

        //Vacancy
        public int GetAllVacancy()
        {
            var VacancyNum = _db.Vacancy.Count();

            return VacancyNum;
        }

        public int GetAllActiveVacancy()
        {
            var VacancyNum = _db.Vacancy.Where(a => a.IsActive == true).Count();

            return VacancyNum;
        }
        public int GetAllDeactiveVacancy()
        {
            var VacancyNum = _db.Vacancy.Where(a => a.IsActive == false).Count();

            return VacancyNum;
        }

        //JobCat&JobTitle 
        public int GetAllJobCat()
        {
            var JobCat = _db.JobCategory.Count();

            return JobCat;
        }
        public int GetAllJobTitle()
        {
            var JobTitle = _db.JobTypes.Count();

            return JobTitle;
        }


    }
}
