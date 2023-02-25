﻿// <auto-generated />
using System;
using Management.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Management.Data.Migrations
{
    [DbContext(typeof(HealthManagementDbContext))]
    [Migration("20230225155721_MedicalPraticeAndFamilyDoctorTablesAdded")]
    partial class MedicalPraticeAndFamilyDoctorTablesAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IngredientMedication", b =>
                {
                    b.Property<int>("IngredientsIngredientId")
                        .HasColumnType("int");

                    b.Property<int>("MedicationsMedicationId")
                        .HasColumnType("int");

                    b.HasKey("IngredientsIngredientId", "MedicationsMedicationId");

                    b.HasIndex("MedicationsMedicationId");

                    b.ToTable("IngredientMedication");
                });

            modelBuilder.Entity("Management.Data.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Management.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("HouseAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostIndex")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Management.Domain.Models.Allergy", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TypeOfAllergyId")
                        .HasColumnType("int");

                    b.HasKey("AllergyId");

                    b.HasIndex("TypeOfAllergyId");

                    b.ToTable("Allergy");
                });

            modelBuilder.Entity("Management.Domain.Models.AllergyPerson", b =>
                {
                    b.Property<int>("AllergyId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsPersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDiscovered")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("AllergyId", "PersonsPersonId");

                    b.HasIndex("AllergyId")
                        .IsUnique();

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("PersonsPersonId");

                    b.ToTable("AllergyPerson");
                });

            modelBuilder.Entity("Management.Domain.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Management.Domain.Models.FamilyDoctor", b =>
                {
                    b.Property<int>("FamilyDoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyDoctorId"));

                    b.Property<DateTime>("JoiningDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicalPracticeId")
                        .HasColumnType("int");

                    b.Property<string>("PlaceOfEducation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FamilyDoctorId");

                    b.HasIndex("MedicalPracticeId");

                    b.ToTable("FamilyDoctors");
                });

            modelBuilder.Entity("Management.Domain.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Management.Domain.Models.MedicalPractice", b =>
                {
                    b.Property<int>("MedicalPracticeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalPracticeId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumberId")
                        .HasColumnType("int");

                    b.Property<string>("WebsiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicalPracticeId");

                    b.HasIndex("AddressId");

                    b.HasIndex("PhoneNumberId");

                    b.ToTable("MedicalPractices");
                });

            modelBuilder.Entity("Management.Domain.Models.Medication", b =>
                {
                    b.Property<int>("MedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicationId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicationId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("Management.Domain.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PhoneNumberId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.HasIndex("PhoneNumberId");

                    b.HasIndex("RoleId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Management.Domain.Models.PhoneNumber", b =>
                {
                    b.Property<int>("PhoneNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneNumberId"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumberCountryCodeId")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("PhoneNumberId");

                    b.HasIndex("PhoneNumberCountryCodeId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("Management.Domain.Models.PhoneNumberCountryCode", b =>
                {
                    b.Property<int>("PhoneNumberCountryCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneNumberCountryCodeId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneNumberCountryCodeId");

                    b.ToTable("PhoneNumberCountryCodes");
                });

            modelBuilder.Entity("Management.Domain.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Management.Domain.Models.TypeOfAllergy", b =>
                {
                    b.Property<int>("TypeOfAllergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeOfAllergyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TypeOfAllergyId");

                    b.ToTable("TypeOfAllergy");
                });

            modelBuilder.Entity("IngredientMedication", b =>
                {
                    b.HasOne("Management.Domain.Models.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Management.Domain.Models.Medication", null)
                        .WithMany()
                        .HasForeignKey("MedicationsMedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Management.Domain.Models.Address", b =>
                {
                    b.HasOne("Management.Domain.Models.Address", null)
                        .WithMany("Addresses")
                        .HasForeignKey("AddressId");

                    b.HasOne("Management.Domain.Models.City", "City")
                        .WithMany("Address")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Management.Data.Models.Country", "Country")
                        .WithMany("Address")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Management.Domain.Models.Allergy", b =>
                {
                    b.HasOne("Management.Domain.Models.TypeOfAllergy", "TypeOfAllergies")
                        .WithMany("Allergies")
                        .HasForeignKey("TypeOfAllergyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfAllergies");
                });

            modelBuilder.Entity("Management.Domain.Models.AllergyPerson", b =>
                {
                    b.HasOne("Management.Domain.Models.Allergy", "Allergy")
                        .WithOne()
                        .HasForeignKey("Management.Domain.Models.AllergyPerson", "AllergyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Management.Domain.Models.Person", "Person")
                        .WithOne()
                        .HasForeignKey("Management.Domain.Models.AllergyPerson", "PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Management.Domain.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergy");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Management.Domain.Models.FamilyDoctor", b =>
                {
                    b.HasOne("Management.Domain.Models.MedicalPractice", "MedicalPractice")
                        .WithMany("FamilyDoctors")
                        .HasForeignKey("MedicalPracticeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalPractice");
                });

            modelBuilder.Entity("Management.Domain.Models.MedicalPractice", b =>
                {
                    b.HasOne("Management.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Management.Domain.Models.PhoneNumber", "PhoneNumber")
                        .WithMany("MedicalPractices")
                        .HasForeignKey("PhoneNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("Management.Domain.Models.Person", b =>
                {
                    b.HasOne("Management.Domain.Models.Address", "Address")
                        .WithMany("Persons")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Management.Domain.Models.PhoneNumber", "PhoneNumber")
                        .WithMany("Persons")
                        .HasForeignKey("PhoneNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Management.Domain.Models.Role", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("PhoneNumber");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Management.Domain.Models.PhoneNumber", b =>
                {
                    b.HasOne("Management.Domain.Models.PhoneNumberCountryCode", "PhoneNumberCountryCode")
                        .WithMany("PhoneNumber")
                        .HasForeignKey("PhoneNumberCountryCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhoneNumberCountryCode");
                });

            modelBuilder.Entity("Management.Data.Models.Country", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Management.Domain.Models.Address", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Management.Domain.Models.City", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Management.Domain.Models.MedicalPractice", b =>
                {
                    b.Navigation("FamilyDoctors");
                });

            modelBuilder.Entity("Management.Domain.Models.PhoneNumber", b =>
                {
                    b.Navigation("MedicalPractices");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Management.Domain.Models.PhoneNumberCountryCode", b =>
                {
                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("Management.Domain.Models.Role", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Management.Domain.Models.TypeOfAllergy", b =>
                {
                    b.Navigation("Allergies");
                });
#pragma warning restore 612, 618
        }
    }
}
