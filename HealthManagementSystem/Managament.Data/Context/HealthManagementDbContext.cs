using Management.Data.Models;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Context
{
    public class HealthManagementDbContext : DbContext
    {
        public HealthManagementDbContext(DbContextOptions<HealthManagementDbContext> options) : base(options)
        { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Ingredient>().HasQueryFilter
        //}

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumberCountryCode> PhoneNumberCountryCodes { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
