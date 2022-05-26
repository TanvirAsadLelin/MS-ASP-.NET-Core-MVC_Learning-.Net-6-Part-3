using ASP.NetCoreLearn.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetCoreLearn.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
