using Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduationProject.Helper;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Context;

namespace Services
{
      public class Rate : IRating
       {
        private ApiDbContext _db;
        private readonly UserManager<User> _user;
       
        public Rate( ApiDbContext db ,UserManager<User> user)
        {
            _user = user;
            _db = db; 
            
        }
        private Boolean checkuser( int company_Id, string userName,out string usrID)
        {
            var user =_user.FindByNameAsync(userName).Result;
              if (user!= null) 
            {
                var us = _db.UserCompany.FirstOrDefault(u => u.User_Id == user.Id && u.Company_Id == company_Id);
                if (us == null)
                {
                    usrID = string.Empty;
                    return false;
                }
                else
                {
                    usrID = user.Id;
                    return true;
                }
            }
            else
            {
                usrID = string.Empty;
                return false;
            }
        }
        public async Task<string> Give_A_Rate(RatingModel rm)
        {
            string userID;
            bool exist = checkuser(rm.Company_Id, rm.user_Name, out userID);
            if (!exist)
            {
                return ("An Error Occured");
            }
            else
            {
                var rating = _db.Rating.FirstOrDefault(x => x.User_Id == userID && x.Company_Id == rm.Company_Id);
                double overall = (rm.SalRate + rm.SafetyRate + rm.WorkEnvironmentRate + rm.ServiceRate) / 4;
                if (rating!=null)
                {
                    rating.SalRate = rm.SalRate;
                    rating.SafetyRate = rm.SafetyRate;
                    rating.WorkEnvironmentRate = rm.WorkEnvironmentRate;
                    rating.ServiceRate = rm.ServiceRate;
                    rating.Rate_Desc = rm.Rate_Desc;
                    rating.OverAllRate = overall;
                    _db.SaveChanges();
                    return "done";
                }
                else
                {
                    var rate = new Rating()
                    {
                        Company_Id = rm.Company_Id,
                        User_Id = userID,
                        SalRate = rm.SalRate,
                        SafetyRate = rm.SafetyRate,
                        WorkEnvironmentRate = rm.WorkEnvironmentRate,
                        ServiceRate = rm.ServiceRate,
                        Rate_Desc = rm.Rate_Desc,
                        OverAllRate = overall
                    };
                    var result = await _db.Rating.AddAsync(rate);
                    if (result.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                    {
                        _db.SaveChanges();
                        return "done";
                    }
                    else
                        return "An Error Occured";
                }
              
            }
        }

      
    }
}
