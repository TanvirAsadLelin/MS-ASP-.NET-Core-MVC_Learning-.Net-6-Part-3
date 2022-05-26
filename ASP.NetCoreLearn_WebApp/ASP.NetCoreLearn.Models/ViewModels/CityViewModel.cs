using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.Models.ViewModels
{
    public class CityViewModel
    {
        public City City { get; set; }
        public IEnumerable<City> cities { get; set; } = new List<City>();   
    }
}
