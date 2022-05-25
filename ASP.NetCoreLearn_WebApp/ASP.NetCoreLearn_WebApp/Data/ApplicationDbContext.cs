using ASP.NetCoreLearn_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetCoreLearn_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<City> Cities { get; set; }
    }
}
