using Context;
using GraduationProject.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class auth :Iauth
    {
        private readonly JWT _jwt;
        private readonly UserManager<User> _user;
        private readonly ApiDbContext _db;
        private readonly RoleManager<IdentityRole> _role;
        public auth(UserManager<User> user,IOptions<JWT> jwt, ApiDbContext db, RoleManager<IdentityRole> role)
        {
            _user = user;
            _jwt = jwt.Value;
            _db = db;
            _role = role;
        }

        public async Task<JwtSecurityToken> Generatetoken(User user)
        {
            var Userclaims = await _user.GetClaimsAsync(user); //get user claims
            var Userroles = await _user.GetRolesAsync(user); //get user rols
            var Roleclaims = new List<Claim>();
            foreach (var item in Userroles)
            {
                Roleclaims.Add(new Claim("roles", item));
            }
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //New ID for each claim
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim("uid", user.Id)
            }.Union(Userclaims).Union(Roleclaims);
            var symmetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingcredentials = new SigningCredentials(symmetrickey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
             issuer: _jwt.Issuer,
             audience: _jwt.Audience,
             claims: claims,
             expires: DateTime.Now.AddDays(_jwt.DurationInDay),
             signingCredentials: signingcredentials);
            return jwtSecurityToken;
        }

        public async Task<Authentication> RegisterAsync(RegisterModel rm)
        {
           
            if (await _user.FindByEmailAsync(rm.Email) !=null)
                return new Authentication { Message = "E-mail already Existed" };
            if (await _user.FindByNameAsync(rm.Username) != null)
                return new Authentication { Message = "UserName already Existed" };
            var user = new User()
            {
                FName = rm.Firstname,
                LName = rm.Lastname,
                Email = rm.Email,
                UserName = rm.Username,
                Country_Id = rm.countryid,
                City_Id = rm.cityid,
                birthday = rm.birthdate,
                PhoneNumber = rm.phone,
                Gender = rm.Gender,
                Strength = 0.25f,
                JoinedDate = DateTime.Now,
                IsActive = true
            };
            var result = await _user.CreateAsync(user, rm.Password);
            if (!result.Succeeded)
            {
                var errs = "";
                foreach (var item in result.Errors)
                {
                    errs = $"{item.Description} , ";
                }
                return new Authentication { Message = errs };
            }
            var token= await Generatetoken(user);
            await _user.AddToRoleAsync(user, "User");

            return new Authentication
            {
                email = user.Email,
                Tokenlife = token.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.UserName,
                userID = user.Id,
            };
        }


        //Admin Role 
        //[Authorize(Roles = "Admin")]
        public async Task<Authentication> RegisterAsyncAdmin(RegisterModel rm)
        {

            if (await _user.FindByEmailAsync(rm.Email) != null)
                return new Authentication { Message = "E-mail already Existed" };
            if (await _user.FindByNameAsync(rm.Username) != null)
                return new Authentication { Message = "UserName already Existed" };
            var user = new User()
            {
                FName = rm.Firstname,
                LName = rm.Lastname,
                Email = rm.Email,
                UserName = rm.Username,
                Country_Id = rm.countryid,
                City_Id = rm.cityid,
                birthday = rm.birthdate,
                PhoneNumber = rm.phone,
                Gender = rm.Gender,
                Strength = 0.25f,
                JoinedDate = DateTime.Now,
                IsActive = true

            };
            var result = await _user.CreateAsync(user, rm.Password);
            if (!result.Succeeded)
            {
                var errs = "";
                foreach (var item in result.Errors)
                {
                    errs = $"{item.Description} , ";
                }
                return new Authentication { Message = errs };
            }
            await _user.AddToRoleAsync(user, "Admin");
            var token = await Generatetoken(user);

            return new Authentication
            {
                email = user.Email,
                Tokenlife = token.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Admin" },
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.UserName,
                userID = user.Id,
                Strength=user.Strength,
                
            };
        }
        public async Task<Authentication> LogInAsync(LogInModel lm)
        {  
            var user = lm.Username.Contains('@')? await _user.FindByEmailAsync(lm.Username): await _user.FindByNameAsync(lm.Username);

            var ValidPassword = await _user.CheckPasswordAsync(user, lm.Password);
            if (user.IsActive == true)
            {
                if (user == null || !ValidPassword)
                {
                    return new Authentication { Message = "Invalid Username or Password" };

                }
                else
                {
                    var token = await Generatetoken(user);

                    var userID = await _db.Users.Where(a => a.UserName == lm.Username).Select(a => a.Id).FirstOrDefaultAsync();
                    var RoleID = await _db.UserRoles.Where(a => a.UserId == userID).Select(a => a.RoleId).FirstOrDefaultAsync();
                    //var Username = user.UserName;
                    //var Email = user.Email;
                    //var Tokenlife = token.ValidTo;
                    ////var IsAuthenticated = true;
                    //var Roles = await _db.Roles.Where(a => a.Id == RoleID).Select(a => a.Name).ToListAsync();

                    //var userIDyy = user.Id;
                    //var canEdit =_db.UserCompany.FirstOrDefault(a => a.User_Id == userID)==null?false: _db.UserCompany.FirstOrDefault(a => a.User_Id == userID && a.StillWorking == true && a.CanEdit == true).CanEdit;
                    //var Strength = await _db.User.Where(a => a.Id == userID).Select(a => a.Strength).FirstOrDefaultAsync();
                    //var companyId = await _db.UserCompany.Where(a => a.User_Id == userID && a.StillWorking == true).Select(a => a.Company_Id).FirstOrDefaultAsync();
                    //var isRelated = _db.UserCompany.Where(a => a.User_Id == userID).Select(a => a.Company_Id).ToList();
                    var role = _db.Roles.Where(a => a.Id == RoleID).Select(a => a.Name);
                    var can = _db.UserCompany.FirstOrDefault(a => a.User_Id == user.Id && a.StillWorking == true && a.CanEdit == true);
                    var res = can != null?can.CanEdit: false;
                    var Token = new JwtSecurityTokenHandler().WriteToken(token);
                    var comId = 0;
                   //var  companyId = _db.UserCompany.FirstOrDefault(a => a.User_Id == user.Id && a.CanEdit == true).Company_Id;
                    var company = _db.UserCompany.FirstOrDefault(a => a.User_Id == user.Id && a.CanEdit == true);
                    if(company != null)
                    {
                        comId = company.Company_Id;
                    }
                    Authentication auth = new Authentication
                    {
                        Username = user.UserName,
                        Email = user.Email,
                        Tokenlife = token.ValidTo,
                        IsAuthenticated = true,
                        Roles =await _db.Roles.Where(a => a.Id == RoleID).Select(a => a.Name).ToListAsync(),
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        userID = user.Id,
                        canEdit =res,
                        Strength = await _db.User.Where(a => a.Id == user.Id).Select(a => a.Strength).FirstOrDefaultAsync(),
                        companyId = comId,
                    isRelated = _db.UserCompany.Where(a => a.User_Id == user.Id).Select(a => a.Company_Id).ToList()
                    };

                    return auth;
                }
            }
            else
                return new Authentication() { Message="Invalid details"};
        }
    }
}
