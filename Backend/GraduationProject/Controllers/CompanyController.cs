using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Interfaces;
using Services.ViewModels;
using Services.ViewModels.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _db;

        public CompanyController(ICompany db)
        {
            _db = db;
        }

        [HttpGet("companies")]
        public async Task<IActionResult> AllCompanies()
        {
            return Ok(await _db.GetAll());
        }

        [HttpGet("companies/{id}")]
        public async Task<IActionResult> AllCompaniesbyID(int id)
        {
            return Ok(await _db.GetAllbyCategoryID(id));
        }

        [HttpGet("GetAllCompare")]
        public async Task<IActionResult> GetAllCompare(string CompanyName)
        {
            return Ok(await _db.GetAllCompare(CompanyName));
        }


        [HttpGet("GetonCompare/{id}")]
        public async Task<IActionResult> GetonCompare(int id)
        {
            return Ok(await _db.GetonCompany(id));
        }


        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNewCompany([FromBody] CompanyModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var res = await _db.Add(obj);
                return Ok(obj);
            }
        }
        [HttpPost("SetupLocation")]
        public async Task<IActionResult> Loaction([FromBody] LocationModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                await _db.addLocation(obj);
                return Ok();
            }
        }
        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> EditLoaction([FromBody] EditLocation obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                await _db.EditLocation(obj);
                return Ok();
            }
        }
        [HttpPut("UpdateCompany/{id}")]
        public async Task<IActionResult> Update(int ID, [FromBody] ShowCompanyModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                await _db.Edit(ID, obj);
                return Ok(obj);
            }
        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody] string MngID)
        {
            if (id == null)
                return NotFound();
            else
            {
                await _db.Delete(id, MngID);
                return NoContent();
            }

        }
        [HttpGet("GetCompareById")]
        public async Task<IActionResult> GetCompareById(string name1, string name2)
        {
            return Ok(await _db.GetCompareById(name1, name2));
        }



        //GET: api/Search
        [HttpGet("Search")]

        public async Task<IActionResult> SearchFilteration(int? countryid, int? cityid, int? categoryid)
        {
            var company = await _db.SearchFilteration(countryid, cityid, categoryid);
            return Ok(company);
        }

        [HttpGet("Company/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                return Ok(await _db.GetbyId(id));
            }

        }

        [HttpGet("GetStatus/{id}")]
        public async Task<IActionResult> GetStatus(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                return Ok(await _db.getNoOfReviewers(id));
            }
        }

        [HttpGet("Reviews/{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                return Ok(await _db.AllReviews(id));
            }
        }
        [HttpDelete("Deactivate/{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            if (id != null)
            {
                var res = await _db.DeactiveCompany(id);
                if (res)
                    return Ok();
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }
    }
}
 