using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JobtypesMoc : IDBOperations<JobType>
    {
        private readonly ApiDbContext _db;
        public JobtypesMoc(ApiDbContext db)
        {
            _db = db;
        }

        public Task<JobType> Add(JobType t1)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<JobType> Edit(JobType t1)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobType>> GetAll()
        {
            return await  _db.JobTypes.ToListAsync();
        }

        public Task<JobType> GetbyId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobType>> SelCityByCountryID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
