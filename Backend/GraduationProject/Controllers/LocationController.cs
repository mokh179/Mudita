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
    public class LocationController : ControllerBase
    {
        private readonly IDBOperations<City> _dBCity;
        private readonly IDBOperations<Countries> _dBCountry;

        public LocationController(IDBOperations<City> dBCity, IDBOperations<Countries> dBCountry)
        {
            _dBCity = dBCity;
            _dBCountry = dBCountry;
        }
        

        // GET: api/City/5
        [HttpGet("city/{id}")]
        public async Task<IActionResult> GetCity( int id)
        {
            return Ok(await _dBCity.GetbyId(id.ToString()));
        }

        // GET: api/City/id
        [HttpGet("cityBYcounty/{countryid}")]
        public async Task<IActionResult> SelCityByCountryID(int countryid)
        {
            var cities = await _dBCity.SelCityByCountryID(countryid);
            return Ok(cities);
        }

        // GET: api/Country
        [HttpGet("Country")]
        public async  Task<IActionResult> GetCountry()
        {
            var countries =await  _dBCountry.GetAll();
            return Ok(countries);
        }

        // GET: api/Country/5
        [HttpGet("Country/{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            return Ok(await _dBCountry.GetbyId(id.ToString()));
        }
        [HttpGet("getCities")]
        public IActionResult getCities()
        {
            return Ok(_dBCity.GetAll());
        }
    }
}
