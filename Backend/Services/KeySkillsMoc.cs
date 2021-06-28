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
    public class KeySkillsMoc : IDBOperations<KeySkills>
    {
        private readonly ApiDbContext _db;

        public KeySkillsMoc(ApiDbContext db)
        {
            _db = db;
        }
        public async Task<KeySkills> Add(KeySkills t1)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<KeySkills> Edit(KeySkills t1)
        {
            throw new NotImplementedException();
        }

        public async Task<List<KeySkills>> GetAll()
        {
            return await _db.KeySkills.ToListAsync();
        }

        public async  Task<KeySkills> GetbyId(string id)
        {
            return await  _db.KeySkills.FirstOrDefaultAsync(x=>x.Id == int.Parse(id));
        }

        public Task<List<KeySkills>> SelCityByCountryID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
