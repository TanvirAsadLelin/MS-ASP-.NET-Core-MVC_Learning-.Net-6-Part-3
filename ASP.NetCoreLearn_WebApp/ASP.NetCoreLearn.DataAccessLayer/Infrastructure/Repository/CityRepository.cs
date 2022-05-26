using ASP.NetCoreLearn.DataAccessLayer.Infrastructure.IRepository;
using ASP.NetCoreLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.DataAccessLayer.Infrastructure.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {    
        private ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }

        public void Update(City city)
        {
          //  _context.Cities.Update(city);
          var cityDb = _context.Cities.FirstOrDefault(x => x.Id == city.Id);
            if (cityDb == null)
            {
                cityDb.Name = city.Name;
                cityDb.Population = city.Population;    
                cityDb.AreaSize = city.AreaSize;    
                cityDb.BuildDate = city.BuildDate;
            }

        }
    }
}
