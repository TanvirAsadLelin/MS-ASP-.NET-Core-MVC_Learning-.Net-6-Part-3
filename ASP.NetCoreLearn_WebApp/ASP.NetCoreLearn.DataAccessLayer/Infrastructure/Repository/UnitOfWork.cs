using ASP.NetCoreLearn.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NetCoreLearn.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICityRepository City { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            City = new CityRepository(context);
        }
       

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
