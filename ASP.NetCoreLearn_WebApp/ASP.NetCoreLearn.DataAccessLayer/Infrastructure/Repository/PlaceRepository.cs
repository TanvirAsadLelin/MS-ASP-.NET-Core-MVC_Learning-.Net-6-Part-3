using ASP.NetCoreLearn.DataAccessLayer.Infrastructure.IRepository;
using ASP.NetCoreLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.DataAccessLayer.Infrastructure.Repository
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {    
        private ApplicationDbContext _context;
        public PlaceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }

        public void Update(Place place)
        {
            _context.Places.Update(place);
        }
    }
}
