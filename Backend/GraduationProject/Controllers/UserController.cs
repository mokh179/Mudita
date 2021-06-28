using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using Services.Interfaces;
using Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _db;
        public UserController(IUser db)
        {
            _db = db;
        }
        [HttpGet("EditBasicInfo/{id}")]
        public async Task<IActionResult> GetbasicInformation(String id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.GetBasic(id);
                if (result.Message == "Successed")
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

       [HttpPost("EditBasicInfo")]
       public async Task<IActionResult> basicInformation(BasicInfoModel obj)
       {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result=await _db.EditBasic(obj);
                if (result.Message == "Successed")
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }


        [HttpGet("EditResume/{id}")]
        public async Task<IActionResult> resumInformation(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.GetuserRusme(id);
                if (result!=null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpPost("EditResume")]
        public async Task<IActionResult> resumInformation(userResumeModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.userResume(obj);
                if (result.Message == "Successed")
                    return Ok();
                else
                    return BadRequest();
            }
        }


        [HttpGet("EditSkills/{id}")]
        public async Task<IActionResult> KeySkills(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.GetuserSkills(id);
                if (result.Message == "Successed")
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpPut("EditSkills")]
        public async Task<IActionResult> KeySkills(SkillsModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.userSkills(obj);
                if (result.Message == "Successed")
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpGet("EditEducation/{id}")]
        public async Task<IActionResult> Education(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.GetuserEducation(id);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpPost("EditEducation")]
        public async Task<IActionResult> Education(userEducationModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.userEducation(obj);
                if (result.Message == "Successed")
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpPut("ResetPass")]
        public async Task<IActionResult> Pass(PassModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                if (await _db.resetPassword(obj))
                    return Ok();
                else
                    return BadRequest("An Error Occured");
            }
        }

        [HttpGet("SocialMedia/{id}")]
        public async Task<IActionResult> SocialMedia(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.GetuserOnlineProfile(id);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpPost("SocialMedia")]
        public async Task<IActionResult> SocialMedia(SocialMedia obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.userOnlineProfile(obj);
                if (result.Message == "Successed")
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }
        // Delete: api/user/
        [HttpDelete("DelUser")]
        public async Task<IActionResult> DelUsr(string usrname)
        {
            return Ok(await _db.DelUser(usrname));

        }

        [HttpDelete("DeleteEduHistroy/{id}")]
        public async Task<IActionResult> DeleteEduHistroy(int id)
        {
            var result = await _db.DeleteEduHistroy(id);
            if (result == true)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpDelete("DeleteEmpHistroy/{id}")]
        public async Task<IActionResult> DeleteEmpHistroy(int id)
        {
            var result = await _db.DeleteEmpHistroy(id);
            if (result == true)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpDelete("Deleteonlineprofile/{id}")]
        public async Task<IActionResult> Deleteonlineprofile(int id)
        {
            var result = await _db.Deleteonlineprofile(id);
            if (result == true)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
