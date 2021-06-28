using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Interfaces;
using Services.ViewModels.Admin;
using Services.ViewModels.Vacancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _db;
        private readonly ICompany _dbcom;

        public AdminController(IAdmin db,ICompany dbcom )
        {
            _db = db;
            _dbcom = dbcom;
        }
        
        //from UserMoc
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DelUsr(string usrname)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteUser(usrname);
                return Ok(result);

        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetAllUsers();
            return Ok(result);
        }

        //Vacancy Functions 



        [HttpDelete("DeleteVacancies/{id}")]
        public async Task<IActionResult> DeleteVacancy(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteVacancy(id);
            return Ok(result);
        }

        [HttpGet("GetCloseVacancy")]
        public async Task<IActionResult> GetCloseVacancy()
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetCloseVacancy();
            return Ok(result);
        }

        //Country Functions

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetAllCountries();
              return Ok(result);
        }

        [HttpPost("AddCountry")]
        public async Task<IActionResult> AddCountry(AdminCountryModel c1)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.AddCountry(c1);
            return Ok(result);
        }
        [HttpGet("GetCountrybyId")]
        public async Task<IActionResult> GetCountrybyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetCountrybyId(id);
             return Ok(result);
        }

        [HttpPut("EditCountry")]
        public async Task<IActionResult> EditCountry(AdminCountryModel c1)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.EditCountry(c1);
            return Ok(result);
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteCountry(id);
            return Ok(result);
        }




        //City Func


        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetAllCities();
            return Ok(result);
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity(AdminCityModel c1)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.AddCity(c1);
            return Ok(result);
        }
        [HttpGet("GetCitybyId")]
        public async Task<IActionResult> GetCitybyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetCitybyId(id);
            return Ok(result);
        }

        [HttpPut("EditCity")]
        public async Task<IActionResult> EditCity(AdminCityModel c1)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.EditCity(c1);
            return Ok(result);
        }

        [HttpDelete("DeleteCity")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteCity(id);
            return Ok(result);
        }


        //Category Func 


        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetAllCategory();
            return Ok(result);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(AdminCategoryModel c1)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.AddCategory(c1);
            return Ok(result);
        }


        [HttpGet("GetCategorybyId")]
        public async Task<IActionResult> GetCategorybyId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.GetCategorybyId(id);
            return Ok(result);
        }

        [HttpPut("EditCategory")]
        public async Task<IActionResult> EditCategory(AdminCategoryModel c1)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.EditCategory(c1);
            return Ok(result);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteCategory(id);
            return Ok(result);
        }


       // Company Func

        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _db.DeleteCompany(id);
            return Ok(result);
        }

        [HttpGet("AdminGetAll")]
        public async Task<IActionResult> AdminGetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _dbcom.AdminGetAll();
            return Ok(result);
        }
        //Count Func 



        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var result =  _db.GetAllUser();
            return Ok(result);
        }
        [HttpGet("GetAllActiveUser")]
        public IActionResult GetAllActiveUser()
        {
            var result = _db.GetAllActiveUser();
            return Ok(result);
        }


        [HttpGet("GetAllDeactiveUser")]
        public IActionResult GetAllDeactiveUser()
        {
            var result = _db.GetAllDeactiveUser();
            return Ok(result);
        }


        [HttpGet("GetAllCompany")]
        public IActionResult GetAllCompany()
        {
            var result = _db.GetAllCompany();
            return Ok(result);
        }
        [HttpGet("GetAllActiveCompany")]
        public IActionResult GetAllActiveCompany()
        {
            var result = _db.GetAllActiveCompany();
            return Ok(result);
        }


        [HttpGet("GetAllDeactiveCompany")]
        public IActionResult GetAllDeactiveCompany()
        {
            var result = _db.GetAllDeactiveCompany();
            return Ok(result);
        }


        [HttpGet("GetAllVacancy")]
        public IActionResult GetAllVacancy()
        {
            var result = _db.GetAllVacancy();
            return Ok(result);
        }
        [HttpGet("GetAllActiveVacancy")]
        public IActionResult GetAllActiveVacancy()
        {
            var result = _db.GetAllActiveVacancy();
            return Ok(result);
        }


        [HttpGet("GetAllDeactiveVacancy")]
        public IActionResult GetAllDeactiveVacancy()
        {
            var result = _db.GetAllDeactiveVacancy();
            return Ok(result);
        }


        [HttpGet("GetAllJobCat")]
        public IActionResult GetAllJobCat()
        {
            var result = _db.GetAllJobCat();
            return Ok(result);
        }
        [HttpGet("GetAllJobTitle")]
        public IActionResult GetAllJobTitle()
        {
            var result = _db.GetAllJobTitle();
            return Ok(result);
        }

    }
}
