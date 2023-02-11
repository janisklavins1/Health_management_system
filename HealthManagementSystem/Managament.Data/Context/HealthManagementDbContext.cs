using Management.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Context
{
    public class HealthManagementDbContext : DbContext
    {
        public HealthManagementDbContext(DbContextOptions<HealthManagementDbContext> options) : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
    }
}
