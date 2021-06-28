using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Context;
using Microsoft.AspNet.Identity;
using Models;

namespace GraduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private string folderName;
        private readonly ApiDbContext _db;

        public FileController(ApiDbContext db)
        {
            _db = db;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadUserProfile/{username}")]
        public async Task<IActionResult> uploadUserProfile(string username)
        {
            var user = _db.User.FirstOrDefault(x => x.UserName == username);

            if (user == null)
                return BadRequest();
            else
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                if (file.Length > 0)
                {
                    var fileName_orgin = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var extention = fileName_orgin.Split('.')[1];
                    if (extention == "pdf")
                    {
                        folderName = Path.Combine("Resources", "User", "Documents");
                    }
                    else if (extention == "jpg" || extention == "png")
                    {
                        folderName = Path.Combine("Resources", "User", "Images");
                    }

                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var fileName = $"{username}.{extention}";
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    try
                    {
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);                            
                        }
                        if (extention == "pdf")
                        {
                            user.CV = fileName;
                        }
                        else if (extention == "jpg" || extention == "png")
                        {
                            user.Image = fileName;
                        }
                        _db.SaveChanges();

                    }
                    catch (Exception ex)
                    {

                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }

            
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadCompanyProfile/{id}")]
        public async Task<IActionResult> uploadCompanyProfile(int id)
        {
            var company = _db.Company.FirstOrDefault(x => x.Company_Id == id);

            if (company == null)
                return BadRequest();
            else
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                if (file.Length > 0)
                {
                    try
                    {
                        var fileName_orgin = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var extention = fileName_orgin.Split('.')[1];
                        /*if (extention == "pdf")
                        {
                            folderName = Path.Combine("Resources", "Company", "Documents");
                        }*/
                        if (extention == "jpg" || extention == "png")
                        {
                            folderName = Path.Combine("Resources", "Company", "Images");
                        }

                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                        var fileName = $"{company.CompanyName}.{extention}";
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        /*if (extention == "pdf")
                        {
                            user.CV = fileName;
                        }*/
                        if (extention == "jpg" || extention == "png")
                        {
                            company.Image = fileName;
                        }
                        _db.SaveChanges();
                        return Ok(new { dbPath });
                    }
                    catch (Exception ex)
                    {
                        return BadRequest();
                    }

                    
                }
                else
                {
                    return NotFound();
                }
            }
        }

        //Show Profile Picture
        [HttpGet, DisableRequestSizeLimit]
        [Route("getfile/{path}")]
        public IActionResult GetFile(string path)
        {
            try
            {
                var checkImage = _db.User.FirstOrDefault(x => x.UserName == path).Image;
                if (checkImage == null)
                    return NotFound();
                else
                {
                    var obj = new List<string>(); 
                    var folderName = Path.Combine("Resources", "User", "Images");
                    obj.Add( $"{ folderName}\\{checkImage}");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("getCompanyProfile/{path}")]
        public IActionResult getCompanyProfile(int path)
        {
            try
            {
                var checkImage = _db.Company.FirstOrDefault(x => x.Company_Id == path).Image;
                if (checkImage == null)
                    return NotFound();
                else
                {
                    var obj = new List<string>();
                    var folderName = Path.Combine("Resources", "Company", "Images");
                    obj.Add($"{ folderName}\\{checkImage}");
                    return Ok(obj);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet, DisableRequestSizeLimit]
        [Route("download/{filename}")]
        public async Task<IActionResult> Download(string filename)
        {
            var folderName = Path.Combine("Resources", "User", "Documents", filename);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();
            try
            {
                var memory = new MemoryStream();
                await using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(filePath), filePath);
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

        //With Download api
        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }

        

    }
}
