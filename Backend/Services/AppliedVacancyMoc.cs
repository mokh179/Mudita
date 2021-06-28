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
    public class AppliedVacancyMoc : IDBOperations<AppliedVacancy>
    {
        private readonly ApiDbContext _db;

        public AppliedVacancyMoc(ApiDbContext db)
        {
            _db = db;
        }
        public async Task<AppliedVacancy> Add(AppliedVacancy t1)
        {
            _db.AppliedVacancy.Add(t1);
            _db.SaveChanges();
            return t1;
        }

        public async Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<AppliedVacancy> Edit(AppliedVacancy t1)
        {
            _db.Update(t1);
            _db.SaveChanges();
            return t1;
        }

        public async Task<List<AppliedVacancy>> GetAll()
        {
            return await _db.AppliedVacancy.ToListAsync();
        }

        public async Task<AppliedVacancy> GetbyId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppliedVacancy>> SelCityByCountryID(int id)
        {
            throw new NotImplementedException();
        }
       
    }
}
