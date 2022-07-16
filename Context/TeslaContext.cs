using microservice.Model;
using Microsoft.EntityFrameworkCore;

namespace microservice.Context
{
    public class TeslaContext : DbContext
    {
        public TeslaContext(DbContextOptions<TeslaContext> options) : base(options)
        {
        
        }

        public DbSet<Car> Car { get; set; }
    }
}
