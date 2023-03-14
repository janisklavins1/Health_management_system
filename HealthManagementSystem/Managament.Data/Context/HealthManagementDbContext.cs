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
            // FamilyDoctor
            builder.Entity<FamilyDoctor>()
                .HasOne(p => p.Person)
                .WithMany(f => f.FamilyDoctors)
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
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<AllergyPerson> AllergiesPerson { get; set; }
        public DbSet<TypeOfAllergy> TypeOfAllergies { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<IllnessPerson> IllnessesPersons { get; set; }
        public DbSet<MedicationPerson> MedicationPersons { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<VaccinationPerson> VaccinationPersons { get; set; }
        public DbSet<LabResultStatus> LabResultStatuses { get; set; }
        public DbSet<LabResultStatusLabResult> LabResultStatusLabResults { get; set; }
        public DbSet<LabResult> LabResults { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
