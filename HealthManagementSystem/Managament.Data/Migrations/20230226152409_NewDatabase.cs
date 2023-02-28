using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Management.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalServices",
                columns: table => new
                {
                    MedicalServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalServices", x => x.MedicalServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberCountryCodes",
                columns: table => new
                {
                    PhoneNumberCountryCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberCountryCodes", x => x.PhoneNumberCountryCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfAllergies",
                columns: table => new
                {
                    TypeOfAllergyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfAllergies", x => x.TypeOfAllergyId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    HouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostIndex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientMedication",
                columns: table => new
                {
                    IngredientsIngredientId = table.Column<int>(type: "int", nullable: false),
                    MedicationsMedicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMedication", x => new { x.IngredientsIngredientId, x.MedicationsMedicationId });
                    table.ForeignKey(
                        name: "FK_IngredientMedication_Ingredients_IngredientsIngredientId",
                        column: x => x.IngredientsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientMedication_Medications_MedicationsMedicationId",
                        column: x => x.MedicationsMedicationId,
                        principalTable: "Medications",
                        principalColumn: "MedicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberCountryCodeId = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.PhoneNumberId);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhoneNumberCountryCodes_PhoneNumberCountryCodeId",
                        column: x => x.PhoneNumberCountryCodeId,
                        principalTable: "PhoneNumberCountryCodes",
                        principalColumn: "PhoneNumberCountryCodeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeOfAllergyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergyId);
                    table.ForeignKey(
                        name: "FK_Allergies_TypeOfAllergies_TypeOfAllergyId",
                        column: x => x.TypeOfAllergyId,
                        principalTable: "TypeOfAllergies",
                        principalColumn: "TypeOfAllergyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalPractices",
                columns: table => new
                {
                    MedicalPracticeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalPractices", x => x.MedicalPracticeId);
                    table.ForeignKey(
                        name: "FK_MedicalPractices_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalPractices_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "PhoneNumberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "PhoneNumberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDoctors",
                columns: table => new
                {
                    FamilyDoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalPracticeId = table.Column<int>(type: "int", nullable: false),
                    PlaceOfEducation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDoctors", x => x.FamilyDoctorId);
                    table.ForeignKey(
                        name: "FK_FamilyDoctors_MedicalPractices_MedicalPracticeId",
                        column: x => x.MedicalPracticeId,
                        principalTable: "MedicalPractices",
                        principalColumn: "MedicalPracticeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergiesPerson",
                columns: table => new
                {
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    DateDiscovered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergiesPerson", x => new { x.AllergyId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_AllergiesPerson_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "AllergyId");
                    table.ForeignKey(
                        name: "FK_AllergiesPerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    MedicalHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MedicalServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.MedicalHistoryId);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_MedicalServices_MedicalServiceId",
                        column: x => x.MedicalServiceId,
                        principalTable: "MedicalServices",
                        principalColumn: "MedicalServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDoctorsPersons",
                columns: table => new
                {
                    FamilyDoctorId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDoctorsPersons", x => new { x.FamilyDoctorId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_FamilyDoctorsPersons_FamilyDoctors_FamilyDoctorId",
                        column: x => x.FamilyDoctorId,
                        principalTable: "FamilyDoctors",
                        principalColumn: "FamilyDoctorId");
                    table.ForeignKey(
                        name: "FK_FamilyDoctorsPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressId",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_TypeOfAllergyId",
                table: "Allergies",
                column: "TypeOfAllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesPerson_AllergyId",
                table: "AllergiesPerson",
                column: "AllergyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesPerson_PersonId",
                table: "AllergiesPerson",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctors_MedicalPracticeId",
                table: "FamilyDoctors",
                column: "MedicalPracticeId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctorsPersons_FamilyDoctorId",
                table: "FamilyDoctorsPersons",
                column: "FamilyDoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDoctorsPersons_PersonId",
                table: "FamilyDoctorsPersons",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMedication_MedicationsMedicationId",
                table: "IngredientMedication",
                column: "MedicationsMedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_MedicalServiceId",
                table: "MedicalHistories",
                column: "MedicalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PersonId",
                table: "MedicalHistories",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPractices_AddressId",
                table: "MedicalPractices",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalPractices_PhoneNumberId",
                table: "MedicalPractices",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AddressId",
                table: "Persons",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PhoneNumberId",
                table: "Persons",
                column: "PhoneNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RoleId",
                table: "Persons",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhoneNumberCountryCodeId",
                table: "PhoneNumbers",
                column: "PhoneNumberCountryCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergiesPerson");

            migrationBuilder.DropTable(
                name: "FamilyDoctorsPersons");

            migrationBuilder.DropTable(
                name: "IngredientMedication");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "FamilyDoctors");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "MedicalServices");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "TypeOfAllergies");

            migrationBuilder.DropTable(
                name: "MedicalPractices");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "PhoneNumberCountryCodes");
        }
    }
}
