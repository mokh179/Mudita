using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Services.ViewModels;

namespace Services
{
    public interface Iauth
    {
        Task<Authentication> RegisterAsync(RegisterModel rm);
        Task<Authentication> RegisterAsyncAdmin(RegisterModel rm);
        Task<Authentication> LogInAsync(LogInModel lm);
    }
}
