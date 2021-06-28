using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using Services.ViewModels;
using Services.ViewModels.Interview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewQuesController : ControllerBase
    {
        private readonly IInterviewQues _db;
        public InterviewQuesController(IInterviewQues db)
        {
            _db = db;
        }


        [HttpGet("interviewques")]
        public async Task<IActionResult> AllQues()
        {
            return Ok(await _db.GetAll());
        }

        // POST: api/Question
        [HttpPost]
        public async Task<ActionResult<InterviewQuesModel>> PostQuestion(InterviewQuesModel Q)
        {
            await _db.Add(Q);
            return Ok(Q);
        }

       
        //[HttpGet("userques")]
        [HttpGet("GetAllUsrId")]
        public async Task<IActionResult> GetAllUsrId(string UsrName)
        {
            return Ok(await _db.GetAllUsrId(UsrName));
        }
 

        //[HttpGet("getquesbyQid")]
        [HttpGet("GetQuesbyQId")]
        public async Task<IActionResult> GetQuesbyQId( int QId)
        {
            return Ok(await _db.GetQuesbyQId(QId));
        }


        //[HttpGet("GetAllJobCategoy")]
        [HttpGet("GetAllJobCategoy")]
        public async Task<IActionResult> GetAllJobCategoy(string JCName)
        {
            return Ok(await _db.GetAllJobCategoy(JCName));
        }


        // Delete: api/Question
        [HttpDelete("DelQues")]
        public async Task<IActionResult> DelQues(int id)
        {
            return Ok(await _db.DelQues(id));

        }


        // Put: api/Question
        [HttpPut("EditQues")]
        public async Task<IActionResult> EditQues(InterviewQuesModel Q)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var res = await _db.EditQues(Q);
                if (res)
                    return Ok(res);
                else
                    return NotFound(res);
            }
          

        }

        // POST: api/Question
        [HttpPost("React")]
        public async Task<IActionResult> React(voteModel obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                var res = await _db.React(obj);
                if (res)
                    return Ok(res);
                else
                    return BadRequest(res);
            }
           
        }


    }
}
