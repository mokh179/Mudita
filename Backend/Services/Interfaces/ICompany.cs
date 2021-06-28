using Models;
using Services.ViewModels;
using Services.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICompany
    {
        Task<List<CompareCompanyModel>> GetCompareById(params string[] list);
        Task<List<AllCompanyDataModel>> GetAll();
        Task<List<AllCompanyDataModel>> GetAllbyCategoryID(int catID);
        Task<ShowCompanyModel> GetbyId(int id);
        Task<CompanyModel> Add(CompanyModel t1);
        Task<bool> Delete(int CompanyId,string ManagerID);
        Task<ShowCompanyModel> Edit(int CompanyID, ShowCompanyModel t1);
        Task<LocationModel> addLocation(LocationModel obj);
        Task<EditLocation> EditLocation(EditLocation obj);
        Task<List<Company>> GetAllCompare(string id);
        Task<Company> GetonCompany(int id);
        Task<List<AllCompanyDataModel>> SearchFilteration(int? countryid, int? cityid, int? categoryid);
        Task<GetStatus> getNoOfReviewers(int companyID);
        Task<List<string>> AllReviews(int companyID);
        Task<bool> DeactiveCompany(int companyID);

        Task<List<AllCompanyDataModel>> AdminGetAll();

    }
}
