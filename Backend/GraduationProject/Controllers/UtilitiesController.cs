using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitiesController : ControllerBase
    {
        private readonly IDBOperations<KeySkills> _dbskills;
        private readonly IDBOperations<Category> _dbcat;
        private readonly IDBOperations<JobCategory> _dbJobCat;
        private readonly IDBOperations<JobType> _dbJobType;

        public UtilitiesController(IDBOperations<KeySkills> dbskills,
                                   IDBOperations<Category> dbCat,
                                   IDBOperations<JobCategory> dbJobCat,
                                   IDBOperations<JobType> dbJobType
                                  )
        {
            _dbskills = dbskills;
            _dbcat = dbCat;
            _dbJobCat = dbJobCat;
            _dbJobType = dbJobType;
        }

        [HttpGet("AllSkills")]
        public async Task<IActionResult> GetSkills()
        {
            return Ok(await _dbskills.GetAll());
        }

        [HttpGet("AllSkills/{id}")]
        public async Task<IActionResult> GetOneSkills(string id)
        {
            return Ok(await _dbskills.GetbyId(id));
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _dbcat.GetAll());
        }
        [HttpGet("jobTypes")]
        public async Task<IActionResult> JobTypes()
        {
            return Ok(await _dbJobType.GetAll());
        }
        [HttpGet("AllJobCategory")]
        public async Task<IActionResult> GetAllJobCategory()
        {
            return Ok(await _dbJobCat.GetAll());
        }

        [HttpGet("JobCategoryBYcategory/{id}")]
        public async  Task<IActionResult> GetJobCategoryBycategory(int id)
        {
            return Ok(await _dbJobCat.SelCityByCountryID(id));
        }

        [HttpGet("JobCategory/{id}")]
        public async Task<IActionResult> GetJobCategory(int id)
        {
            return Ok(await _dbJobCat.GetbyId(id.ToString()));
        }


    }
}
