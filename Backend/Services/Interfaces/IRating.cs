
﻿using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRating
    {
        Task<string> Give_A_Rate(RatingModel rm);
        //  Task<string> Give_A_Rate(RatingModel rm);
       
    }
}
