using Management.Data.Models;
using Management.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Context
{
    public class HealthManagementDbContext : DbContext
    {
        public HealthManagementDbContext(DbContextOptions<HealthManagementDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // AllergyPerson
            builder.Entity<Person>()
                .HasMany(x => x.Allergies)
                .WithMany(x => x.Persons)
                .UsingEntity<AllergyPerson>();

            builder.Entity<AllergyPerson>()
                .HasOne(x => x.Allergy)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<AllergyPerson>()
                .HasOne(x => x.Person)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            // FamilyDoctorPerson
            builder.Entity<Person>()
                .HasMany(x => x.FamilyDoctors)
                .WithMany(x => x.Persons)
                .UsingEntity<FamilyDoctorPerson>();

            builder.Entity<FamilyDoctorPerson>()
                .HasOne(x => x.FamilyDoctor)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<FamilyDoctorPerson>()
                .HasOne(x => x.Person)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PhoneNumberCountryCode> PhoneNumberCountryCodes { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MedicalPractice> MedicalPractices { get; set; }
        public DbSet<FamilyDoctor> FamilyDoctors { get; set; }
    }
}
