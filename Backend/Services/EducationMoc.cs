using Models;
using Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class EducationMoc : IEducation
    {
        private readonly ApiDbContext _db;

        public EducationMoc(ApiDbContext db)
        {
            _db = db;
        }

        public async Task<List<typeOfEducation>> AllTypeEdu()
        {
            return await  _db.typeOfEducations.ToListAsync();
        }

        public async Task<typeOfEducation> OneTypeEdu(int id)
        {
            return await _db.typeOfEducations.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async  Task<List<userEducation>> OneUserEdu(string id)
        {
            var user = await _db.User.FirstOrDefaultAsync(x => x.UserName == id);
            var data = await _db.userEducations.Where(x => x.userID == user.Id).ToListAsync();
            return data;
        }
    }
}
