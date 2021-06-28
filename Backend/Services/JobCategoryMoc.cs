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

        
    public class JobCategoryMoc : IDBOperations<JobCategory>
    {
            private readonly ApiDbContext _db;

            public JobCategoryMoc(ApiDbContext db)
            {
                _db = db;
            }
            public async Task<JobCategory> Add(JobCategory t1)
            {
                throw new NotImplementedException();
            }

            public async Task<bool> Delete(string id)
            {
                throw new NotImplementedException();
            }

            public async Task<JobCategory> Edit(JobCategory t1)
            {
                throw new  NotImplementedException();
            }

            public async Task<List<JobCategory>> GetAll()
            {
                return await _db.JobCategory.ToListAsync();
            }

            public async Task<JobCategory> GetbyId(string id)
            {
            return await _db.JobCategory.FirstOrDefaultAsync(x => x.JobCat_Id == int.Parse(id));
            }
            public async Task<List<JobCategory>> SelCityByCountryID(int id)
            {
                return await _db.JobCategory.Where(x => x.CategoryID == id).Include(x=>x.Category).ToListAsync();
            }

 
    }
}
