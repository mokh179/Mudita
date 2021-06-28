using Services.ViewModels.Vacancy;
using Services.ViewModels.Vacancy.GET_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IVacancy
    {
        //string PostJob(VacancyViewModel vc); //user
        Task<List<GETVacancyViewModel>> getAll(string userName); //user
        Task<List<GetAllJobsforCompanyModel>> getAllByCompany(int id); //company
        Task<GETVacancyViewModel> getByID(int id);
        Task<string> EditVacancy(VacancyViewModel vc);
        Task<bool>Delete(int id);
        Task<bool> withdraw(int id,string username);
        Task<bool> Apply(Applied_Vacancy_Model vm);

        Task<List<getAllAppliedVacancyModel>> GetUserVacancy(string obj);
        Task<List<GETAplicantVacany>> GetResumes(int comId, int VacId);
        Task<Boolean> changeStatus(GETAplicantVacany st);
        /*Task<List<GETMangeJob>> GetMangeVacancy();*/
    }
}
