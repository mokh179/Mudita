using Models;
using Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class UserEducationMoc : IDBOperations<userEducation>
    {
        private readonly ApiDbContext _db;

        public UserEducationMoc(ApiDbContext db)
        {
            _db = db;
        }
        public async Task<userEducation> Add(userEducation t1)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async  Task<userEducation> Edit(userEducation t1)
        {
            throw new NotImplementedException();
        }

        public async Task<List<userEducation>> GetAll()
        {
            return await _db.userEducations.ToListAsync();
        }

        public Task<userEducation> GetbyId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<userEducation>> SelCityByCountryID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
