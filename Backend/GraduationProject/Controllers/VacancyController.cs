using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Interfaces;
using Services.ViewModels;
using Services.ViewModels.Vacancy;
using Services.ViewModels.Vacancy.GET_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancy _db;
        public VacancyController(IVacancy db)
        {
            _db = db;
        }
        [HttpPost("PostAJob")]
        public async Task<IActionResult> postjob(VacancyViewModel vc)
        {
            if (!ModelState.IsValid)
                return BadRequest(vc);
            else
            {

                var res=await _db.EditVacancy(vc);
                if (res == "Done")
                    return Ok();
                else
                    return BadRequest(vc);
            }
        }
        [HttpGet("GetVacanciesBYcomapany/{id}")]
        public async Task<IActionResult> companyVacancies(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await  _db.getAllByCompany(id);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpGet("GetVacanciesFORuser")]
        public async Task<IActionResult> userVacancies(string userName)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.getAll(userName);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpGet("GetVacanciesBYid/{id}")]
        public async Task<IActionResult> GetVacanciesBYid(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await  _db.getByID(id);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpDelete("DeleteVacancy/{id}")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.Delete(id);
                if (result == true)
                    return Ok();
                else
                    return BadRequest();
            }
        }
        [HttpPost("Apply")]
        public async Task<IActionResult> Apply(Applied_Vacancy_Model vm)
        {
            if (!ModelState.IsValid)
                 return BadRequest();
            else
            {
                var result = await _db.Apply(vm);
                if (result == true)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }
        [HttpGet("GetApplieduser/{usernaemr}")]
        public async Task<IActionResult> GetApplieduser(string usernaemr)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var result = await _db.GetUserVacancy(usernaemr);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
        }

        [HttpGet("GetAllcompanyJobs/{id}")]
        public async Task<IActionResult> getAllJobsforCountries(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var res= await _db.getAllByCompany(id);
                return Ok(res);
            }
        }

        [HttpGet("GetResumes")]
        public async Task<IActionResult> GetResumes(int comID, int VacID)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var res = await _db.GetResumes(comID, VacID);
                return Ok(res);
            }
        }

        [HttpPost("changeStatus")]
        public async Task<IActionResult> changeStatus(GETAplicantVacany st)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var res = await _db.changeStatus(st);
                return Ok(res);
            }
        }
        [HttpPut("withDraw")]
        public async Task<IActionResult> withDraw(int id,string username)
        {
            if (id != null || username == string.Empty)
            {
                if (await _db.withdraw(id, username))
                    return Ok();
                else
                    return BadRequest();
            }
            else
                return BadRequest();

        }
    }
}
