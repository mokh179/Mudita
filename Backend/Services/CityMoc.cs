using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CityMoc: IDBOperations<City>
    {
        private readonly ApiDbContext _db;

        public CityMoc(ApiDbContext db)
        {
            _db = db;
        }
        public async Task<City>  Add(City t1)
        {
            _db.City.Add(t1);
            _db.SaveChanges();
            return t1;
        }

        public async Task<bool> Delete(string id)
        {
            _db.City.Remove(await _db.City.FirstOrDefaultAsync(m => m.City_Id == int.Parse(id)));
            _db.SaveChanges();
            return true;
        }

        public async Task<City> Edit(City t1)
        {
              _db.Update(t1);
            _db.SaveChanges();
            return t1;
        }

        public async Task<List<City>> GetAll()
        {
            return await _db.City.Include(a => a.Country).ToListAsync();
        }
        public async Task<City> GetbyId(string id)
        {
            return await _db.City.Where(a => a.City_Id == int.Parse(id)).FirstOrDefaultAsync();            
        }
        public async Task<List<City>> SelCityByCountryID(int countryid)
        {
            var city = await _db.City.Where(a => a.Country_Id == countryid).ToListAsync();
            return city; 
        }
   
    }
}
