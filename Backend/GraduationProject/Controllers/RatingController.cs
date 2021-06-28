using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRating _db;

        public RatingController(IRating db)
        {
            _db = db;
        }
        [HttpPost("GiveRate")]
        public async Task<IActionResult> GiveRate(RatingModel rm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else 
            {
                var result =await _db.Give_A_Rate(rm);
                if (result == "done") 
                    return Ok();
                else
                    return BadRequest(result);
            }
        }
    }
}
