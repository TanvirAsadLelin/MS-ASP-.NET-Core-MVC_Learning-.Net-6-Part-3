﻿using ASP.NetCoreLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICityRepository: IRepository<City>
    {
        void Update(City city); 
    }
}
