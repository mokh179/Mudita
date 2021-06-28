using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountryMoc : IDBOperations<Countries>
    {
        private readonly ApiDbContext _db;

        public CountryMoc(ApiDbContext db)
        {
            _db = db;
        }
        public async Task<Countries> Add(Countries t1)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Countries> Edit(Countries t1)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Countries>> GetAll()
        {
            return await _db.Countries.ToListAsync(); 
        }

        public async Task<Countries> GetbyId(string id)
        {
           return  await _db.Countries.FirstOrDefaultAsync(x=>x.country_id == int.Parse(id));  
        }  
        public async Task<List<Countries>> SelCityByCountryID(int id)
        {
            throw new NotImplementedException();
        }

    }
}
