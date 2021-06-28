using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class Authentication : ControllerBase
    {
        private Iauth _auth;

        public Authentication(Iauth auth)
        {
            _auth = auth;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> Register([FromBody] RegisterModel rm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _auth.RegisterAsync(rm);
            if (!res.IsAuthenticated)
                return BadRequest(res.Message);
            return Ok(res);
        }

        [HttpPost("AdminSignUp")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel rm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _auth.RegisterAsyncAdmin(rm);
            if (!res.IsAuthenticated)
                return BadRequest(res.Message);
            return Ok(res);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInModel lm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _auth.LogInAsync(lm);
            if (!res.IsAuthenticated)
                return BadRequest(res.Message);
            return Ok(res);
        }
    }
}
