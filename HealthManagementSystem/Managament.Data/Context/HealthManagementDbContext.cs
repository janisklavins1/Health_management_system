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

            // FamilyDoctor
            builder.Entity<FamilyDoctor>()
                .HasOne(p => p.Person)
                .WithMany(f => f.FamilyDoctors)
                .OnDelete(DeleteBehavior.NoAction);

            // IllnessPerson
            builder.Entity<Person>()
                .HasMany(x => x.Illnesses)
                .WithMany(x => x.Persons)
                .UsingEntity<IllnessPerson>();
            builder.Entity<IllnessPerson>()
                .HasOne(x => x.Illness)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<IllnessPerson>()
                .HasOne(x => x.Person)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            // MedicationPersons
            //builder.Entity<Person>()
            //    .HasMany(x => x.Medications)
            //    .WithMany(x => x.Persons)
            //    .UsingEntity<MedicationPerson>();
            //builder.Entity<MedicationPerson>()
            //    .HasOne(x => x.Medication)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.NoAction);
            //builder.Entity<MedicationPerson>()
            //    .HasOne(x => x.Person)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.NoAction);

            // VaccinationPerson
            builder.Entity<Person>()
                .HasMany(x => x.Vaccinations)
                .WithMany(x => x.Persons)
                .UsingEntity<VaccinationPerson>();
            builder.Entity<VaccinationPerson>()
                .HasOne(x => x.Vaccination)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<VaccinationPerson>()
                .HasOne(x => x.Person)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<VaccinationPerson>()
                .HasOne(x => x.MedicalPractice)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            // LabResultStatusLabResult
            builder.Entity<LabResult>()
                .HasMany(x => x.LabResultStatuses)
                .WithMany(x => x.LabResults)
                .UsingEntity<LabResultStatusLabResult>();
            builder.Entity<LabResultStatusLabResult>()
                .HasOne(x => x.LabResult)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<LabResultStatusLabResult>()
                .HasOne(x => x.LabResultStatus)
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
