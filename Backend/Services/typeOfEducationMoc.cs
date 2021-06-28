using Models;
using System;
using Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class typeOfEducationMoc : IDBOperations<typeOfEducation> 
    {
        private readonly ApiDbContext _db;

        public typeOfEducationMoc(ApiDbContext db)
        {
            _db = db;
        }
        public async Task<typeOfEducation> Add(typeOfEducation t1)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async  Task<typeOfEducation> Edit(typeOfEducation t1)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<typeOfEducation>> GetAll()
        {
            return await  _db.typeOfEducations.ToListAsync();
        }

        public async Task<typeOfEducation> GetbyId(string id)
        {
            return _db.typeOfEducations.FirstOrDefault(x=>x.ID==int.Parse(id));
        }

        public Task<List<typeOfEducation>> SelCityByCountryID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
