using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEducation
    {
        Task<List<userEducation>> OneUserEdu(string id);
        Task<List<typeOfEducation>> AllTypeEdu();
        Task<typeOfEducation>OneTypeEdu(int id);

    }
}
