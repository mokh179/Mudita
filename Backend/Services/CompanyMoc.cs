using Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using Services.ViewModels;
using Services.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CompanyMoc : ICompany
    {
        private ApiDbContext _db;
        private readonly UserManager<User> _user;
        public CompanyMoc(ApiDbContext db, UserManager<User> user)
        {
            _db = db;
            _user = user;
        }

        #region GeneralFunctionsUsed
        public bool IsAllowed(int CompanyId, string ManagerID, out UserCompany Uscompany)
        {
            var Allowed = _db.UserCompany.Where(u => u.User_Id == ManagerID && u.Company_Id == CompanyId && u.StillWorking).FirstOrDefault();
            Uscompany = Allowed;
            if (Uscompany == null)
                return false;
            else
                return true;
        }
        public double overallavarge(int company_id)
        {
            int count = _db.Rating.Count(x => x.Company_Id == company_id);
            var sum = _db.Rating.Where(x => x.Company_Id == company_id)
            .Sum(x => x.OverAllRate);
            double total = sum / count;
            if (total > 0 || total == 0)
                return total;
            return 0;
        }
        public void overalltotal(int company_id, out double Totalsalary, out double TotalWorkingEnvironment, out double TotalService, out double TotalSafety)
        {

            int count = _db.Rating.Count(x => x.Company_Id == company_id);
            var sumsalrate = _db.Rating.Where(x => x.Company_Id == company_id)
            .Sum(x => x.SalRate);
            var totalsalrate = sumsalrate / count;
            Totalsalary = totalsalrate;

            var sumworkenvironmentRate = _db.Rating.Where(x => x.Company_Id == company_id)
            .Sum(x => x.WorkEnvironmentRate);
            var totalworkenvironmentRate = sumworkenvironmentRate / count;
            TotalWorkingEnvironment = totalworkenvironmentRate;

            var sumserviceRate = _db.Rating.Where(x => x.Company_Id == company_id)
           .Sum(x => x.ServiceRate);
            var totalserviceRate = sumserviceRate / count;
            TotalService = totalserviceRate;

            var sumsafetyRate = _db.Rating.Where(x => x.Company_Id == company_id)
            .Sum(x => x.SafetyRate);
            var totalsafetyRate = sumsafetyRate / count;
            TotalSafety = totalsafetyRate;


        }
        #endregion
        public async Task<List<CompareCompanyModel>> GetCompareById(params string[] list)
        {
            List<CompareCompanyModel> TableFill = new List<CompareCompanyModel>();
            for (int i = 0; i < list.Length; i++)
            {

                double Tsafety;
                double Tsalary;
                double Tservice;
                double Tworkenv;


                var companyid = await _db.Company.Where(x => x.CompanyName == list[i]).Select(a => a.Company_Id).FirstOrDefaultAsync();
                var votecount = _db.Rating.Where(x => x.Company_Id == companyid).Count();

                var companyname = await _db.Company.Where(x => x.CompanyName == list[i]).Select(a => a.CompanyName).FirstOrDefaultAsync();

                //var company = await _db.Company.FindAsync(id);
                var avg = overallavarge(companyid);
                overalltotal(companyid, out Tsafety, out Tsalary, out Tservice, out Tworkenv);

                TableFill.Add(new CompareCompanyModel()
                {
                    votecount = votecount,
                    CompanyID = companyid,
                    CompanyName = companyname,
                    OverAllRate = avg,
                    Totalsalary = Tsalary,
                    TotalSafety = Tsafety,
                    TotalService = Tservice,
                    TotalWorkingEnvironment = Tworkenv,
                });

            }
            return TableFill;

        }
        public async Task<List<Company>> GetAllCompare(string Company_Name)
        {
            var companyid = await _db.Company.Where(a => a.CompanyName == Company_Name).Select(a => a.Company_Id).FirstOrDefaultAsync();
            // var CompId = _db.CompanyQues.Where(a => a.Ques_Id == loadAll[i].Ques_Id).Select(a => a.Company_Id).FirstOrDefault();
            // var compName = _db.CompanyQues.Where(b => b.Company_Id == CompId).Select(b => b.Company.CompanyName).FirstOrDefault();
            int category = _db.Company.Where(x => x.Company_Id == companyid).Select(a => a.Category_Id).FirstOrDefault();
            var Companies = _db.Company.Where(s => s.Category_Id == category).ToList();
            return Companies;
        }
        public async Task<List<AllCompanyDataModel>> GetAll()
        {
            int len = _db.Company.Where(a=>a.IsActive==true).ToList().Count();
            var companies = await _db.Company.Include(x => x.Category).Where(a => a.IsActive == true).ToListAsync();
            List<AllCompanyDataModel> AllCompanies = new List<AllCompanyDataModel>();
            for (int i = 0; i < len; i++)
            {
                AllCompanies.Add(new AllCompanyDataModel()
                {
                    companyID = companies[i].Company_Id,
                    categoryName = companies[i].Category.Cat_Desc,
                    overAllRate = overallavarge(companies[i].Company_Id),
                    companyName = companies[i].CompanyName,
                    Category_Id = companies[i].Category_Id

                });
            }

            return AllCompanies;
        }
        public async Task<List<AllCompanyDataModel>> AdminGetAll()
        {
            int len = _db.Company.Where(a => a.IsActive == false).ToList().Count();
            var companies = await _db.Company.Include(x => x.Category).Where(a => a.IsActive == false).ToListAsync();
            List<AllCompanyDataModel> AllCompanies = new List<AllCompanyDataModel>();
            for (int i = 0; i < len; i++)
            {
                AllCompanies.Add(new AllCompanyDataModel()
                {
                    companyID = companies[i].Company_Id,
                    categoryName = companies[i].Category.Cat_Desc,
                    overAllRate = overallavarge(companies[i].Company_Id),
                    companyName = companies[i].CompanyName,
                    Category_Id = companies[i].Category_Id

                });
            }

            return AllCompanies;
        }
        public async Task<ShowCompanyModel> GetbyId(int id)
        {
            var company = await _db.Company.FindAsync(id);
            var rate = _db.Rating.FirstOrDefault(x => x.Company_Id == id);
            var manager = await _user.FindByIdAsync(company.Manager_Id);
            var reviews = _db.Rating.Where(x => x.Company_Id == company.Company_Id).Select(s => s.Rate_Desc).ToList();
            var Cities = _db.Locationcompanies.Where(x => x.companyId == company.Company_Id).Select(s => s.City.City_Name).ToList();
            var CitiesIDs = _db.Locationcompanies.Where(x => x.companyId == company.Company_Id).Select(x => x.cityId).ToList();
            var Countries = _db.Locationcompanies.Where(x => x.companyId == company.Company_Id).Select(s => s.Country.Country_Name).ToList();
            var CountriesIDs = _db.Locationcompanies.Where(x => x.companyId == company.Company_Id).Select(x => x.countryId).ToList();
            ShowCompanyModel CompanyPage;
            if (rate == null)
            {
                CompanyPage = new ShowCompanyModel()
                {
                    CompanyName = company.CompanyName,
                    Phone = company.Phone,
                    Fax = company.Fax,
                    Website = company.Website,
                    Category = _db.Category.FirstOrDefault(x => x.Cat_Id == company.Category_Id).Cat_Desc,
                    CategoryID = company.Category_Id,
                    OverAllRate = overallavarge(company.Company_Id),
                    Reviews = reviews,
                    Citis = Cities,
                    Countries = Countries,
                    CountriesID = CountriesIDs,
                    CitisID = CitiesIDs,
                    Manager = manager.FName + " " + manager.LName,
                    LinkedProfile = company.LinkedProfile,
                    faceProfile = company.FaceProfile,
                    foundedDate = company.FoundedDate,
                    description = company.Description,
                    ManagerID = manager.UserName,
                    img = company.Image,
                    email = company.Email
                };
            }
            else
            {
                CompanyPage = new ShowCompanyModel()
                {
                    CompanyName = company.CompanyName,
                    Phone = company.Phone,
                    Fax = company.Fax,
                    Website = company.Website,
                    Category = _db.Category.FirstOrDefault(x => x.Cat_Id == company.Category_Id).Cat_Desc,
                    CategoryID = company.Category_Id,
                    WorkEnvironmentRate = rate.WorkEnvironmentRate,
                    SafetyRate = rate.SafetyRate,
                    SalRate = rate.SalRate,
                    ServiceRate = rate.ServiceRate,
                    OverAllRate = overallavarge(company.Company_Id),
                    Reviews = reviews,
                    Citis = Cities,
                    Countries = Countries,
                    CountriesID = CountriesIDs,
                    CitisID = CitiesIDs,
                    Manager = manager.FName + " " + manager.LName,
                    foundedDate = company.FoundedDate,
                    LinkedProfile = company.LinkedProfile,
                    faceProfile = company.FaceProfile,
                    description = company.Description,
                    ManagerID = manager.UserName,
                    img = company.Image,
                    email=company.Email
                };
            }

            return CompanyPage;
        }
        public async Task<CompanyModel> Add(CompanyModel t1)
        {

            var Manager = t1.Manager_Id.Contains('@') ? await _user.FindByEmailAsync(t1.Manager_Id) : await _user.FindByNameAsync(t1.Manager_Id);
            if (Manager.Id != null)
            {
                var company = new Company()
                {
                    CompanyName = t1.CompanyName,
                    Phone = t1.Phone,
                    Fax = t1.Fax,
                    Category_Id = t1.Category_Id,
                    Manager_Id = Manager.Id,
                    Website = t1.Website,
                    IsActive = true
                };
                _db.Company.Add(company);
                _db.SaveChanges();
                var com = _db.Company.FirstOrDefault(a => a.CompanyName == company.CompanyName && a.Category_Id == company.Category_Id);
                int id = _db.UserCompany.ToList().Count == 0 ? 1 : _db.UserCompany.Max(x => x.ID) + 1;
                var employee = new UserCompany()
                {       
                    User_Id = Manager.Id,
                    Company_Id = com.Company_Id,
                    StillWorking = true,
                    CanEdit = true,
                    title=58,
                    ID = id
                };

                
                t1.Message = "Succefully Added";
                _db.UserCompany.Add(employee);
                try
                {
                _db.SaveChanges();
                }
                catch (Exception)
                {
                    _db.Company.Remove(com);
                    _db.SaveChanges();
                    throw;
                }
                return t1;
            }
            else
                return new CompanyModel() { Message = "This Manager is not Exist" };
        }
        public async Task<bool> Delete(int CompanyId, string ManagerID)
        {
            UserCompany toBedeleted;
            var check = IsAllowed(CompanyId, ManagerID, out toBedeleted);
            if (check)
            {
                var result = _db.UserCompany.Remove(toBedeleted);
                if (result.State == Microsoft.EntityFrameworkCore.EntityState.Deleted)
                {
                    Company com = await _db.Company.FindAsync(CompanyId);
                    com.IsActive = false;
                    _db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public async Task<ShowCompanyModel> Edit(int CompanyID, ShowCompanyModel t1)
        {
            UserCompany toBeChecked;
            var Manager = await _user.FindByNameAsync(t1.ManagerID);
            var company = _db.Company.FirstOrDefault(x => x.Company_Id == CompanyID);
            var check = IsAllowed(company.Company_Id, Manager.Id, out toBeChecked);
            if (check)
            {
                company.CompanyName = t1.CompanyName;
                company.Category_Id = t1.CategoryID;
                company.Description = t1.description;
                company.Email = t1.email;
                company.Phone = t1.Phone;
                company.Fax = t1.Fax;
                company.FoundedDate = t1.foundedDate;
                company.FaceProfile = t1.faceProfile;
                company.LinkedProfile = t1.LinkedProfile;
                company.Website = t1.Website;
                _db.SaveChanges();
                t1.Message = "Done";
                return t1;
            }
            else
                return new ShowCompanyModel() { Message = "Error Occured" };
        }
        public async Task<LocationModel> addLocation(LocationModel obj)
        {
            var location = new locationcompany()
            {
                companyId = obj.CompanyID,
                cityId = obj.CityID,
                countryId = obj.CountryID,
            };
            var result = await _db.Locationcompanies.AddAsync(location);
            if (result.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                obj.Message = "Added";
                _db.SaveChanges();
                return obj;
            }
            else
            {
                return new LocationModel() { Message = "Error Occurred" };
            }
        }
        public async Task<EditLocation> EditLocation(EditLocation obj)
        {
            var userId = await _user.FindByNameAsync(obj.User);
            var checkManager =await _db.Company.FirstOrDefaultAsync(a => a.Manager_Id == userId.Id);
            if(checkManager==null)
                return new EditLocation() { Message = "Error Occurred" };
            else
            { 
                var loc = await _db.Locationcompanies.FirstOrDefaultAsync(x => x.companyId == obj.CompanyID);
                if (loc != null)
                {
                    loc.cityId = obj.CityID;
                    loc.countryId = obj.CountryID;
                    obj.Message = "EDited";
                    try
                    {
                        _db.SaveChanges();
                        return obj;

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
                else 
                {
                        return new EditLocation() { Message = "Error Occurred" };
                }
            }
        }
        public async Task<Company> GetonCompany(int id)
        {
            return await _db.Company.FirstOrDefaultAsync(x => x.Company_Id == id);
        }
        public async Task<List<AllCompanyDataModel>> GetAllbyCategoryID(int catID)
        {
            int len = _db.Company.ToList().Count();
            var companies = await _db.Company.Where(x => x.Category_Id == catID).Include(x => x.Category).ToListAsync();
            List<AllCompanyDataModel> AllCompanies = new List<AllCompanyDataModel>();
            for (int i = 0; i < companies.Count; i++)
            {
                AllCompanies.Add(new AllCompanyDataModel()
                {
                    companyID = companies[i].Company_Id,
                    categoryName = companies[i].Category.Cat_Desc,
                    overAllRate = overallavarge(companies[i].Company_Id),
                    companyName = companies[i].CompanyName
                });
            }
            return AllCompanies;
        }
        public async Task<List<AllCompanyDataModel>> SearchFilteration(int? countryid, int? cityid, int? categoryid)
        {
            #region MyRegion
            //if (compnayid != null)
            //{

            //    var companyonly = _db.Company.Where(a => a.Company_Id == compnayid).Select(b => b.Company_Id).FirstOrDefault();
            //    var company = new SearchModel()
            //    {
            //        Company_Id = companyonly,
            //    };
            //    return company;
            //}
            #endregion
            string folderName;/*For image file*/

            List<AllCompanyDataModel> companies = new List<AllCompanyDataModel>();
            if (countryid != null && cityid == null && categoryid == null)
            {

                var companycountries = await _db.Locationcompanies
                    .Where(c => c.countryId == countryid)
                    .Include(a => a.Company)
                    .Include(a => a.City)
                    .ToListAsync();

                var len = _db.Locationcompanies
                 .Where(c => c.countryId == countryid)
                 .Include(a => a.Company)
                 .ToList().Count();




                var company = await _db.Locationcompanies
                  .Where(c => c.countryId == countryid)
                  .Include(a => a.Company)
                  .ToListAsync();
                //var len = _db.CompanyLocations.Count(c => c.countryId == countryid);

                //  List<SearchModel> companies = new List<SearchModel>();
               
                for (int i = 0; i < len; i++)
                {
                    /*var cst =_db.Company.Where(a => a.Company_Id == companycountries[i].companyId).Select(a => a.Category.Cat_Desc).First()*/
                    var cst = _db.Company.Include(a => a.Category).FirstOrDefault(a => a.Company_Id == companycountries[i].companyId);
                    if (cst.Image != null)
                    {
                        folderName = Path.Combine("Resources", "Company", "images", cst.Image);
                    }
                    else
                    {
                        folderName = null;
                    }
                    companies.Add(new AllCompanyDataModel()
                    {
                        companyID = companycountries[i].companyId,
                        companyName = companycountries[i].Company.CompanyName,
                        categoryName = cst.Category.Cat_Desc,
                        overAllRate = overallavarge(companycountries[i].companyId),
                        Category_Id = companycountries[i].Company.Category_Id,
                        City_Name = companycountries[i].City.City_Name,
                        img = folderName
                    });

                }
                return companies;
            }
            else if (categoryid != null && cityid == null && countryid == null)
            {
                var companycategory = _db.Company
                    .Where(c => c.Category_Id == categoryid)
                    .Include(x => x.Category)

                    .ToList();


                var len = _db.Company.Count(c => c.Category_Id == categoryid);

                // List<SearchModel> companies = new List<SearchModel>();
                for (int i = 0; i < len; i++)
                {
                    var cst = _db.Company.Include(a=>a.Category).FirstOrDefault(a => a.Company_Id == companycategory[i].Company_Id);

                    if (cst.Image != null)
                    {
                        folderName = Path.Combine("Resources", "Company", "images", cst.Image);
                    }
                    else
                    {
                        folderName = null;
                    }
                    companies.Add(new AllCompanyDataModel()
                    {
                        companyID = companycategory[i].Company_Id,
                        companyName = companycategory[i].CompanyName,
                        categoryName = cst.Category.Cat_Desc,
                        overAllRate = overallavarge(companycategory[i].Company_Id),
                        Category_Id = companycategory[i].Category_Id,
                        img=folderName
                    });
                }
                return companies;
            }
            else if (countryid != null && cityid != null && categoryid == null)
            {

                var companycountriescity = _db.Locationcompanies
                    .Where(c => c.countryId == countryid && c.cityId == cityid)
                     .Include(a => a.Company)
                    .Include(a => a.City)
                    .Include(a => a.Country)
                    .ToList();

                var len = _db.Locationcompanies.Count(c => c.cityId == cityid);






                //  List<SearchModel> companies = new List<SearchModel>();
                for (int i = 0; i < len; i++)
                {
                    var cst = _db.Company.Include(a => a.Category).FirstOrDefault(a => a.Company_Id == companycountriescity[i].companyId);

                    if (cst.Image != null)
                    {
                        folderName = Path.Combine("Resources", "Company", "images", cst.Image);
                    }
                    else
                    {
                        folderName = null;
                    }
                    companies.Add(new AllCompanyDataModel()
                    {
                        companyID = companycountriescity[i].companyId,
                        companyName = companycountriescity[i].Company.CompanyName,
                        categoryName = cst.Category.Cat_Desc,
                        overAllRate = overallavarge(companycountriescity[i].companyId),
                        Category_Id = companycountriescity[i].Company.Category_Id,
                        img=folderName

                    });
                }
                return companies;

            }
            else if (countryid != null && categoryid != null && cityid == null)
            {
                var companycountrycat = (from m in _db.Company
                                         join dm in _db.Locationcompanies on m.Company_Id equals dm.Company.Company_Id
                                         join dist in _db.Category on m.Category_Id equals dist.Cat_Id
                                         where dist.Cat_Id == categoryid && dm.countryId == countryid
                                         select m
                                         )

                                         .ToList();

                var len = (from m in _db.Company
                           join dm in _db.Locationcompanies on m.Company_Id equals dm.Company.Company_Id
                           join dist in _db.Category on m.Category_Id equals dist.Cat_Id
                           where dist.Cat_Id == categoryid && dm.countryId == countryid
                           select m.Company_Id).Count();

                //  var len = _db.Company.Count(c => c.Category_Id == categoryid);

                // List<SearchModel> companies = new List<SearchModel>();
                for (int i = 0; i < len; i++)
                {
                    var cst = _db.Company.Include(a => a.Category).FirstOrDefault(a => a.Company_Id == companycountrycat[i].Company_Id);

                    if (cst.Image != null)
                    {
                        folderName = Path.Combine("Resources", "Company", "images", cst.Image);
                    }
                    else
                    {
                        folderName = null;
                    }
                    companies.Add(new AllCompanyDataModel()
                    {
                        companyID = companycountrycat[i].Company_Id,
                        companyName = companycountrycat[i].CompanyName,
                        categoryName = cst.Category.Cat_Desc,
                        overAllRate = overallavarge(companycountrycat[i].Company_Id),
                        Category_Id = companycountrycat[i].Category_Id,
                        img=folderName
                    });
                }
                return companies;

            }
            else if (countryid != null && categoryid != null && cityid != null)
            {
                var companycountrycatcit = (from m in _db.Company
                                            join dm in _db.Locationcompanies on m.Company_Id equals dm.Company.Company_Id
                                            join dist in _db.Category on m.Category_Id equals dist.Cat_Id
                                            where dist.Cat_Id == categoryid && dm.countryId == countryid && dm.cityId == cityid
                                            select m
                                            )

                                             .ToList();

                var length = (from m in _db.Company
                              join dm in _db.Locationcompanies on m.Company_Id equals dm.Company.Company_Id
                              join dist in _db.Category on m.Category_Id equals dist.Cat_Id
                              where dist.Cat_Id == categoryid && dm.countryId == countryid && dm.cityId == cityid
                              select m.Company_Id).Count();

                // var len = _db.Company.Count(c => c.Category_Id == categoryid);

                //  List<SearchModel> companies = new List<SearchModel>();
                for (int i = 0; i < length; i++)
                {
                    var cst = _db.Company.Include(a => a.Category).FirstOrDefault(a => a.Company_Id == companycountrycatcit[i].Company_Id);

                    if (cst.Image != null)
                    {
                        folderName = Path.Combine("Resources", "Company", "images", cst.Image);
                    }
                    else
                    {
                        folderName = null;
                    }
                    companies.Add(new AllCompanyDataModel()
                    {
                        companyID = companycountrycatcit[i].Company_Id,
                        companyName = companycountrycatcit[i].CompanyName,
                        categoryName = _db.Company.Where(a => a.Company_Id == companycountrycatcit[i].Company_Id).Select(a => a.Category.Cat_Desc).First(),
                        overAllRate = overallavarge(companycountrycatcit[i].Company_Id),
                        Category_Id = companycountrycatcit[i].Category_Id,
                        img=folderName
                    });
                }
                return companies;

            }
            else if (countryid == null && categoryid == null && cityid == null)
            {
                var AllCompanies = await _db.Company.ToListAsync();
                var len = AllCompanies.Count(); 
                for (int i = 0; i < len; i++)
                {
                    
                    if (AllCompanies[i].Image != null)
                    {
                        folderName = Path.Combine("Resources", "Company", "images", AllCompanies[i].Image);
                    }
                    else
                    {
                        folderName = null;
                    }
                    companies.Add(new AllCompanyDataModel()
                    {
                        companyID = AllCompanies[i].Company_Id,
                        companyName = AllCompanies[i].CompanyName,
                        categoryName = _db.Company.Where(a => a.Company_Id == AllCompanies[i].Company_Id).Select(a => a.Category.Cat_Desc).First(),
                        overAllRate = overallavarge(AllCompanies[i].Company_Id),
                        Category_Id = AllCompanies[i].Category_Id,
                        img = folderName
                    });
                }
                return companies;

            }
            else
                return companies;

        }

        public async Task<GetStatus> getNoOfReviewers(int companyID)
        {
            var result = new GetStatus();
            result.NoReviwers = await _db.Rating.CountAsync(x => x.Company_Id == companyID);
            result.Comments = await _db.Rating.CountAsync(x => x.Company_Id == companyID&&x.Rate_Desc!=string.Empty||x.Rate_Desc=="");
            result.OverAllRate = overallavarge(companyID);
            return result;
        }

        public async Task<List<string>> AllReviews(int companyID)
        {
            List<string> reviews = new List<string>();
            var Allreviews = await _db.Rating.Where(x => x.Company_Id == companyID).Select(a => a.Rate_Desc).ToListAsync();
            reviews.AddRange(Allreviews);
            return reviews;
        }

        public async Task<bool> DeactiveCompany(int companyID)
        {
            var company=await _db.Company.FindAsync(companyID);
            company.IsActive = false;
            var vacancies = await _db.CompanyVacany.Include(a => a.Vacancy).Where(a => a.Company_Id == companyID).ToListAsync();
            var usersincompany = await _db.UserCompany.Where(a => a.Company_Id == companyID).ToListAsync();
            foreach (var item in vacancies)
            {
                item.Vacancy.IsActive = false;  
            }
            foreach (var item in usersincompany)
            {
                item.StillWorking = false;
                item.CanEdit = false;
            }
            _db.SaveChanges();
            return true;

        }
    }
}
