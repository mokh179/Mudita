using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducation _db;

        public EducationController(IEducation db )
        {
            _db = db;
        }
        
        [HttpGet("typeofEducation")]
        public async  Task<IActionResult> GetAll()
        {
            return Ok(await _db.AllTypeEdu());
        }

        [HttpGet("typeofEducation/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            return Ok(await _db.OneTypeEdu(id));
        }

        [HttpGet("UserEducation/{id}")]
        public async Task<IActionResult> GetByUSerID(string id)
        {
            return Ok(await _db.OneUserEdu(id));
        }
    }
}
