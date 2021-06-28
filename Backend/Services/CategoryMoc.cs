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
    public class CategoryMoc : IDBOperations<Category>
    {
        private readonly ApiDbContext _db;

        public CategoryMoc(ApiDbContext db)
        {
            _db = db;
        }

        public Task<Category> Add(Category t1)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Edit(Category t1)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _db.Category.ToListAsync();
        }

        public Task<Category> GetbyId(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> SelCityByCountryID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
