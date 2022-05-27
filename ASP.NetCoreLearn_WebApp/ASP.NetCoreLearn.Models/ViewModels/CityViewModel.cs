﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.Models.ViewModels
{
    public class CityViewModel
    {
        public City City { get; set; } = new City();
        public IEnumerable<City> Cities { get; set; }  = new List<City>();
    }
}
