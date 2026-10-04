using Microsoft.EntityFrameworkCore;

namespace RentACarWebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

      
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer>Customers { get; set; }
    }
}