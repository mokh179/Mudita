using Models;
using Services.ViewModels.Admin;
using Services.ViewModels.Company;
using Services.ViewModels.Vacancy;
using Services.ViewModels.Vacancy.GET_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAdmin
    {
        //Admin User func
        Task<List<AdminUserModel>> GetAllUsers();
        Task<bool> DeleteUser(string username);

        //Admin Company func
        Task<bool> DeleteCompany(int id);
        //Admin Country Func 
        Task<List<AdminCountryModel>> GetAllCountries();
        Task<AdminCountryModel> GetCountrybyId(int id);
        Task<AdminCountryModel> AddCountry(AdminCountryModel c1);
        Task<AdminCountryModel> EditCountry(AdminCountryModel c1);
        Task<bool> DeleteCountry(int id);

        //Admin City Fun

        Task<List<AdminCityModel>> GetAllCities();
        Task<AdminCityModel> GetCitybyId(int id);
        Task<AdminCityModel> AddCity(AdminCityModel c1);
        Task<AdminCityModel> EditCity(AdminCityModel c1);
        Task<bool> DeleteCity(int id);


        //Admin Category fun 
        Task<List<Category>> GetAllCategory();
        Task<AdminCategoryModel> GetCategorybyId(int id);
        Task<AdminCategoryModel> AddCategory(AdminCategoryModel c1);
        Task<AdminCategoryModel> EditCategory(AdminCategoryModel c1);
        Task<bool> DeleteCategory(int id);


        //Admin Vacancy fun
      
        Task<bool> DeleteVacancy(int id);
        Task<List<getAllAppliedVacancyModel>> GetCloseVacancy();

        //Count fun

        int GetAllUser();
        int GetAllActiveUser();
        int GetAllDeactiveUser();

        int GetAllCompany();
        int GetAllActiveCompany();
        int GetAllDeactiveCompany();

        int GetAllVacancy();
        int GetAllActiveVacancy();
        int GetAllDeactiveVacancy();

        int GetAllJobCat();
        int GetAllJobTitle(); 
    }
}
