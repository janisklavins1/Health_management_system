using Management.Data.Models;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Context
{
    public class HealthManagementDbContext : DbContext
    {
        public HealthManagementDbContext(DbContextOptions<HealthManagementDbContext> options) : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
